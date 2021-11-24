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
using System.Windows.Controls.Primitives;

namespace SmartHome.ViewModels
{
    public class LightManagerViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Button> SaveSettingsCommand { get; set; }
        public DelegateCommand<Button> UpMinuteCounterCommand { get; set; }
        public DelegateCommand<Button> DownMinuteCounterCommand { get; set; }
        public DelegateCommand<RadioButton> LocationChanged { get; set; }
        public DelegateCommand<ToggleButton> MotionStateChanged { get; set; }

        private ExternalFactors _actualExternalFactors;

        public List<string> InsidePlaces { get; set; }
        public List<string> OutsidePlaces { get; set; }

        private List<string> _places;
        public List<string> Places
        {
            get => _places;
            set
            {
                _places = value;
                NotifyChange(nameof(Places));
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
                GetActualLightData(SelectedPlace);
            }
        }

        private bool _insideCheckState;
        public bool InsideCheckState
        {
            get => _insideCheckState;
            set
            {
                _insideCheckState = value;
                NotifyChange(nameof(InsideCheckState));
            }
        }

        private bool _outsideCheckState;
        public bool OutsideCheckState
        {
            get => _outsideCheckState;
            set
            {
                _outsideCheckState = value;
                NotifyChange(nameof(OutsideCheckState));
            }
        }

        private Visibility _motionEnabledVisibility;
        public Visibility MotionEnabledVisibility
        {
            get => _motionEnabledVisibility;
            set
            {
                _motionEnabledVisibility = value;
                NotifyChange(nameof(MotionEnabledVisibility));
            }
        }

        private bool _isMotionDetectionEnabled;
        public bool IsMotionDetectionEnabled
        {
            get => _isMotionDetectionEnabled;
            set
            {
                _isMotionDetectionEnabled = value;
                NotifyChange(nameof(IsMotionDetectionEnabled));
            }
        }

        private string _motionTimeTextBox;
        public string MotionTimeTextBox
        {
            get => _motionTimeTextBox;
            set
            {
                _motionTimeTextBox = value;
                NotifyChange(nameof(MotionTimeTextBox));
            }
        }

