using PatientManager.Domain.Common.DTOs;
using PatientManager.WinFormsApp.Controllers;
using PatientManager.WinFormsApp.Extensions;
using PatientManager.WinFormsApp.Interfaces;
using PatientManager.WinFormsApp.ViewModels;
using System.ComponentModel;

namespace PatientManager.WinFormsApp.Forms
{
    public partial class FormAttendances : Form
    {
        private readonly PatientController _patientController;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPageSizeService _pageSize;
        private readonly Guid guid;
        private FilterInput _filterInput;
        private int _patientId;
        public FormAttendances(PatientController patientController,
                               IServiceProvider serviceProvider,
                               IPageSizeService pageSize)
        {
            InitializeComponent();
            _patientController = patientController;
            _serviceProvider = serviceProvider;
            _pageSize = pageSize;
            _filterInput = new FilterInput(1, _pageSize.PageSize, string.Empty);
        }

        public async void SetPatient(int patientId)
        {
            _patientId = patientId;
            await FillUI();
        }

        private async Task FillUI()
        {
            var responseList = await _patientController.GetAttendancesAsync(new(_patientId, _filterInput));
            if (responseList is null)
                return;

            var attendancesDates = responseList.Items.Select(attendance => new AttendanceViewModel(attendance.Id, attendance.Date.ToString()));
            var list = new BindingList<AttendanceViewModel>(attendancesDates.ToList());
            _dataGridViewResults.Columns.Clear();
            _dataGridViewResults.DataSource = list;
            _dataGridViewResults.Columns[nameof(AttendanceViewModel.Date)].HeaderText = "Data";
            _dataGridViewResults.Columns[nameof(AttendanceViewModel.Id)].Visible = false;
            _dataGridViewResults.Refresh();

            if (responseList.TotalCount.Equals(0))
            {
                _labelPagination.Text = "Nenhum resultado encontrado.";
                return;
            }

            _buttonPrevious.Enabled = responseList.HasPreviousPage;
            _buttonNext.Enabled = responseList.HasNextPage;
            _labelPagination.Text = $"Exibindo {_filterInput.ItemsPerPage * (_filterInput.CurrentPage - 1) + 1}-{(responseList.HasNextPage ? responseList.Items.Count() * responseList.PageNumber : responseList.TotalCount)} de {responseList.TotalCount} resultados.";
            _dataGridViewResults.ClearSelection();
        }

        private async void AtualizarPresençaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var attendance = GetAttendanceViewModelOrDefault();
            var form = _serviceProvider.GetForm<FormUpdateAttendance>();
            if (attendance is not null && form is not null)
            {
                form.SetAttendance(_patientId, attendance.Id, DateTime.Parse(attendance.Date));
                if (form.ShowDialog().Equals(DialogResult.OK))
                    await FillUI();
            }
        }

        private async void RemoverPresençaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var attendance = GetAttendanceViewModelOrDefault();
            if (attendance is not null)
                await _patientController.RemoveAttendPatientAsync(new() { PatientId = _patientId, AttendId = attendance.Id });

            await FillUI();
        }

        private AttendanceViewModel? GetAttendanceViewModelOrDefault()
        {
            var attendaceViewModel = _dataGridViewResults.SelectedRows[0].DataBoundItem as AttendanceViewModel;
            if (attendaceViewModel is null)
                MessageBox.Show("Erro ao capturar registro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return attendaceViewModel;
        }

        private void DataGridViewResults_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = _dataGridViewResults.HitTest(e.X, e.Y);
                _dataGridViewResults.ClearSelection();
                _dataGridViewResults.Rows[hti.RowIndex].Selected = true;
            }
        }

        private async void ButtonPrevious_Click(object sender, EventArgs e)
        {
            _filterInput = _filterInput with { CurrentPage = _filterInput.CurrentPage - 1 };
            await FillUI();
        }

        private async void ButtonNext_Click(object sender, EventArgs e)
        {
            _filterInput = _filterInput with { CurrentPage = _filterInput.CurrentPage + 1 };
            await FillUI();
        }

        private void ExportarPresençasParaCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_saveFileDialogCSV.ShowDialog() != DialogResult.OK)
                return;

            var fileName = _saveFileDialogCSV.FileName;

            using var form = new FormLoading(async () => await SaveFileCSVAsync(fileName));
            form.ShowDialog();
        }

        private async Task SaveFileCSVAsync(string fileName)
        {
            try
            {
                var csvBytes = await _patientController.ExportAttendancesToCSVAsync(new(_patientId));
                if (csvBytes is null)
                    return;

                using var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                await fs.WriteAsync(csvBytes);
                await fs.FlushAsync();

                MessageBox.Show(
                    "Exportação de presenças no formato CSV realizada com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.ServiceNotification);

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
        }

        private void ExportarPresençasParaXLSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_saveFileDialogXLSX.ShowDialog() != DialogResult.OK)
                return;

            var fileName = _saveFileDialogXLSX.FileName;
            using var form = new FormLoading(async () => await SaveFileXLSXAsync(fileName));
            form.ShowDialog();
        }

        private async Task SaveFileXLSXAsync(string fileName)
        {
            try
            {
                var xlsxBytes = await _patientController.ExportAttendancesToXLSXAsync(new(_patientId));
                if (xlsxBytes is null)
                    return;

                using var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                await fs.WriteAsync(xlsxBytes);
                await fs.FlushAsync();

                MessageBox.Show(
                    "Exportação de presenças no formato XLSX realizada com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.ServiceNotification);

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
        }
    }
}
