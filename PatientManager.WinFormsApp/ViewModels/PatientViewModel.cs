namespace PatientManager.WinFormsApp.ViewModels
{
    public record PatientViewModel : ViewModel
    {
        public string? Name { get; private set; }
        public string? CPF { get; private set; }
        public string? RG { get; private set; }
        public PatientViewModel(int id, string? name, string? cpf, string? rg)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            RG = rg;
        }
    }
}
