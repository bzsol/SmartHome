using Common.Model;
using Prism.Commands;
using SmartHome.DataProvider;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using static Common.Model.ExternalFactors;

namespace SmartHome.ViewModels
{
    public class ClimateViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> SaveSettingsCommand { get; set; }

        public DelegateCommand<ToggleButton> EntryStateChange { get; set; }

        public DelegateCommand<ComboBox> OnSelected { get; set; }

        private ExternalFactors _actualExternalFactors;

        public List<string> CoolerOptions { get; private set; }

        public List<int> CoolerLevel { get; private set; }

        private bool _isCheckedEntryRoomHeating;
        public bool isCheckedEntryRoomHeating
        {
            get => _isCheckedEntryRoomHeating;
            set
            {
                _isCheckedEntryRoomHeating = value;
                NotifyChange(nameof(isCheckedEntryRoomHeating));
            }
        }

        private bool _isCheckedLivingRoomHeating;
        public bool isCheckedLivingRoomHeating
        {
            get => _isCheckedLivingRoomHeating;
            set
            {
                _isCheckedLivingRoomHeating = value;
                NotifyChange(nameof(isCheckedLivingRoomHeating));
            }


        }
        private bool _isCheckedKitchenRoomHeating;
        public bool isCheckedKitchenRoomHeating
        {
            get => _isCheckedKitchenRoomHeating;
            set
            {
                _isCheckedKitchenRoomHeating = value;
                NotifyChange(nameof(isCheckedKitchenRoomHeating));
            }


        }
        private bool _isCheckedOfficeRoomHeating;
        public bool isCheckedOfficeRoomHeating
        {
            get => _isCheckedOfficeRoomHeating;
            set
            {
                _isCheckedOfficeRoomHeating = value;
                NotifyChange(nameof(isCheckedOfficeRoomHeating));
            }


        }
        private bool _isCheckedDiningRoomHeating;
        public bool isCheckedDiningRoomHeating
        {
            get => _isCheckedDiningRoomHeating;
            set
            {
                _isCheckedDiningRoomHeating = value;
                NotifyChange(nameof(isCheckedDiningRoomHeating));
            }

        }

        private bool _isCheckedRoom1Heating;
        public bool isCheckedRoom1Heating
        {
            get => _isCheckedRoom1Heating;
            set
            {
                _isCheckedRoom1Heating = value;
                NotifyChange(nameof(isCheckedRoom1Heating));
            }

        }
        private bool _isCheckedRoom2Heating;
        public bool isCheckedRoom2Heating
        {
            get => _isCheckedRoom2Heating;
            set
            {
                _isCheckedRoom2Heating = value;
                NotifyChange(nameof(isCheckedRoom2Heating));
            }

        }
        private bool _isCheckedRoom3Heating;
        public bool isCheckedRoom3Heating
        {
            get => _isCheckedRoom3Heating;
            set
            {
                _isCheckedRoom3Heating = value;
                NotifyChange(nameof(isCheckedRoom3Heating));
            }

        }
        private bool _isCheckedBathRoomHeating;
        public bool isCheckedBathRoomHeating
        {
            get => _isCheckedBathRoomHeating;
            set
            {
                _isCheckedBathRoomHeating = value;
                NotifyChange(nameof(isCheckedBathRoomHeating));
            }


        }

        private bool _isHumidityCheckEnabled;
        public bool isHumidityCheckEnabled
        {
            get => _isHumidityCheckEnabled;
            set
            {
                _isHumidityCheckEnabled = value;
                NotifyChange(nameof(isHumidityCheckEnabled));
            }
        }
        private bool _isCO2Enabled;
        public bool isCO2Enabled
        {
            get => _isCO2Enabled;
            set
            {
                _isCO2Enabled = value;
                NotifyChange(nameof(isCO2Enabled));
            }
        }
        private bool _isVentilationChecked;
        public bool isVentilationChecked
        {
            get => _isVentilationChecked;
            set
            {
                _isVentilationChecked = value;
                NotifyChange(nameof(isVentilationChecked));
            }

        }
        private bool _isDehumuditification;
        public bool isDehumuditification
        {
            get => _isDehumuditification;
            set
            {
                _isDehumuditification = value;
                NotifyChange(nameof(isDehumuditification));
            }


        }

        private string _firstSelectedOption;
        public string FirstSelectedOption
        {
            get => _firstSelectedOption;
            set
            {
                _firstSelectedOption = value;
                NotifyChange(nameof(FirstSelectedOption));
            }
        }

        private int _firstSelectedLevel;
        public int FirstSelectedLevel
        {
            get => _firstSelectedLevel;
            set
            {
                _firstSelectedLevel = value;
                NotifyChange(nameof(FirstSelectedLevel));
            }
        }

