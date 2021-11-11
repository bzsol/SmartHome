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
    public class ShadowManagerViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> SaveSettingsCommand { get; set; }

        public DelegateCommand<RadioButton> PreferenceChangedCommand { get; set; }

        public List<string> Places { get; set; }

        private string _selectedPlace;
        public string SelectedPlace
        {
            get => _selectedPlace;
            set
            {
                _selectedPlace = value;
                NotifyChange(nameof(SelectedPlace));
            }
        }

        private bool _timePreferenceCheckState;
        public bool TimePreferenceCheckState
        {
            get => _timePreferenceCheckState;
            set
            {
                _timePreferenceCheckState = value;
                NotifyChange(nameof(TimePreferenceCheckState));
            }
        }

        private bool _lightPreferenceCheckState;
        public bool LightPreferenceCheckState
        {
            get => _lightPreferenceCheckState;
            set
            {
                _lightPreferenceCheckState = value;
                NotifyChange(nameof(LightPreferenceCheckState));
            }
        }

        private Visibility _timeSettingVisibility;
        public Visibility TimeSettingVisibility
        {
            get => _timeSettingVisibility;
            set
            {
                _timeSettingVisibility = value;
                NotifyChange(nameof(TimeSettingVisibility));
            }
        }

        private Visibility _lightSettingVisibility;
        public Visibility LightSettingVisibility
        {
            get => _lightSettingVisibility;
            set
            {
                _lightSettingVisibility = value;
                NotifyChange(nameof(LightSettingVisibility));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ShadowManagerViewModel()
        {
            SaveSettingsCommand = new DelegateCommand<Button>(OnSaveSettings);
            PreferenceChangedCommand = new DelegateCommand<RadioButton>(OnPreferenceChanged);
                
            Places = new()
            {
                "Nappali",
                "Konyha",
                "Iroda",
                "Terasz",
                "Szoba #1",
                "Szoba #2",
                "Szoba #3"
            };

            SelectedPlace = Places[0];
            LightPreferenceCheckState = true;
            LightSettingVisibility = Visibility.Visible;
            TimeSettingVisibility = Visibility.Hidden;
        }
    
        private void OnSaveSettings(Button btn)
        {
            MessageBox.Show($"{SelectedPlace}");
        }

        private void OnPreferenceChanged(RadioButton rbtn)
        {
            if (TimePreferenceCheckState)
            {
                TimeSettingVisibility = Visibility.Visible;
                LightSettingVisibility = Visibility.Hidden;
            } 
            else
            {
                TimeSettingVisibility = Visibility.Hidden;
                LightSettingVisibility = Visibility.Visible;
            }
        }
    }
}
