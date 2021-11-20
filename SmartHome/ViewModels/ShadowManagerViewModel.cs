using Common.Model;
using Prism.Commands;
using SmartHome.DataProvider;
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

        public DelegateCommand<ComboBox> WindowSelectionChangeCommand { get; set; }

        public List<string> Places { get; set; }

        public Dictionary<string, string> AllWindowsToPlace { get; set; }

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

        private string _selectedWindow;
        public string SelectedWindow
        {
            get => _selectedWindow;
            set
            {
                _selectedWindow = value;
                NotifyChange(nameof(SelectedWindow));
            }
        }

        private List<string> _windowsInPlace;
        public List<string> WindowsInPlace
        {
            get => _windowsInPlace;
            set
            {
                _windowsInPlace = value;
                NotifyChange(nameof(WindowsInPlace));
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

        private Visibility _noMultipleWindowsVisibility;
        public Visibility NoMultipleWindowsVisibility
        {
            get => _noMultipleWindowsVisibility;
            set
            {
                _noMultipleWindowsVisibility = value;
                NotifyChange(nameof(NoMultipleWindowsVisibility));
            }
        }

        private Visibility _multipleWindowsVisibility;
        public Visibility MultipleWindowsVisibility
        {
            get => _multipleWindowsVisibility;
            set
            {
                _multipleWindowsVisibility = value;
                NotifyChange(nameof(MultipleWindowsVisibility));
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

        private int _lightstrength;
        public int LightStrength
        {
            get => _lightstrength;
            set
            {
                _lightstrength = value;
                NotifyChange(nameof(LightStrength));
            }
        }

        private int _levelslinder;
        public int LevelSlinder
        {
            get => _levelslinder;
            set
            {
                _levelslinder = value;
                NotifyChange(nameof(LevelSlinder));
            }
        }

        private DateTime _selectedtime;
        public DateTime SelectedTime
        {
            get => _selectedtime;
            set
            {
                _selectedtime = value;
                NotifyChange(nameof(SelectedTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ShadowManagerViewModel()
        {
            SaveSettingsCommand = new DelegateCommand<Button>(OnSaveSettings);
            PreferenceChangedCommand = new DelegateCommand<RadioButton>(OnPreferenceChanged);
            WindowSelectionChangeCommand = new DelegateCommand<ComboBox>(OnPlaceSelectionChanged);
                
            Places = new()
            {
                "Nappali",
                "Konyha",
                "Fürdőszoba",
                "Iroda",
                "Étkező",
                "Szoba #1",
                "Szoba #2",
                "Szoba #3"
            };

            AllWindowsToPlace = new()
            {
                { "Fürdőszoba", "Baloldali ablak;Jobboldali ablak" },
                { "Nappali", "Panoráma ablak;Nagy ablak" },
            };

            SelectedPlace = Places[0];
            GetAvailableWindows();

            LightPreferenceCheckState = true;
            LightSettingVisibility = Visibility.Visible;
            TimeSettingVisibility = Visibility.Hidden;
        }
        
        private void DataUpload()
        {
            ExternalFactors external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
            Shading shading = new Shading();
            shading.level = _levelslinder;
            if(_lightPreferenceCheckState)
            {
                shading.photosensitivity = _lightstrength;
            }
            else if (_timePreferenceCheckState)
            {
                shading.date = _selectedtime;
            }
            switch(SelectedPlace)
            {
                case "Nappali":
                    {
                        if(SelectedWindow.Equals("Panoráma ablak"))
                        {
                            external.livingroomPanorama = shading;
                        }
                        else if (SelectedWindow.Equals("Nagy ablak"))
                        {
                            external.livingroomShading = shading;
                        }
                        break;
                    }
                case "Fürdőszoba":
                    {
                        if(SelectedWindow.Equals("Baloldali ablak"))
                        {
                            external.bathleftWindow = shading;
                        }
                        else if(SelectedWindow.Equals("Jobboldali ablak"))
                        {
                            external.bathShading = shading;
                        }
                        break;

                    }
                case "Konyha":
                    {
                        external.kitchenShading = shading;
                        break;
                    }
                case "Iroda":
                    {
                        external.officeShading = shading;
                        break;
                    }
                case "Szoba #1":
                    {
                        external.roomno1Shading = shading;
                        break;
                    }
                case "Szoba #2":
                    {
                        external.roomno2Shading = shading;
                        break;
                    }
                case "Szoba #3":
                    {
                        external.roomno3Shading = shading;
                        break;
                    }
                case "Étkező":
                    {
                        external.terraceShading = shading;
                        break;
                    }
            }
            ExtFactDataProvider.Update(external);
        }
        private void OnSaveSettings(Button btn)
        {
            MessageBox.Show($"{_lightstrength} / {_selectedtime} / {_selectedPlace} / {_selectedWindow}");
            DataUpload();
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

        private void OnPlaceSelectionChanged(ComboBox cbox)
        {
            GetAvailableWindows();
        }

        private void GetAvailableWindows()
        {
            if (AllWindowsToPlace.ContainsKey(SelectedPlace))
            {
                MultipleWindowsVisibility = Visibility.Visible;
                NoMultipleWindowsVisibility = Visibility.Hidden;

                WindowsInPlace = AllWindowsToPlace[SelectedPlace].Split(";").ToList();
                SelectedWindow = WindowsInPlace[0];
            }
            else
            {
                MultipleWindowsVisibility = Visibility.Hidden;
                NoMultipleWindowsVisibility = Visibility.Visible;
            }
        }
    }
}
