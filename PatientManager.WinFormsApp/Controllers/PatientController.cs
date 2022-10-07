using MediatR;
using PatientManager.Application.Commands.Patient;
using PatientManager.Application.Commands.Patient.Exports;
using PatientManager.Application.Queries.Patient;
using PatientManager.Domain.Common.DTOs;
using PatientManager.Domain.Common.Entities;

namespace PatientManager.WinFormsApp.Controllers
{
    public class PatientController
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> AddAsync(CreatePatientCommand command)
        {
            try
            {
                var notifications = await _mediator.Send(command);
                if (notifications.Success)
                {
                    MessageBox.Show("Cadastro realizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                var message = string.Join(Environment.NewLine, notifications.Errors);
                MessageBox.Show(message, "Erro Durante Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine, "Erro Durante Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(UpdatePatientCommand command)
        {
            try
            {
                var notifications = await _mediator.Send(command);
                if (notifications.Success)
                {
                    MessageBox.Show("Cadastro atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                var message = string.Join(Environment.NewLine, notifications.Errors);
                MessageBox.Show(message, "Erro Durante Atualização", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException?.Message, $"Erro Durante Atualização", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public async Task<bool> UpdateAttendPatientAsync(UpdateAttendPatientCommand command)
        {
            try
            {
                var notifications = await _mediator.Send(command);
                if (notifications.Success)
                {
                    MessageBox.Show("Presença atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                var message = string.Join(Environment.NewLine, notifications.Errors);
                MessageBox.Show(message, "Erro Durante Atualização", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException?.Message,
                "Erro Durante Atualização da Presença",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            return false;
        }

        public async Task<bool> AttendPatientAsync(AttendPatientCommand command)
        {
            try
            {
                await _mediator.Send(command);
                MessageBox.Show("Presença adicionada ao paciente com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException?.Message,
                                "Erro Durante Adição da Presença",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> RemoveAttendPatientAsync(DeleteAttendPatientCommand command)
        {
            try
            {
                await _mediator.Send(command);
                MessageBox.Show("Remoção de presença realizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException?.Message, $"Erro Durante Tentativa de Apagar Presença do Paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }


        public Task<Patient> GetAsync(GetPatientQuery query)
            => _mediator.Send(query);

        public Task<byte[]?> GetPhotoAsync(GetPhotoQuery query)
            => _mediator.Send(query);

        public async Task<PaginatedList<Attendance>?> GetAttendancesAsync(GetAttendancesQuery query)
        {
            try
            {
                var attendances = await _mediator.Send(query);
                return attendances;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException?.Message, $"Erro Durante Tentativa de Obter Presenças do Paciente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public async Task<byte[]?> ExportPatientToXLSXAsync(ExportPatientsToXLSXQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message + Environment.NewLine + ex.InnerException?.Message,
                "Erro Durante Exportação de Pacientes no Formato XLSX",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.ServiceNotification);
            }
            return null;
        }

        public async Task<byte[]?> ExportPatientToCSVAsync(ExportPatientsToCSVQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message + Environment.NewLine + ex.InnerException?.Message,
                "Erro Durante Exportação de Pacientes no Formato CSV",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.ServiceNotification);
            }
            return null;
        }

        public async Task<byte[]?> ExportAttendancesToXLSXAsync(ExportAttendanceToXLSXCommand query)
        {
            try
            {
                var result = await _mediator.Send(query);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message + Environment.NewLine + ex.InnerException?.Message,
                "Erro Durante Exportação de Presenças no Formato XLSX",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.ServiceNotification);
            }
            return null;
        }

        public async Task<byte[]?> ExportAttendancesToCSVAsync(ExportAttendancesToCSVCommand query)
        {
            try
            {
                var result = await _mediator.Send(query);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message + Environment.NewLine + ex.InnerException?.Message,
                "Erro Durante Exportação de Presenças no Formato CSV",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.ServiceNotification);
            }
            return null;
        }
    }
}
