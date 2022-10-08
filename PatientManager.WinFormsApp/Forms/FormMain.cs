using PatientManager.Domain.Common.DTOs;
using PatientManager.Domain.Common.Interfaces.Services;
using PatientManager.WinFormsApp.Controllers;
using PatientManager.WinFormsApp.Extensions;
using PatientManager.WinFormsApp.Interfaces;
using PatientManager.WinFormsApp.ViewModels;
using System.ComponentModel;
using System;

namespace PatientManager.WinFormsApp.Forms
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPatientService _patientService;
        private readonly IPageSizeService _pageSize;
        private readonly PatientController _patientController;
        private FilterInput _filterInput;
        private string? _actualText;

        public FormMain(IServiceProvider serviceProvider,
                        IPatientService patientService,
                        IPageSizeService pageSize,
                        PatientController patientController)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            _patientService = patientService;
            _pageSize = pageSize;
            _patientController = patientController;
            _filterInput = new FilterInput(1, _pageSize.PageSize, string.Empty);
        }

        #region EventsMethods

        private async void AdicionarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = _serviceProvider.TryShowDialogFromAnotherForm<FormAddOrUpdatePatient>();
            if (dialog == DialogResult.OK)
                await SearchAndManipuleUI();
        }

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            await SearchPatient();
            await SearchAndManipuleUI();
        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                await SearchPatient();
            }
        }

        private async void ButtonPrevious_Click(object sender, EventArgs e)
        {
            _filterInput = _filterInput with { CurrentPage = _filterInput.CurrentPage - 1 };
            await SearchAndManipuleUI();
        }

        private async void ButtonNext_Click(object sender, EventArgs e)
        {
            _filterInput = _filterInput with { CurrentPage = _filterInput.CurrentPage + 1 };
            await SearchAndManipuleUI();
        }

        #endregion

        private async Task SearchPatient()
        {
            var text = _textBoxSearch.Text;
            if (_actualText.Equals(text))
                return;

            _filterInput = _filterInput with { CurrentPage = 1, Query = text, ItemsPerPage = _pageSize.PageSize };
            await SearchAndManipuleUI();
        }

        private async Task SearchAndManipuleUI()
        {
            var responseList = await _patientService.SearchAsync(_filterInput);
            _actualText = _textBoxSearch.Text;
            var persons = responseList.Items.Select(x => new PatientViewModel
            (
                x.Id,
                x.Person.Name,
                x.Person.CPF,
                x.Person.RG
            ));
            
            var list = new BindingList<PatientViewModel>(persons.ToList());
            _dataGridViewResults.Columns.Clear();
            _dataGridViewResults.DataSource = list;
            _dataGridViewResults.Columns.Remove("Id");
            _dataGridViewResults.Columns["Name"].HeaderText = "Nome";

            if (responseList.TotalCount.Equals(0))
            {
                _labelPagination.Text = "Nenhum resultado encontrado.";
                return;
            }

            _buttonPrevious.Enabled = responseList.HasPreviousPage;
            _buttonNext.Enabled = responseList.HasNextPage;
            _labelPagination.Text = $"Exibindo {_filterInput.ItemsPerPage * (_filterInput.CurrentPage - 1) + 1}-{(responseList.HasNextPage ? responseList.Items.Count() * responseList.PageNumber : responseList.TotalCount)} de {responseList.TotalCount} resultados.";
        }

        private async void DataGridViewResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var patients = _dataGridViewResults.DataSource as IList<PatientViewModel>;
            var form = _serviceProvider.GetForm<FormViewPatient>();
            if (form is null || patients is null)
                return;

            var patient = patients[e.RowIndex];
            form.SetPatient(patient.Id);
            form?.ShowDialog();

            await SearchAndManipuleUI();
        }

        private void DataGridViewResults_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           if (e.RowIndex > -1)
             _dataGridViewResults.Rows[e.RowIndex].Selected = true;
        }

        private void ConfigurarNúmeroDeRegistroPorPáginaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _serviceProvider.TryShowDialogFromAnotherForm<FormConfigurePageSize>();
            _filterInput = _filterInput with { CurrentPage =  1, ItemsPerPage = _pageSize.PageSize };
        }

        private void ExportarParaCSVToolStripMenuItem_Click(object sender, EventArgs e)
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
                var csvBytes = await _patientController.ExportPatientToCSVAsync(new());
                if (csvBytes is null)
                    return;

                using var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                await fs.WriteAsync(csvBytes);
                await fs.FlushAsync();

                MessageBox.Show(
                    "Exportação de pacientes no formato CSV realizada com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message + Environment.NewLine + ex.InnerException?.Message,
                    "Erro Durante Exportação de Pacientes no Formato CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ExportarParaXLSXToolStripMenuItem_Click(object sender, EventArgs e)
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
                var xlsxBytes = await _patientController.ExportPatientToXLSXAsync(new());
                if (xlsxBytes is null)
                    return;

                using var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                await fs.WriteAsync(xlsxBytes);
                await fs.FlushAsync();

                MessageBox.Show(
                    "Exportação de pacientes no formato XLSX realizada com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message + Environment.NewLine + ex.InnerException?.Message,
                    "Erro Durante Exportação de Pacientes no Formato XLSX",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigurarCâmeraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetForm<FormConfigureCamera>();
            if (form is null)
                return;
            form.ShowDialog();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await SearchAndManipuleUI();
        }
    }
}