        private string _secondSelectedOption;
        public string SecondSelectedOption
        {
            get => _secondSelectedOption;
            set
            {
                _secondSelectedOption = value;
                NotifyChange(nameof(SecondSelectedOption));
            }
        }

        private int _secondSelectedLevel;
        public int SecondSelectedLevel
        {
            get => _secondSelectedLevel;
            set
            {
                _secondSelectedLevel = value;
                NotifyChange(nameof(SecondSelectedLevel));
            }
        }

        private string _thirdSelectedOption;
        public string ThirdSelectedOption
        {
            get => _thirdSelectedOption;
            set
            {
                _thirdSelectedOption = value;
                NotifyChange(nameof(ThirdSelectedOption));
            }
        }

        private int _thirdSelectedLevel;
        public int ThirdSelectedLevel
        {
            get => _thirdSelectedLevel;
            set
            {
                _thirdSelectedLevel = value;
                NotifyChange(nameof(ThirdSelectedLevel));
            }
        }

        private string _fourthSelectedOption;
        public string FourthSelectedOption
        {
            get => _fourthSelectedOption;
            set
            {
                _fourthSelectedOption = value;
                NotifyChange(nameof(FourthSelectedOption));
            }
        }

        private int _fourthSelectedLevel;
        public int FourthSelectedLevel
        {
            get => _fourthSelectedLevel;
            set
            {
                _fourthSelectedLevel = value;
                NotifyChange(nameof(FourthSelectedLevel));
            }
        }

        private string _fifthSelectedOption;
        public string FifthSelectedOption
        {
            get => _fifthSelectedOption;
            set
            {
                _fifthSelectedOption = value;
                NotifyChange(nameof(FifthSelectedOption));
            }
        }

        private int _fifthSelectedLevel;
        public int FifthSelectedLevel
        {
            get => _fifthSelectedLevel;
            set
            {
                _fifthSelectedLevel = value;
                NotifyChange(nameof(FifthSelectedLevel));
            }
        }

        private bool _firstEntryCheckState;
        public bool FirstEntryCheckState
        {
            get => _firstEntryCheckState;
            set
            {
                _firstEntryCheckState = value;
                NotifyChange(nameof(FirstEntryCheckState));
            }
        }

        private Visibility _firstEntryVisibility;
        public Visibility FirstEntryVisibility
        {
            get => _firstEntryVisibility;
            set
            {
                _firstEntryVisibility = value;
                NotifyChange(nameof(FirstEntryVisibility));
            }
        }

        private bool _secondEntryCheckState;
        public bool SecondEntryCheckState
        {
            get => _secondEntryCheckState;
            set
            {
                _secondEntryCheckState = value;
                NotifyChange(nameof(SecondEntryCheckState));
            }
        }

        private Visibility _secondEntryVisibility;
        public Visibility SecondEntryVisibility
        {
            get => _secondEntryVisibility;
            set
            {
                _secondEntryVisibility = value;
                NotifyChange(nameof(SecondEntryVisibility));
            }
        }

        private bool _thirdEntryCheckState;
        public bool ThirdEntryCheckState
        {
            get => _thirdEntryCheckState;
            set
            {
                _thirdEntryCheckState = value;
                NotifyChange(nameof(ThirdEntryCheckState));
            }
        }

        private Visibility _thirdEntryVisibility;
        public Visibility ThirdEntryVisibility
        {
            get => _thirdEntryVisibility;
            set
            {
                _thirdEntryVisibility = value;
                NotifyChange(nameof(ThirdEntryVisibility));
            }
        }

        private bool _fourthEntryCheckState;
        public bool FourthEntryCheckState
        {
            get => _fourthEntryCheckState;
            set
            {
                _fourthEntryCheckState = value;
                NotifyChange(nameof(FourthEntryCheckState));
            }
        }

        private Visibility _fourthEntryVisibility;
        public Visibility FourthEntryVisibility
        {
            get => _fourthEntryVisibility;
            set
            {
                _fourthEntryVisibility = value;
                NotifyChange(nameof(FourthEntryVisibility));
            }
        }

        private bool _fifthEntryCheckState;
        public bool FifthEntryCheckState
        {
            get => _fifthEntryCheckState;
            set
            {
                _fifthEntryCheckState = value;
                NotifyChange(nameof(FifthEntryCheckState));
            }
        }

        private Visibility _fifthEntryVisibility;
        public Visibility FifthEntryVisibility
        {
            get => _fifthEntryVisibility;
            set
            {
                _fifthEntryVisibility = value;
                NotifyChange(nameof(FifthEntryVisibility));
            }
        }
        private int _tempSlider;
        public int TempSlider
        {
            get => _tempSlider;
            set
            {
                _tempSlider = value;
                NotifyChange(nameof(TempSlider));
            }

        }

