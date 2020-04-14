using BillingManagement.UI.ViewModels;
using BillingManagement.UI.Views;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// petite modif test branche
    public partial class App : Application
    {
        MainWindow _window;

        public App()
        {
            //CustomerViewModel vm = new CustomerViewModel();

            _window = new MainWindow();
            _window.Show();
        }
    }
}
