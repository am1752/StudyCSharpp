using Caliburn.Micro;
using MqttMonitoringApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttMonitoringApp.ViewModels
{
    class ErrorPopupViewModel : Conductor<object>
    {
        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set {
                errorMessage = value;
                NotifyOfPropertyChange(() => errorMessage);
            }
        }

        public ErrorPopupViewModel(string param)
        {
            var tmp = param.Split('|');
            DisplayName = tmp[0];
            ErrorMessage = tmp[1];
        }

        public void ConfirmClose()
        {
            TryClose(true);
        }
    }
}
