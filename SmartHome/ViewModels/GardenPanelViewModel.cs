using Common.Class;
using Common.Model;
using Common.Tool;
using Prism.Commands;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using static Common.Model.ExternalFactors;

namespace SmartHome.ViewModels
{
    public class GardenPanelViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Ellipse> CheckMotionCommand { get; set; }
        public DelegateCommand<Rectangle> LightClickedCommand { get; set; }

        private ExternalFactors _actualExternalFactors;

        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private List<Lights> _lightsOutside;

        private List<Irrigative> _irrigatives;

        private Brush _leftGardenLightColor;
        public Brush LeftGardenLightColor
        {
            get => _leftGardenLightColor;
            set
            {
                _leftGardenLightColor = value;
                NotifyChange(nameof(LeftGardenLightColor));
            }
        }

        private Brush _rightGardenLightColor;
        public Brush RightGardenLightColor
        {
            get => _rightGardenLightColor;
            set
            {
                _rightGardenLightColor = value;
                NotifyChange(nameof(RightGardenLightColor));
            }
        }

        private Brush _leftEntranceLightColor;
        public Brush LeftEntranceLightColor
        {
            get => _leftEntranceLightColor;
            set
            {
                _leftEntranceLightColor = value;
                NotifyChange(nameof(LeftEntranceLightColor));
            }
        }

        private Brush _rightEntranceLightColor;
        public Brush RightEntranceLightColor
        {
            get => _rightEntranceLightColor;
            set
            {
                _rightEntranceLightColor = value;
                NotifyChange(nameof(RightEntranceLightColor));
            }
        }

        private Brush _upperGarageLightColor;
        public Brush UpperGarageLightColor
        {
            get => _upperGarageLightColor;
            set
            {
                _upperGarageLightColor = value;
                NotifyChange(nameof(UpperGarageLightColor));
            }
        }

        private Brush _lowerGarageLightColor;
        public Brush LowerGarageLightColor
        {
            get => _lowerGarageLightColor;
            set
            {
                _lowerGarageLightColor = value;
                NotifyChange(nameof(LowerGarageLightColor));
            }
        }

        private Brush _frontIrrigationColor;
        public Brush FrontIrrigationColor
        {
            get => _frontIrrigationColor;
            set
            {
                _frontIrrigationColor = value;
                NotifyChange(nameof(FrontIrrigationColor));
            }
        }

