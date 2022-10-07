using PatientManager.WinFormsApp.Interfaces;

namespace PatientManager.WinFormsApp.Forms
{
    public partial class FormConfigurePageSize : Form
    {
        private readonly IPageSizeService _pageSize;

        public FormConfigurePageSize(IPageSizeService pageSize)
        {
            _pageSize = pageSize;
            InitializeComponent();
            InitializeCombobox();
        }

        private void InitializeCombobox()
        {
            var pageSize = _pageSize.PageSize;
            _comboBox.SelectedIndex = _comboBox.FindString(pageSize.ToString());
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            var text = _comboBox.Text;
            await _pageSize.SetPageSizeAsync(int.Parse(text));
            MessageBox.Show("Alteração feita com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
