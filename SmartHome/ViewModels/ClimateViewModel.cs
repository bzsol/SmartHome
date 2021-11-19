using Common.Model;
using Prism.Commands;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<string> CoolerOptions { get; private set; }

        public List<int> CoolerLevel { get; private set; }

        private bool _isCheckedEntryRoomHeating;
        public bool isCheckedEntryRoomHeating {
            get => _isCheckedEntryRoomHeating;
            set {
                _isCheckedEntryRoomHeating = value;
                NotifyChange(nameof(isCheckedEntryRoomHeating));
            }
        }

        private bool _isCheckedLivingRoomHeating;
        public bool isCheckedLivingRoomHeating {
            get => _isCheckedLivingRoomHeating;
            set {
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
        private bool _isCheckedTerraceRoomHeating;
        public bool isCheckedTerraceRoomHeating
        {
            get => _isCheckedTerraceRoomHeating;
            set
            {
                _isCheckedTerraceRoomHeating = value;
                NotifyChange(nameof(isCheckedTerraceRoomHeating));
            }

        }

        private bool _isCheckedRoom1Heating;
        public bool isCheckedRoom1Heating {
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
        public bool isCheckedBathRoomHeating {
            get => _isCheckedBathRoomHeating;
            set {
                _isCheckedBathRoomHeating = value;
                NotifyChange(nameof(isCheckedBathRoomHeating));
            }


        }

        private bool _isHumidityCheckEnabled;
        public bool isHumidityCheckEnabled {
            get => _isHumidityCheckEnabled;
            set {
                _isHumidityCheckEnabled = value;
                NotifyChange(nameof(isHumidityCheckEnabled));
            }
        }
        private bool _isCO2Enabled;
        public bool isCO2Enabled {
            get => _isCO2Enabled;
            set {
                _isCO2Enabled = value;
                NotifyChange(nameof(isCO2Enabled));
            }
        }
        private bool _isVentilationChecked;
        public bool isVentilationChecked {
            get => _isVentilationChecked;
            set {
                _isVentilationChecked = value;
                NotifyChange(nameof(isVentilationChecked));
            }

        }
        private bool _isDehumuditification;
        public bool isDehumuditification {
            get => _isDehumuditification;
            set {
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

        private string _firstSelectedLevel;
        public string FirstSelectedLevel
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

        private string _secondSelectedLevel;
        public string SecondSelectedLevel
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

        private string _thirdSelectedLevel;
        public string ThirdSelectedLevel
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

        private string _fourthSelectedLevel;
        public string FourthSelectedLevel
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

        private string _fifthSelectedLevel;
        public string FifthSelectedLevel
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

            FirstEntryVisibility = FirstEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
            SecondEntryVisibility = SecondEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
            ThirdEntryVisibility = ThirdEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
            FourthEntryVisibility = FourthEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
            FifthEntryVisibility = FifthEntryCheckState ? Visibility.Visible : Visibility.Collapsed;
        }

        public void OnSaveSettings(Button btn)
        {
            MessageBox.Show($"{_firstSelectedOption} : {_firstSelectedLevel}\n" +
                $"{_secondSelectedOption} : {_secondSelectedLevel}\n" +
                $"{ _thirdSelectedOption} : { _thirdSelectedLevel}\n" +
                $"{ _fourthSelectedOption} : { _fourthSelectedLevel}\n" +
                $"{ _fifthSelectedOption} : { _fifthSelectedLevel}");
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


        private void UploadData() {

            var external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
            external.entryClimate.isHeatingEnabled = _isCheckedEntryRoomHeating;
            external.livingroomClimate.isHeatingEnabled = _isCheckedLivingRoomHeating;
            external.kitchenClimate.isHeatingEnabled = _isCheckedKitchenRoomHeating;
            external.officeClimate.isHeatingEnabled = _isCheckedOfficeRoomHeating;
            external.bathClimate.isHeatingEnabled = _isCheckedBathRoomHeating;
            external.terraceClimate.isHeatingEnabled = _isCheckedTerraceRoomHeating;
            external.roomno1Climate.isHeatingEnabled = _isCheckedRoom1Heating;
            external.roomno2Climate.isHeatingEnabled = _isCheckedRoom2Heating;
            external.roomno3Climate.isHeatingEnabled = _isCheckedRoom3Heating;

            external.isCO2sample = _isCO2Enabled;
            external.isDehumidification = _isDehumuditification;
            external.isHumiditysample = _isHumidityCheckEnabled;
            external.isVentilation = _isVentilationChecked;


            if (FirstEntryVisibility.Equals(Visibility.Visible) && !_isCheckedLivingRoomHeating) {
                external.livingroomClimate.level = int.Parse(_firstSelectedLevel);
                external.livingroomClimate.mode = StringToMode(_firstSelectedOption);
            }
            if (SecondEntryVisibility.Equals(Visibility.Visible) && !_isCheckedOfficeRoomHeating) {
                external.officeClimate.level = int.Parse(_secondSelectedLevel);
                external.officeClimate.mode = StringToMode(_secondSelectedOption);
            }
            if (ThirdEntryVisibility.Equals(Visibility.Visible) && !_isCheckedRoom1Heating) {
                external.roomno1Climate.level = int.Parse(_thirdSelectedLevel);
                external.roomno1Climate.mode = StringToMode(_thirdSelectedOption);
            }
            if (FourthEntryVisibility.Equals(Visibility.Visible) && !_isCheckedRoom2Heating) {
                external.roomno2Climate.level = int.Parse(_fourthSelectedLevel);
                external.roomno2Climate.mode = StringToMode(_fourthSelectedOption);
            }
            if (FifthEntryVisibility.Equals(Visibility.Visible) && !_isCheckedRoom3Heating) {
                external.roomno3Climate.level = int.Parse(_fifthSelectedLevel);
                external.roomno3Climate.mode = StringToMode(_fifthSelectedOption);
            }
            
            ExtFactDataProvider.Update(external);
        }

        private Modes StringToMode(string option) {
            switch (option) 
            {
                case "1": return Modes.sleep;
                case "2": return Modes.silent;
                case "3": return Modes.turbo;
                case "0": return Modes.swing;
                default: return Modes.silent;
            }
        }
    }
}