        private int _lightStrenght;
        public int SliderValue
        {

            get => _lightStrenght;
            set
            {
                _lightStrenght = value;
                NotifyChange(nameof(SliderValue));
            }

        }
        private bool _isColorcold;
        public bool isColorCold
        {
            get => _isColorcold;
            set
            {
                _isColorcold = value;
                NotifyChange(nameof(isColorCold));
            }
        }
        private bool _isColorwarm;
        public bool isColorWarm
        {
            get => _isColorwarm;
            set
            {
                _isColorwarm = value;
                NotifyChange(nameof(isColorWarm));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public LightManagerViewModel()
        {
            SaveSettingsCommand = new DelegateCommand<Button>(OnSaveSettings);
            UpMinuteCounterCommand = new DelegateCommand<Button>(OnUpMinuteClicked);
            DownMinuteCounterCommand = new DelegateCommand<Button>(OnDownMinuteClicked);
            LocationChanged = new DelegateCommand<RadioButton>(OnLocationChanged);
            MotionStateChanged = new DelegateCommand<ToggleButton>(OnMotionStateChanged);

            InsidePlaces = new()
            {
                "Előszoba",
                "Nappali",
                "Konyha",
                "Fürdőszoba",
                "Iroda",
                "Étkező",
                "Szoba #1",
                "Szoba #2",
                "Szoba #3"
            };

            OutsidePlaces = new()
            {
                "Kapubejáró",
                "Garázs",
                "Kert"
            };

            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            InitializeView();
        }

        private void InitializeView()
        {
            InsideCheckState = true;
            Places = InsidePlaces;
            SelectedPlace = InsidePlaces[0];

            GetActualLightData(SelectedPlace);
        }


        private void GetActualLightData(string Selected)
        {
            Lights selectedLight;

            switch (Selected)
            {
                case "Előszoba":
                    selectedLight = _actualExternalFactors.entryLights;
                    break;
                case "Nappali":
                    selectedLight = _actualExternalFactors.livingroomLights;
                    break;
                case "Konyha":
                    selectedLight = _actualExternalFactors.kitchenLights;
                    break;
                case "Fürdőszoba":
                    selectedLight = _actualExternalFactors.bathLights;
                    break;
                case "Iroda":
                    selectedLight = _actualExternalFactors.officeLights;
                    break;
                case "Étkező":
                    selectedLight = _actualExternalFactors.diningLights;
                    break;
                case "Szoba #1":
                    selectedLight = _actualExternalFactors.roomno1Lights;
                    break;
                case "Szoba #2":
                    selectedLight = _actualExternalFactors.roomno2Lights;
                    break;
                case "Szoba #3":
                    selectedLight = _actualExternalFactors.roomno3Lights;
                    break;
                case "Kapubejáró":
                    selectedLight = _actualExternalFactors.gateEntranceLights;
                    break;
                case "Garázs":
                    selectedLight = _actualExternalFactors.garageLights;
                    break;
                default:
                    selectedLight = _actualExternalFactors.gardenLights;
                    break;
            }

            MotionEnabledVisibility = selectedLight.motionDetection ? Visibility.Visible : Visibility.Hidden;
            IsMotionDetectionEnabled = selectedLight.motionDetection ? true : false;
            MotionTimeTextBox = selectedLight.motionDetection ? selectedLight.activeSpan.ToString() : string.Empty;
            SliderValue = selectedLight.strenght;
            isColorWarm = selectedLight.color == 0 ? true : false;
            isColorCold = !isColorWarm;
        }


        private void ChangeTextValue(string text, bool increase)
        {
            bool value = int.TryParse(text, out int number);

            if (value && increase && number < 10)
            {
                MotionTimeTextBox = "" + (number + 1);
            }
            else if (value && !increase && number > 1)
            {
                MotionTimeTextBox = "" + (number - 1);
            }
            else if (!value && increase)
            {
                MotionTimeTextBox = "10";
            }
            else if (!value && !increase)
            {
                MotionTimeTextBox = "1";
            }
        }

        private void DataUpload(int motionTimeSpan)
        {
            ExternalFactors external = ((List<ExternalFactors>)ExtFactDataProvider.Get()).FirstOrDefault(x => x.ID == 1);
            Lights lights = new Lights();
            lights.motionDetection = _isMotionDetectionEnabled;
            lights.strenght = _lightStrenght;
            lights.color = isColorCold ? ExternalFactors.LightColor.cold : ExternalFactors.LightColor.warm;
            lights.activeSpan = motionTimeSpan;

            if (_insideCheckState)
            {
                switch (SelectedPlace)
                {
                    case "Előszoba":
                        {
                            external.entryLights = lights;
                            break;
                        }
                    case "Nappali":
                        {
                            external.livingroomLights = lights;
                            break;
                        }
                    case "Konyha":
                        {
                            external.kitchenLights = lights;
                            break;
                        }
                    case "Fürdőszoba":
                        {
                            external.bathLights = lights;
                            break;
                        }
                    case "Iroda":
                        {
                            external.officeLights = lights;
                            break;
                        }
                    case "Étkező":
                        {
                            external.diningLights = lights;
                            break;
                        }
                    case "Szoba #1":
                        {
                            external.roomno1Lights = lights;
                            break;
                        }
                    case "Szoba #2":
                        {
                            external.roomno2Lights = lights;
                            break;
                        }
                    case "Szoba #3":
                        {
                            external.roomno3Lights = lights;
                            break;
                        }
                }
            }
            else if (_outsideCheckState)
            {
                switch (SelectedPlace)
                {
                    case "Kapubejáró":
                        {
                            external.gateEntranceLights = lights;
                            break;
                        }
                    case "Garázs":
                        {
                            external.garageLights = lights;
                            break;
                        }
                    case "Kert":
                        {
                            external.gardenLights = lights;
                            break;
                        }
                }

            }

            ExtFactDataProvider.Update(external);
            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
        }


        private void OnDownMinuteClicked(Button btn)
        {
            ChangeTextValue(MotionTimeTextBox, false);
        }

        private void OnUpMinuteClicked(Button btn)
        {
            ChangeTextValue(MotionTimeTextBox, true);
        }

        private void OnSaveSettings(Button btn)
        {
            int motionTimeSpan = 0;

            if (IsMotionDetectionEnabled)
            {
                if (!(int.TryParse(MotionTimeTextBox, out int value) && value <= 10 && value >= 1))
                {
                    MessageBox.Show("A mozgásérzékelésnél megadott időtartamnak 1 és 10 perc közé kell esnie!");
                }
                else
                {
                    motionTimeSpan = value;
                }
            }

            DataUpload(motionTimeSpan);
        }

        private void OnLocationChanged(RadioButton rbtn)
        {
            if (rbtn.Name.Equals("InsideRadioButton"))
            {
                Places = InsidePlaces;
                SelectedPlace = Places[0];
            }
            else
            {
                Places = OutsidePlaces;
                SelectedPlace = Places[0];
            }
        }

        private void OnMotionStateChanged(ToggleButton tbtn)
        {
            if (IsMotionDetectionEnabled)
            {
                MotionEnabledVisibility = Visibility.Visible;
            }
            else
            {

                MotionEnabledVisibility = Visibility.Hidden;
            }
        }
    }
}
