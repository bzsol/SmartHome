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
        }

        public void OnCategoryClicked(Button btn)
        {
            switch (btn.Name)
            {
                case "btnCat1":
                    CategoryPanelViewModel = new SimulationPanelViewModel();
                    break;
                case "btnCat2":
                    CategoryPanelViewModel = new GardenPanelViewModel();
                    break;
            }
        }
    }
}