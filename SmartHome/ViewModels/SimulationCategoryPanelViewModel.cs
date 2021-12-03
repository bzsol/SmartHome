using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmartHome.ViewModels
{
    public class SimulationCategoryPanelViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> CategoryClicked { get; set; }

        public static bool IsSimulation;

        private object _categoryPanelViewModel;
        public object CategoryPanelViewModel
        {
            get => _categoryPanelViewModel;
            set
            {
                _categoryPanelViewModel = value;
                NotifyChange(nameof(CategoryPanelViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public SimulationCategoryPanelViewModel()
        {
            CategoryClicked = new DelegateCommand<Button>(OnCategoryClicked);
            CategoryPanelViewModel = new SimulationPanelViewModel();
            IsSimulation = true;
        }

        public void OnCategoryClicked(Button btn)
        {
            switch (btn.Name)
            {
                case "btnCat1":
                    CategoryPanelViewModel = new SimulationPanelViewModel();
                    IsSimulation = true;
                    LaunchTimer();
                    break;
                case "btnCat2":
                    CategoryPanelViewModel = new GardenPanelViewModel();
                    IsSimulation = false;
                    LaunchTimer();
                    break;
            }
        }

        public void LaunchTimer()
        {
            if (DashboardViewModel.dispatcherTimer.IsEnabled && IsSimulation)
            {
                GardenPanelViewModel.dispatcherTimer.Stop();
                SimulationPanelViewModel.dispatcherTimer.Start();
            }
            else if (DashboardViewModel.dispatcherTimer.IsEnabled && !IsSimulation)
            {
                GardenPanelViewModel.dispatcherTimer.Start();
                SimulationPanelViewModel.dispatcherTimer.Stop();
            }
        }
    }
}