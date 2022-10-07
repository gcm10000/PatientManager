using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PatientManager.Domain.Common.DTOs;
using PatientManager.Domain.Common.Entities;
using PatientManager.Domain.Common.Interfaces.Repositories;
using PatientManager.Domain.Common.Interfaces.Services;
using PatientManager.Domain.Common.ValueObjects;
using System.Linq.Expressions;

namespace PatientManager.Domain.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PaginatedList<Patient>> SearchAsync(FilterInput filterInput)
        {
            Expression<Func<Patient, bool>> filter = patient => patient.Person.Name.ToLower().Contains(filterInput.Query.ToLower()) ||
                                                                patient.Person.CPF.ToLower().Contains(filterInput.Query.ToLower()) ||
                                                                patient.Person.RG.ToLower().Contains(filterInput.Query.ToLower());

            Expression<Func<Patient, Patient>> selector = 
                patient => new Patient() 
                { 
                    Id = patient.Id,
                    Person = patient.Person
                };

            var entities = await _patientRepository.GetAllAsync(page: filterInput.CurrentPage,
                                                  pageSize: filterInput.ItemsPerPage,
                                                  filter: filter,
                                                  selector: selector);

            var count = await _patientRepository.CountAsync(filter);

            return new PaginatedList<Patient>(entities, count, filterInput.CurrentPage, filterInput.ItemsPerPage);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            Expression<Func<Patient, Patient>> selector =
                patient => new Patient()
                {
                    Person = patient.Person,
                    HealthInsurance = patient.HealthInsurance,
                    MedicalRecordNumber = patient.MedicalRecordNumber
                };

            var entities = await _patientRepository
                .GetAllAsync(selector: selector);
            return entities;
        }

        public Task<Patient?> GetAsync(int id)
            => _patientRepository.GetAsync(id);

        public async Task<string?> GetPhotoNameAsync(int patientId)
        {
            Expression<Func<Patient, Patient>> selector = 
                p => new Patient 
                { 
                    Person = new Person(default, p.Person.Photo, default, default)
                };
            var entity = await _patientRepository.GetAsync(patientId, selector: selector);
            return entity?.Person.Photo;
        }

        public async Task<List<string>> AddAsync(Patient patient)
        {
            var notifications = await ValidatePatient(patient).ToListAsync();

            if (!notifications.Any())
            {
                await _patientRepository.AddAsync(patient);
                await _patientRepository.SaveChangeAsync();
            }

            return notifications;
        }

        public async Task<List<string>> UpdateAsync(Patient patient)
        {
            var notifications = await ValidatePatient(patient, updateMode: true)
                .ToListAsync();

            if (!notifications.Any())
            {
                _patientRepository.Update(patient);
                await _patientRepository.SaveChangeAsync();
            }

            return notifications;
        }

        public async Task<PaginatedList<Attendance>> GetAttendancesAsync(int patientId, FilterInput filterInput)
        {
            var attendances = await _patientRepository.GetAttendancesAsync(patientId, filterInput.CurrentPage, filterInput.ItemsPerPage);
            var count = await _patientRepository.CountAttendancesAsync(patientId);

            return new PaginatedList<Attendance>(attendances, count, filterInput.CurrentPage, filterInput.ItemsPerPage);
        }

        public async Task AttendPatientAsync(int patientId)
        {
            static IIncludableQueryable<Patient, object> include(IQueryable<Patient> x) => x.Include(a => a.Attendances);
            var patient = await _patientRepository.GetAsync(patientId, include: include, tracking: true);
            if (patient is not null)
                patient.Attendances.Add(new Attendance());
            await _patientRepository.SaveChangeAsync();
        }

        public async Task RemoveAttendFromPatientAsync(int patientId, int attendId)
        {
            static IIncludableQueryable<Patient, object> include(IQueryable<Patient> x) => x.Include(a => a.Attendances);
            var patient = await _patientRepository.GetAsync(patientId, include: include, tracking: true);
            if (patient is not null)
                patient.Attendances.Remove(patient.Attendances.First(x => x.Id.Equals(attendId)));
            await _patientRepository.SaveChangeAsync();
        }

        public async Task<List<string>> UpdateAttendPatientAsync(int patientId, int attendId, DateTime date)
        {
            var notifications = ValidateAttend(date).ToList();
            if (notifications.Any())
                return notifications;

            static IIncludableQueryable<Patient, object> include(IQueryable<Patient> x) => x.Include(a => a.Attendances);
            var patient = await _patientRepository.GetAsync(patientId, include: include, tracking: true);
            if (patient is null)
                throw new ArgumentNullException(patientId.ToString(), "Paciente não encontrado.");

            var attend = patient.Attendances.First(x => x.Id.Equals(attendId));

            attend.Date = date;
            await _patientRepository.SaveChangeAsync();
            return notifications;
        }

        private async IAsyncEnumerable<string> ValidatePatient(Patient patient, bool updateMode = false)
        {
            var person = patient.Person;

            if (string.IsNullOrWhiteSpace(person.Name))
                yield return "Nome inválido.";

            if (!person.IsCPFValid())
                yield return "CPF inválido.";

            if (!updateMode)
            {
                var personExist = await _patientRepository
                    .AnyAsync(patient => patient.Person.CPF.Equals(person.CPF));
                if (personExist)
                    yield return "CPF já existente.";
            }

            if (string.IsNullOrWhiteSpace(person.RG))
                yield return "RG inválido.";

            if (patient.MedicalRecordNumber <= 0)
                yield return "Número do prontuário deve ser válido.";

            if (string.IsNullOrWhiteSpace(patient.HealthInsurance))
                yield return "Convênio deve ser preenchido.";
        }

        private static IEnumerable<string> ValidateAttend(DateTime date)
        {
            if (date > DateTime.Now)
                yield return "Data inserida é maior que a data atual.";
        }

        public Task<IEnumerable<Attendance>> GetAttendancesAsync(int patientId)
        {
            var attendances = _patientRepository.GetAttendancesAsync(patientId);
            return attendances;
        }
    }
}