        private Brush _backIrrigationColor;
        public Brush BackIrrigationColor
        {
            get => _backIrrigationColor;
            set
            {
                _backIrrigationColor = value;
                NotifyChange(nameof(BackIrrigationColor));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public GardenPanelViewModel()
        {
            CheckMotionCommand = new DelegateCommand<Ellipse>(OnCheckMotion);
            LightClickedCommand = new DelegateCommand<Rectangle>(OnLightClicked);
            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            _lightsOutside = new()
            {
                _actualExternalFactors.garageLights,
                _actualExternalFactors.garageLights2,
                _actualExternalFactors.gardenLights,
                _actualExternalFactors.gardenLights2,
                _actualExternalFactors.gateEntranceLights,
                _actualExternalFactors.gateEntranceLights2
            };

            _irrigatives = new()
            {
                _actualExternalFactors.frontGarden,
                _actualExternalFactors.garden
            };

            InitializeLights();

            FrontIrrigationColor = Brushes.Black;
            BackIrrigationColor = Brushes.Black;

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            CheckLights();
            CheckIrrigation();
            ExtFactDataProvider.Update(_actualExternalFactors);
        }

        public async void InitializeLights()
        {
            await Task.Delay(0);
            foreach (var light in _lightsOutside)
            {
                bool l;
                switch (light.Place)
                {
                    case "Garden":
                        if (_actualExternalFactors.gardenLights.State == 1)
                        {
                            l = _actualExternalFactors.gardenLights.strenght <= 50;
                            LeftGardenLightColor = _actualExternalFactors.gardenLights.color == LightColor.warm ? l ? Brushes.LightYellow : Brushes.Yellow :
                                l ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        else
                        {
                            LeftGardenLightColor = Brushes.Black;
                        }
                        break;
                    case "Garden2":
                        if (_actualExternalFactors.gardenLights2.State == 1)
                        {
                            l = _actualExternalFactors.gardenLights2.strenght <= 50;
                            RightGardenLightColor = _actualExternalFactors.gardenLights2.color == LightColor.warm ? l ? Brushes.LightYellow : Brushes.Yellow :
                                l ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        else
                        {

                            RightGardenLightColor = Brushes.Black;
                        }
                        break;
                    case "Garage":
                        if (_actualExternalFactors.garageLights.State == 1)
                        {
                            l = _actualExternalFactors.garageLights.strenght <= 50;
                            LowerGarageLightColor = _actualExternalFactors.garageLights.color == LightColor.warm ? l ? Brushes.LightYellow : Brushes.Yellow :
                                l ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        else
                        {
                            LowerGarageLightColor = Brushes.Black;
                        }
                        break;
                    case "Garage2":
                        if (_actualExternalFactors.garageLights2.State == 1)
                        {
                            l = _actualExternalFactors.garageLights2.strenght <= 50;
                            UpperGarageLightColor = _actualExternalFactors.garageLights2.color == LightColor.warm ? l ? Brushes.LightYellow : Brushes.Yellow :
                                l ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        else
                        {
                            UpperGarageLightColor = Brushes.Black;
                        }
                        break;
                    case "Gate":
                        if (_actualExternalFactors.gateEntranceLights.State == 1)
                        {
                            l = _actualExternalFactors.gateEntranceLights.strenght <= 50;
                            LeftEntranceLightColor = _actualExternalFactors.gateEntranceLights.color == LightColor.warm ? l ? Brushes.LightYellow : Brushes.Yellow :
                                l ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        else
                        {
                            LeftEntranceLightColor = Brushes.Black;
                        }
                        break;
                    default:
                        if (_actualExternalFactors.gateEntranceLights2.State == 1)
                        {
                            l = _actualExternalFactors.gateEntranceLights2.strenght <= 50;
                            RightEntranceLightColor = _actualExternalFactors.gateEntranceLights2.color == LightColor.warm ? l ? Brushes.LightYellow : Brushes.Yellow :
                                l ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        else
                        {
                            RightEntranceLightColor = Brushes.Black;
                        }
                        break;
                }
            }
        }

        public async void CheckLights()
        {
            await Task.Delay(0);
            foreach (var light in _lightsOutside)
            {
                if (light.motionDetection && light.TimeLeft > 0)
                {
                    light.TimeLeft -= 1;
                    if (light.TimeLeft == 0)
                    {
                        TurnOffLamp(light);
                    }
                }
            }
        }

        public void CheckIrrigation()
        {
            foreach (var irrigative in _irrigatives)
            {
                if (irrigative.IsTimeSetting && irrigative.Time.ToLongTimeString().Equals(ToolKit.SecToMilitaryTime(DashboardViewModel.time)))
                {
                    ChangeIrrigationState(irrigative, true);
                    irrigative.TimeLeft = irrigative.timespan;
                }
                else if (irrigative.IsTempSetting && irrigative.RepeatTimeLeft == 0 && irrigative.Temp <= DashboardViewModel.tempValue)
                {
                    ChangeIrrigationState(irrigative, true);
                    irrigative.TimeLeft = irrigative.timespan;
                    irrigative.RepeatTimeLeft = 240;
                }

                if (irrigative.RepeatTimeLeft > 0)
                {
                    irrigative.RepeatTimeLeft -= 1;
                    if (irrigative.RepeatTimeLeft == 0)
                    {
                        ChangeIrrigationState(irrigative, true);
                        irrigative.TimeLeft = irrigative.timespan;
                    }
                }

                if (irrigative.TimeLeft > 0)
                {
                    irrigative.TimeLeft -= 1;
                    if (irrigative.TimeLeft == 0)
                    {
                        ChangeIrrigationState(irrigative, false);
                        if (irrigative.IsRepeated)
                        {
                            irrigative.RepeatTimeLeft = irrigative.Repeat * 60;
                        }
                    }
                }
            }
        }

        public void ChangeIrrigationState(Irrigative irrigative, bool start)
        {
            Brush color = start ? GetColorBasedOnIrrigationLevel(irrigative.strength) : Brushes.Black;
            if (irrigative.Place.Equals("Garden"))
            {
                BackIrrigationColor = color;
            }
            else
            {
                FrontIrrigationColor = color;
            }
        }

        public Brush GetColorBasedOnIrrigationLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return Brushes.LightBlue;
                case 2:
                    return Brushes.DeepSkyBlue;
                default:
                    return Brushes.DarkBlue;
            }
        }

        public void TurnOffLamp(Lights light)
        {
            switch (light.Place)
            {
                case "Garden":
                    LeftGardenLightColor = Brushes.Black;
                    _actualExternalFactors.gardenLights.State = 0;
                    break;
                case "Garden2":
                    RightGardenLightColor = Brushes.Black;
                    _actualExternalFactors.gardenLights2.State = 0;
                    break;
                case "Garage":
                    LowerGarageLightColor = Brushes.Black;
                    _actualExternalFactors.garageLights.State = 0;
                    break;
                case "Garage2":
                    UpperGarageLightColor = Brushes.Black;
                    _actualExternalFactors.garageLights2.State = 0;
                    break;
                case "Gate":
                    LeftEntranceLightColor = Brushes.Black;
                    _actualExternalFactors.gateEntranceLights.State = 0;
                    break;
                default:
                    RightEntranceLightColor = Brushes.Black;
                    _actualExternalFactors.gateEntranceLights2.State = 0;
                    break;
            }
        }

        public void OnCheckMotion(Ellipse e)
        {
            if (dispatcherTimer.IsEnabled)
            {
                bool light;
                switch (e.Tag.ToString())
                {
                    case "Garden":
                        if (_actualExternalFactors.gardenLights.motionDetection)
                        {
                            light = _actualExternalFactors.gardenLights.strenght <= 50;
                            LeftGardenLightColor = _actualExternalFactors.gardenLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.gardenLights.TimeLeft = _actualExternalFactors.gardenLights.activeSpan;
                            _actualExternalFactors.gardenLights.State = 1;
                        }
                        break;
                    case "Garden2":
                        if (_actualExternalFactors.gardenLights2.motionDetection)
                        {
                            light = _actualExternalFactors.garageLights2.strenght <= 50;
                            RightGardenLightColor = _actualExternalFactors.gardenLights2.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.gardenLights2.TimeLeft = _actualExternalFactors.gardenLights2.activeSpan;
                            _actualExternalFactors.gardenLights2.State = 1;
                        }
                        break;
                    case "Garage":
                        if (_actualExternalFactors.garageLights.motionDetection)
                        {
                            light = _actualExternalFactors.garageLights.strenght <= 50;
                            LowerGarageLightColor = _actualExternalFactors.garageLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.garageLights.TimeLeft = _actualExternalFactors.garageLights.activeSpan;
                            _actualExternalFactors.garageLights.State = 1;
                        }
                        break;
                    case "Garage2":
                        if (_actualExternalFactors.garageLights2.motionDetection)
                        {
                            light = _actualExternalFactors.garageLights2.strenght <= 50;
                            UpperGarageLightColor = _actualExternalFactors.garageLights2.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.garageLights2.TimeLeft = _actualExternalFactors.garageLights2.activeSpan;
                            _actualExternalFactors.garageLights2.State = 1;
                        }
                        break;
                    case "Gate":
                        if (_actualExternalFactors.gateEntranceLights.motionDetection)
                        {
                            light = _actualExternalFactors.gateEntranceLights.strenght <= 50;
                            LeftEntranceLightColor = _actualExternalFactors.gateEntranceLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.gateEntranceLights.TimeLeft = _actualExternalFactors.gateEntranceLights.activeSpan;
                            _actualExternalFactors.gateEntranceLights.State = 1;
                        }
                        break;
                    default:
                        if (_actualExternalFactors.gateEntranceLights2.motionDetection)
                        {
                            light = _actualExternalFactors.gateEntranceLights2.strenght <= 50;
                            RightEntranceLightColor = _actualExternalFactors.gateEntranceLights2.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.gateEntranceLights2.TimeLeft = _actualExternalFactors.gateEntranceLights2.activeSpan;
                            _actualExternalFactors.gateEntranceLights2.State = 1;
                        }
                        break;
                }
            }
        }

        public void OnLightClicked(Rectangle r)
        {
            if (dispatcherTimer.IsEnabled)
            {
                bool light;
                switch (r.Name)
                {
                    case "GardenL":
                        if (_actualExternalFactors.gardenLights.State == 1)
                        {
                            _actualExternalFactors.gardenLights.State = 0;
                            LeftGardenLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.gardenLights.State = 1;
                            light = _actualExternalFactors.gardenLights.strenght <= 50;
                            LeftGardenLightColor = _actualExternalFactors.gardenLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.gardenLights.motionDetection = false;
                        break;
                    case "Garden2L":
                        if (_actualExternalFactors.gardenLights2.State == 1)
                        {
                            _actualExternalFactors.gardenLights2.State = 0;
                            RightGardenLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.gardenLights2.State = 1;
                            light = _actualExternalFactors.gardenLights2.strenght <= 50;
                            RightGardenLightColor = _actualExternalFactors.gardenLights2.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.gardenLights2.motionDetection = false;
                        break;
                    case "GateL":
                        if (_actualExternalFactors.gateEntranceLights.State == 1)
                        {
                            _actualExternalFactors.gateEntranceLights.State = 0;
                            LeftEntranceLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.gateEntranceLights.State = 1;
                            light = _actualExternalFactors.gateEntranceLights.strenght <= 50;
                            LeftEntranceLightColor = _actualExternalFactors.gateEntranceLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.gateEntranceLights.motionDetection = false;
                        break;
                    case "Gate2L":
                        if (_actualExternalFactors.gateEntranceLights2.State == 1)
                        {
                            _actualExternalFactors.gateEntranceLights2.State = 0;
                            RightEntranceLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.gateEntranceLights2.State = 1;
                            light = _actualExternalFactors.gateEntranceLights2.strenght <= 50;
                            RightEntranceLightColor = _actualExternalFactors.gateEntranceLights2.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.gateEntranceLights2.motionDetection = false;
                        break;
                    case "GarageL":
                        if (_actualExternalFactors.garageLights.State == 1)
                        {
                            _actualExternalFactors.garageLights.State = 0;
                            LowerGarageLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.garageLights.State = 1;
                            light = _actualExternalFactors.garageLights.strenght <= 50;
                            LowerGarageLightColor = _actualExternalFactors.garageLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.garageLights.motionDetection = false;
                        break;
                    default:
                        if (_actualExternalFactors.garageLights2.State == 1)
                        {
                            _actualExternalFactors.garageLights2.State = 0;
                            UpperGarageLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.garageLights2.State = 1;
                            light = _actualExternalFactors.garageLights2.strenght <= 50;
                            UpperGarageLightColor = _actualExternalFactors.garageLights2.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.garageLights2.motionDetection = false;
                        break;
                }
            }
        }
    }
}
