using MediatR;
using PatientManager.Application.Interfaces;
using PatientManager.Application.Interfaces.CSV;
using PatientManager.Application.Interfaces.XLSX;
using PatientManager.Application.Queries.Patient;
using PatientManager.Application.Queries.Patient.Exports;
using PatientManager.Domain.Common.DTOs;
using PatientManager.Domain.Common.Interfaces.Services;

namespace PatientManager.Application.Handlers.QueryHandlers
{
    public sealed class PatientQueryHandler : HandlerBase,
        IRequestHandler<GetPatientQuery, Domain.Common.Entities.Patient?>,
        IRequestHandler<GetPhotoQuery, byte[]?>,
        IRequestHandler<GetAttendancesQuery, PaginatedList<Domain.Common.Entities.Attendance>>,
        IRequestHandler<ExportAttendancesToCSVQuery, byte[]>,
        IRequestHandler<ExportPatientsToCSVQuery, byte[]>,
        IRequestHandler<ExportAttendancesToXLSXQuery, byte[]>,
        IRequestHandler<ExportPatientsToXLSXQuery, byte[]>

    {
        private readonly IReaderFileService _readerFileService;
        private readonly IPatientService _patientService;
        private readonly IExportFileCSV _exportFileCSV;
        private readonly IExportFileXLSX _exportFileXLSX;

        public PatientQueryHandler(IReaderFileService readerFileService,
                                   IPatientService patientService,
                                   IExportFileCSV exportFileCSV,
                                   IExportFileXLSX exportFileXLSX)
        {
            _readerFileService = readerFileService;
            _patientService = patientService;
            _exportFileCSV = exportFileCSV;
            _exportFileXLSX = exportFileXLSX;
        }

        public async Task<byte[]?> Handle(GetPhotoQuery request, CancellationToken cancellationToken)
        {
            var photoName = await _patientService.GetPhotoNameAsync(request.Id);
            if (string.IsNullOrWhiteSpace(photoName))
                return Array.Empty<byte>();

            return await _readerFileService.ReadOrDefaultAsync(new DTOs.FileTransfer(photoName));
        }

        public Task<Domain.Common.Entities.Patient?> Handle(GetPatientQuery request, CancellationToken cancellationToken)
            => _patientService.GetAsync(request.Id);

        public Task<PaginatedList<Domain.Common.Entities.Attendance>> Handle(GetAttendancesQuery request, CancellationToken cancellationToken)
        {
            return _patientService.GetAttendancesAsync(request.Id, request.FilterInput);
        }

        public async Task<byte[]> Handle(ExportAttendancesToCSVQuery request, CancellationToken cancellationToken)
        {
            var attendances = await _patientService.GetAttendancesAsync(request.PatientId);
            return await _exportFileCSV.WriteDataAsync(attendances.ToList());
        }

        public async Task<byte[]> Handle(ExportPatientsToCSVQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientService.GetPatientsAsync();
            var file = await _exportFileCSV.WriteDataAsync(patients.ToList());
            return file;
        }

        public async Task<byte[]> Handle(ExportPatientsToXLSXQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientService.GetPatientsAsync();
            var file = await _exportFileXLSX.WriteDataPatientsAsync(patients.ToList());
            return file;
        }

        public async Task<byte[]> Handle(ExportAttendancesToXLSXQuery request, CancellationToken cancellationToken)
        {
            var attendances = await _patientService.GetAttendancesAsync(request.PatientId);
            var file = await _exportFileXLSX.WriteDataAttendancesAsync(attendances.ToList());
            return file;
        }
    }
}
