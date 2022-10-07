using Microsoft.Extensions.DependencyInjection;

namespace PatientManager.WinFormsApp.Extensions
{
    public static class IServiceProviderExtensions
    {
        public static TForm? GetForm<TForm>(this IServiceProvider serviceProvider) where TForm : Form
        {
            var scope = serviceProvider.CreateScope();
            return scope.ServiceProvider.GetService<TForm>();
        }

        public static DialogResult? TryShowDialogFromAnotherForm<TForm>(this IServiceProvider serviceProvider)
            where TForm : Form
        {
            using var scope = serviceProvider.CreateScope();
            var form = scope.ServiceProvider.GetService<TForm>();
            return form?.ShowDialog();
        }
    }
}
