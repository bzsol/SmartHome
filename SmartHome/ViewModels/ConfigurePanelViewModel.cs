using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SmartHome.ViewModels
{
    public class ConfigurePanelViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> CategoryClicked { get; set; }

        public static ConfigurePanelViewModel ActuallyShownConfigurePanel;

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

        public ConfigurePanelViewModel()
        {
            CategoryClicked = new DelegateCommand<Button>(OnCategoryClicked);
            ActuallyShownConfigurePanel = this;
            CategoryPanelViewModel = new ElectronicCategoryPanelViewModel();
        }

        public void ExecuteChangeToElectronicPanel(bool ToEventList)
        {
            if (ToEventList)
            {
                CategoryPanelViewModel = new ElectronicEventListViewModel();
            }
            else
            {
                CategoryPanelViewModel = new ElectronicCategoryPanelViewModel();
            }

        }

        public void OnCategoryClicked(Button btn)
        {
            switch (btn.Name)
            {
                case "btnCat1":
                    CategoryPanelViewModel = new ElectronicCategoryPanelViewModel();
                    break;
                case "btnCat2":
                    CategoryPanelViewModel = new ClimateViewModel();
                    break;
                case "btnCat3":
                    CategoryPanelViewModel = new LightManagerViewModel();
                    break;
                case "btnCat4":
                    CategoryPanelViewModel = new ShadowManagerViewModel();
                    break;
                case "btnCat5":
                    CategoryPanelViewModel = new IrrigationManagerViewModel();
                    break;
            }
        }
    }
}
