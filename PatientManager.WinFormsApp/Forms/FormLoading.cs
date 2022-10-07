namespace PatientManager.WinFormsApp.Forms
{
    public partial class FormLoading : Form
    {
        private readonly Action _action;

        public FormLoading(Action action)
        {
            InitializeComponent();
            _action = action;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(_action)
                .ContinueWith(t =>
            {
                this.Close();
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