        private int _climateSlider;
        public int ClimateSlider
        {
            get => _climateSlider;
            set
            {
                _climateSlider = value;
                NotifyChange(nameof(ClimateSlider));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ClimateViewModel()
        {
            SaveSettingsCommand = new DelegateCommand<Button>(OnSaveSettings);
            EntryStateChange = new DelegateCommand<ToggleButton>(OnEntryStateChange);
            CoolerOptions = new()
            {
                "NORMAL",
                "SWING",
                "TURBO",
                "SILENT",
                "SLEEP"
            };

            CoolerLevel = new()
            {
                1,
                2,
                3
            };

            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            InitializeView();
        }

        public void InitializeView()
        {
            TempSlider = _actualExternalFactors.Heating;
            isCheckedEntryRoomHeating = _actualExternalFactors.entryClimate.IsHeatingEnabled;
            isCheckedLivingRoomHeating = _actualExternalFactors.livingroomClimate.IsHeatingEnabled;
            isCheckedKitchenRoomHeating = _actualExternalFactors.kitchenClimate.IsHeatingEnabled;
            isCheckedOfficeRoomHeating = _actualExternalFactors.officeClimate.IsHeatingEnabled;
            isCheckedBathRoomHeating = _actualExternalFactors.bathClimate.IsHeatingEnabled;
            isCheckedDiningRoomHeating = _actualExternalFactors.diningClimate.IsHeatingEnabled;
            isCheckedRoom1Heating = _actualExternalFactors.roomno1Climate.IsHeatingEnabled;
            isCheckedRoom2Heating = _actualExternalFactors.roomno2Climate.IsHeatingEnabled;
            isCheckedRoom3Heating = _actualExternalFactors.roomno3Climate.IsHeatingEnabled;

            ClimateSlider = _actualExternalFactors.Cooling;
            FirstEntryCheckState = _actualExternalFactors.livingroomClimate.IsCoolingEnabled;
            SecondEntryCheckState = _actualExternalFactors.officeClimate.IsCoolingEnabled;
            ThirdEntryCheckState = _actualExternalFactors.roomno1Climate.IsCoolingEnabled;
            FourthEntryCheckState = _actualExternalFactors.roomno2Climate.IsCoolingEnabled;
            FifthEntryCheckState = _actualExternalFactors.roomno3Climate.IsCoolingEnabled;

            FirstEntryVisibility = FirstEntryCheckState ? Visibility.Visible : Visibility.Hidden;
            SecondEntryVisibility = SecondEntryCheckState ? Visibility.Visible : Visibility.Hidden;
            ThirdEntryVisibility = ThirdEntryCheckState ? Visibility.Visible : Visibility.Hidden;
            FourthEntryVisibility = FourthEntryCheckState ? Visibility.Visible : Visibility.Hidden;
            FifthEntryVisibility = FifthEntryCheckState ? Visibility.Visible : Visibility.Hidden;

            FirstSelectedLevel = _actualExternalFactors.livingroomClimate.Level == 0 ? 1 : _actualExternalFactors.livingroomClimate.Level;
            FirstSelectedOption = CoolerOptions[(int)_actualExternalFactors.livingroomClimate.Mode];

            SecondSelectedLevel = _actualExternalFactors.officeClimate.Level == 0 ? 1 : _actualExternalFactors.officeClimate.Level;
            SecondSelectedOption = CoolerOptions[(int)_actualExternalFactors.officeClimate.Mode];

            ThirdSelectedLevel = _actualExternalFactors.roomno1Climate.Level == 0 ? 1 : _actualExternalFactors.roomno1Climate.Level;
            ThirdSelectedOption = CoolerOptions[(int)_actualExternalFactors.roomno1Climate.Mode];

            FourthSelectedLevel = _actualExternalFactors.roomno2Climate.Level == 0 ? 1 : _actualExternalFactors.roomno2Climate.Level;
            FourthSelectedOption = CoolerOptions[(int)_actualExternalFactors.roomno2Climate.Mode];

            FifthSelectedLevel = _actualExternalFactors.roomno3Climate.Level == 0 ? 1 : _actualExternalFactors.roomno3Climate.Level;
            FifthSelectedOption = CoolerOptions[(int)_actualExternalFactors.roomno3Climate.Mode];


            isHumidityCheckEnabled = _actualExternalFactors.isHumiditysample;
            isCO2Enabled = _actualExternalFactors.isCO2sample;
            isDehumuditification = _actualExternalFactors.isDehumidification;
            isVentilationChecked = _actualExternalFactors.isVentilation;
        }

        public void OnSaveSettings(Button btn)
        {
            UploadData();
        }

        public void OnEntryStateChange(ToggleButton tbtn)
        {
            switch (tbtn.Name)
            {
                case "ClimateFirstEntry":
                    FirstEntryVisibility = FirstEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
                    break;
                case "ClimateSecondEntry":
                    SecondEntryVisibility = SecondEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
                    break;
                case "ClimateThirdEntry":
                    ThirdEntryVisibility = ThirdEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
                    break;
                case "ClimateFourthEntry":
                    FourthEntryVisibility = FourthEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
                    break;
                case "ClimateFifthEntry":
                    FifthEntryVisibility = FifthEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
                    break;
            }
        }

        private void UploadData()
        {
            if (IsHeatingSomewhereEnabled() && IsCoolingSomewhereEnabled())
            {
                MessageBox.Show("Nem lehet bekapcsolva a klíma és a fűtés egyszerre!");
            }
            else
            {
                _actualExternalFactors.entryClimate.IsHeatingEnabled = _isCheckedEntryRoomHeating;
                _actualExternalFactors.livingroomClimate.IsHeatingEnabled = _isCheckedLivingRoomHeating;
                _actualExternalFactors.kitchenClimate.IsHeatingEnabled = _isCheckedKitchenRoomHeating;
                _actualExternalFactors.officeClimate.IsHeatingEnabled = _isCheckedOfficeRoomHeating;
                _actualExternalFactors.bathClimate.IsHeatingEnabled = _isCheckedBathRoomHeating;
                _actualExternalFactors.diningClimate.IsHeatingEnabled = _isCheckedDiningRoomHeating;
                _actualExternalFactors.roomno1Climate.IsHeatingEnabled = _isCheckedRoom1Heating;
                _actualExternalFactors.roomno2Climate.IsHeatingEnabled = _isCheckedRoom2Heating;
                _actualExternalFactors.roomno3Climate.IsHeatingEnabled = _isCheckedRoom3Heating;

                _actualExternalFactors.isCO2sample = _isCO2Enabled;
                _actualExternalFactors.isDehumidification = _isDehumuditification;
                _actualExternalFactors.isHumiditysample = _isHumidityCheckEnabled;
                _actualExternalFactors.isVentilation = _isVentilationChecked;
                _actualExternalFactors.Cooling = ClimateSlider == 0 ? 18 : ClimateSlider;
                _actualExternalFactors.Heating = TempSlider == 0 ? 16 : TempSlider;

                _actualExternalFactors.livingroomClimate.IsCoolingEnabled = FirstEntryCheckState;
                _actualExternalFactors.livingroomClimate.Level = FirstSelectedLevel;
                _actualExternalFactors.livingroomClimate.Mode = StringToMode(_firstSelectedOption);

                _actualExternalFactors.officeClimate.IsCoolingEnabled = SecondEntryCheckState;
                _actualExternalFactors.officeClimate.Level = SecondSelectedLevel;
                _actualExternalFactors.officeClimate.Mode = StringToMode(_secondSelectedOption);

                _actualExternalFactors.roomno1Climate.IsCoolingEnabled = ThirdEntryCheckState;
                _actualExternalFactors.roomno1Climate.Level = ThirdSelectedLevel;
                _actualExternalFactors.roomno1Climate.Mode = StringToMode(_thirdSelectedOption);

                _actualExternalFactors.roomno2Climate.IsCoolingEnabled = FourthEntryCheckState;
                _actualExternalFactors.roomno2Climate.Level = FourthSelectedLevel;
                _actualExternalFactors.roomno2Climate.Mode = StringToMode(_fourthSelectedOption);

                _actualExternalFactors.roomno3Climate.IsCoolingEnabled = FifthEntryCheckState;
                _actualExternalFactors.roomno3Climate.Level = FifthSelectedLevel;
                _actualExternalFactors.roomno3Climate.Mode = StringToMode(_fifthSelectedOption);

                ExtFactDataProvider.Update(_actualExternalFactors);
                MessageBox.Show("Beállítások mentve");
            }
        }

        public bool IsHeatingSomewhereEnabled()
        {
            return isCheckedEntryRoomHeating || isCheckedLivingRoomHeating || isCheckedKitchenRoomHeating || isCheckedOfficeRoomHeating || isCheckedBathRoomHeating
                || isCheckedDiningRoomHeating || isCheckedRoom1Heating || isCheckedRoom2Heating || isCheckedRoom3Heating;
        }

        public bool IsCoolingSomewhereEnabled()
        {
            return FirstEntryCheckState || SecondEntryCheckState || ThirdEntryCheckState || FourthEntryCheckState || FifthEntryCheckState;
        }

        private Modes StringToMode(string option)
        {
            switch (option)
            {
                case "NORMAL": return Modes.NORMAL;
                case "SWING": return Modes.SWING;
                case "TURBO": return Modes.TURBO;
                case "SILENT": return Modes.SILENT;
                default: return Modes.SLEEP;
            }
        }
    }
}
