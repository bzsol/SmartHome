using Common.Model;
using Prism.Commands;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Common.Model.ExternalFactors;

namespace SmartHome.ViewModels
{
    public class ShadowManagerViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> SaveSettingsCommand { get; set; }

        public DelegateCommand<RadioButton> PreferenceChangedCommand { get; set; }

        private ExternalFactors _actualExternalFactors;

        public List<string> Places { get; set; }

        public Dictionary<string, string> AllWindowsToPlace { get; set; }

        private GridLength _firstGridRowHeight;
        public GridLength FirstGridRowHeight
        {
            get => _firstGridRowHeight;
            set
            {
                _firstGridRowHeight = value;
                NotifyChange(nameof(FirstGridRowHeight));
            }
        }

        private GridLength _secondGridRowHeight;
        public GridLength SecondGridRowHeight
        {
            get => _secondGridRowHeight;
            set
            {
                _secondGridRowHeight = value;
                NotifyChange(nameof(SecondGridRowHeight));
            }
        }

        private string _selectedPlace;
        public string SelectedPlace
        {
            get => _selectedPlace;
            set
            {
                _selectedPlace = value;
                NotifyChange(nameof(SelectedPlace));
                GetAvailableWindows();
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
                GetActualWindowData(SelectedWindow);
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

        private bool _nonePreferenceCheckState;
        public bool NonePreferenceCheckState
        {
            get => _nonePreferenceCheckState;
            set
            {
                _nonePreferenceCheckState = value;
                NotifyChange(nameof(NonePreferenceCheckState));
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

        private int _levelslider;
        public int LevelSlider
        {
            get => _levelslider;
            set
            {
                _levelslider = value;
                NotifyChange(nameof(LevelSlider));
            }
        }

        private string _selectedtime;
        public string SelectedTime
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

            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            InitializeView();
        }

        public void InitializeView()
        {
            SelectedPlace = Places[0];
        }

        public void GetActualWindowData(string Selected)
        {
            Shading selectedShading;

            switch (Selected)
            {
                case "Konyha":
                    selectedShading = _actualExternalFactors.kitchenShading;
                    break;
                case "Iroda":
                    selectedShading = _actualExternalFactors.officeShading;
                    break;
                case "Étkező":
                    selectedShading = _actualExternalFactors.diningShading;
                    break;
                case "Szoba #1":
                    selectedShading = _actualExternalFactors.roomno1Shading;
                    break;
                case "Szoba #2":
                    selectedShading = _actualExternalFactors.roomno2Shading;
                    break;
                case "Szoba #3":
                    selectedShading = _actualExternalFactors.roomno3Shading;
                    break;
                case "Baloldali ablak":
                    selectedShading = _actualExternalFactors.bathLeftWindowShading;
                    break;
                case "Jobboldali ablak":
                    selectedShading = _actualExternalFactors.bathRightWindowShading;
                    break;
                case "Panoráma ablak":
                    selectedShading = _actualExternalFactors.livingroomPanoramaShading;
                    break;
                default:
                    selectedShading = _actualExternalFactors.livingroomShading;
                    break;
            }

            TimePreferenceCheckState = selectedShading.ShadePreference == ShadePreference.TIME;
            LightPreferenceCheckState = selectedShading.ShadePreference == ShadePreference.PHOTOSENSITIVTY;
            NonePreferenceCheckState = selectedShading.ShadePreference == ShadePreference.NONE;
            LevelSlider = selectedShading.Level;
            SelectedTime = selectedShading.Date == null ? string.Empty : selectedShading.Date;
            LightStrength = selectedShading.Photosensitivity;
            SetViewBasedOnPreference();
        }

        private void DataUpload()
        {
            if (TimePreferenceCheckState && !IsValidTime())
            {
                MessageBox.Show("Az időpontnak 0:00-23:59 közé kell esnie!");
            }
            else
            {
                Shading shading = new Shading();

                shading.Level = LevelSlider;
                shading.ShadePreference = TimePreferenceCheckState ? ShadePreference.TIME : LightPreferenceCheckState ? ShadePreference.PHOTOSENSITIVTY : ShadePreference.NONE;
                if (_lightPreferenceCheckState)
                {
                    shading.Photosensitivity = _lightstrength;
                }
                else if (_timePreferenceCheckState)
                {
                    shading.Date = _selectedtime;
                }

                switch (SelectedPlace)
                {
                    case "Nappali":
                        if (SelectedWindow.Equals("Panoráma ablak"))
                        {
                            _actualExternalFactors.livingroomPanoramaShading = shading;
                        }
                        else if (SelectedWindow.Equals("Nagy ablak"))
                        {
                            _actualExternalFactors.livingroomShading = shading;
                        }
                        break;
                    case "Fürdőszoba":
                        if (SelectedWindow.Equals("Baloldali ablak"))
                        {
                            _actualExternalFactors.bathLeftWindowShading = shading;
                        }
                        else if (SelectedWindow.Equals("Jobboldali ablak"))
                        {
                            _actualExternalFactors.bathRightWindowShading = shading;
                        }
                        break;

                    case "Konyha":
                        _actualExternalFactors.kitchenShading = shading;
                        break;
                    case "Iroda":
                        _actualExternalFactors.officeShading = shading;
                        break;
                    case "Szoba #1":
                        _actualExternalFactors.roomno1Shading = shading;
                        break;
                    case "Szoba #2":
                        _actualExternalFactors.roomno2Shading = shading;
                        break;
                    case "Szoba #3":
                        _actualExternalFactors.roomno3Shading = shading;
                        break;
                    case "Étkező":
                        _actualExternalFactors.diningShading = shading;
                        break;
                }

                ExtFactDataProvider.Update(_actualExternalFactors);
            }
        }

        private bool IsValidTime()
        {
            return Regex.IsMatch(SelectedTime == null ? string.Empty : SelectedTime, "([0-9]|[1][0-9]|[2][0-3]):[0-5][0-9]");
        }

        private void OnSaveSettings(Button btn)
        {
            DataUpload();
        }

        private void OnPreferenceChanged(RadioButton rbtn)
        {
            SetViewBasedOnPreference();
        }

        private void SetViewBasedOnPreference()
        {
            if (TimePreferenceCheckState)
            {
                TimeSettingVisibility = Visibility.Visible;
                LightSettingVisibility = Visibility.Hidden;
                FirstGridRowHeight = new GridLength(1, GridUnitType.Star);
                SecondGridRowHeight = new GridLength(1, GridUnitType.Star);
            }
            else if (LightPreferenceCheckState)
            {
                TimeSettingVisibility = Visibility.Hidden;
                LightSettingVisibility = Visibility.Visible;
                FirstGridRowHeight = new GridLength(1, GridUnitType.Star);
                SecondGridRowHeight = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                TimeSettingVisibility = Visibility.Hidden;
                LightSettingVisibility = Visibility.Hidden;
                FirstGridRowHeight = new GridLength(0, GridUnitType.Star);
                SecondGridRowHeight = new GridLength(0, GridUnitType.Star);
            }
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
                GetActualWindowData(SelectedPlace);
            }
        }
    }
}
