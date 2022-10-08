using MediatR;
using PatientManager.Application.Commands.Patient;
using PatientManager.Application.DTOs;
using PatientManager.Application.Interfaces;
using PatientManager.Application.Interfaces.CSV;
using PatientManager.Application.Interfaces.XLSX;
using PatientManager.Application.Models;
using PatientManager.Domain.Common.Interfaces.Services;
using PatientManager.Domain.Common.ValueObjects;

namespace PatientManager.Application.Handlers.CommandHandlers
{
    public class PatientCommandHandler 
        : HandlerBase,
        IRequestHandler<CreatePatientCommand, Response>,
        IRequestHandler<UpdatePatientCommand, Response>,
        IRequestHandler<AttendPatientCommand, Response>,
        IRequestHandler<UpdateAttendPatientCommand, Response>,
        IRequestHandler<DeleteAttendPatientCommand, Response>

    {
        private readonly IPatientService _patientService;
        private readonly IWriterFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExportFileCSV _exportFileCSV;
        private readonly IExportFileXLSX _exportFileXLSX;

        public PatientCommandHandler(
            IPatientService patientService,
            IWriterFileService fileService,
            IUnitOfWork unitOfWork,
            IExportFileCSV exportFileCSV,
            IExportFileXLSX exportFileXLSX)
        {
            _patientService = patientService;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
            _exportFileCSV = exportFileCSV;
            _exportFileXLSX = exportFileXLSX;
        }

        public async Task<Response> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
        {
            var guid = Guid.NewGuid();
            using (_unitOfWork)
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);
                var photo = command.GetPhoto(guid);
                var patient = new Domain.Common.Entities.Patient()
                {
                    Person = new Person(command.Name, photo, command.CPF, command.RG),
                    MedicalRecordNumber = command.MedicalRecordNumber,
                    HealthInsurance = command.HealthInsurance ?? ""
                };
                var notifications = await _patientService.AddAsync(patient);

                await PublishFile(command, guid, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);
                return new Response(notifications);
            }
        }

        public async Task<Response> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            var guid = Guid.NewGuid();

            var (photoName, publish) = await GetNewPhotoNameOrAlreadyExistsInDatabase(command, guid);

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var person = new Person(command.Name,
                                    IsToDeletePhoto(command) ? default : photoName,
                                    command.CPF,
                                    command.RG);


            var patient = new Domain.Common.Entities.Patient()
            {
                Id = command.Id,
                Person = person,
                MedicalRecordNumber = command.MedicalRecordNumber,
                HealthInsurance = command.HealthInsurance ?? ""
            };

            var notifications = await _patientService.UpdateAsync(patient);

            if (photoName is not null && publish)
                await PublishFile(command, guid, cancellationToken);
            
            if (IsToDeletePhoto(command) && photoName is not null)
            {
                var fileTransfer = new FileTransfer(photoName);
                await _fileService.DeleteFileAsync(fileTransfer, cancellationToken);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return new Response(notifications);
        }

        public async Task<Response> Handle(AttendPatientCommand request, CancellationToken cancellationToken)
        {
            await _patientService.AttendPatientAsync(request.Id);
            return new Response(true);
        }

        public async Task<Response> Handle(UpdateAttendPatientCommand request, CancellationToken cancellationToken)
        {
            var notifications = await _patientService.UpdateAttendPatientAsync(request.PatientId, request.AttendId, request.Date);
            return new Response(notifications);
        }

        public async Task<Response> Handle(DeleteAttendPatientCommand request, CancellationToken cancellationToken)
        {
            await _patientService.RemoveAttendFromPatientAsync(request.PatientId, request.AttendId);
            return new Response(true);
        }

        private async Task<(string? fileName, bool publish)> GetNewPhotoNameOrAlreadyExistsInDatabase(UpdatePatientCommand command, Guid guid)
        {
            if (command.Photo?.Data is null)
            {
                var photoName = await _patientService.GetPhotoNameAsync(command.Id);
                return (photoName, false);
            }

            if (command.Photo.Data.Equals(Array.Empty<byte>()))
            {
                var photoName = await _patientService.GetPhotoNameAsync(command.Id);
                return (photoName, false);
            }

            return (guid.ToString() + command.Photo?.Extension, true);
        }

        private async Task<Guid?> PublishFile(PatientCommand command, Guid guid, CancellationToken cancellationToken)
        {
            if (command.Photo is not null)
            {
                var fileTransfer = new FileTransfer(command.Photo.Data, guid, command.Photo.Extension);
                await _fileService.PublishFileAsync(fileTransfer, cancellationToken);
                return guid;
            }
            return null;
        }

        private static bool IsToDeletePhoto(UpdatePatientCommand command)
        {
            return command.Photo is not null && command.Photo.Data.Equals(Array.Empty<byte>());
        }
    }
}
