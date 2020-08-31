using Caliburn.Micro;
using StartCaliburnApp.ViewModels;
using System.Security.RightsManagement;
using System.Windows;

namespace StartCaliburnApp
{
    class Bootstrapper :BootstrapperBase
    {
        public Bootstrapper (){
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ButtonsViewModel>(); // object => ViewModel
        }
    }
}
