using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SmartHome.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> ChangeToSimulation { get; set; }
        public DelegateCommand<Button> ChangeToConfiguration { get; set; }

        private object _userControlViewModel;
        public object UserControlViewModel
        {
            get => _userControlViewModel;
            set
            {
                _userControlViewModel = value;
                NotifyChange(nameof(UserControlViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public DashboardViewModel()
        {
            ChangeToSimulation = new DelegateCommand<Button>(OnChangeToSimulation);
            ChangeToConfiguration = new DelegateCommand<Button>(OnChangeToConfiguration);
        }

        public void OnChangeToSimulation(Button btn)
        {
            UserControlViewModel = new SimulationCategoryPanelViewModel();
        }

        public void OnChangeToConfiguration(Button btn)
        {
            UserControlViewModel = new ConfigurePanelViewModel();
        }
    }
}
