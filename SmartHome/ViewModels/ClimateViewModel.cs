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
                UploadData(_firstSelectedOption, _firstSelectedLevel,_secondSelectedOption,_secondSelectedLevel,_thirdSelectedOption,_thirdSelectedLevel,_fourthSelectedOption,_fourthSelectedLevel,_fifthSelectedOption,_fifthSelectedLevel);
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


        private void UploadData(string firsSelectedOption,string firstSelectedLevel,string secondSelectedOption,string secondSelectedLevel, string thirdSelectedOption, string thirdSelectedLevel, string fourthSelectedOption, string fourthSelectedLevel, string fifthSelectedOption, string fifthSelectedLevel) {

            var external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
            external.livingroomLevel = int.Parse(firstSelectedLevel);
            external.livingroomModes = StringToMode(firsSelectedOption);
            external.officeLevel = int.Parse(secondSelectedLevel);
            external.officeModes = StringToMode(secondSelectedOption);
            external.roomno1Level = int.Parse(thirdSelectedLevel);
            external.roomno1Modes = StringToMode(thirdSelectedOption);
            external.roomno2Level = int.Parse(fourthSelectedLevel);
            external.roomno2Modes = StringToMode(fourthSelectedOption);
            external.roomno3Level = int.Parse(fifthSelectedLevel);
            external.roomno3Modes = StringToMode(fifthSelectedOption);
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
