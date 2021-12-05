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
    public class SimulationPanelViewModel : INotifyPropertyChanged
    {
        public DelegateCommand<Rectangle> ElectronicClickedCommand { get; set; }
        public DelegateCommand<Rectangle> CheckMotionCommand { get; set; }
        public DelegateCommand<Rectangle> WindowLeftClickedCommand { get; set; }
        public DelegateCommand<Rectangle> WindowRightClickedCommand { get; set; }
        public DelegateCommand<Rectangle> LightClickedCommand { get; set; }

        private ExternalFactors _actualExternalFactors;

        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private List<Lights> _lightsInside;

        private List<Shading> _shadings;

        public int LightValue { get; set; }

        private Brush _TVColor;
        public Brush TVColor
        {
            get => _TVColor;
            set
            {
                _TVColor = value;
                NotifyChange(nameof(TVColor));
            }
        }

        private Brush _radioColor;
        public Brush RadioColor
        {
            get => _radioColor;
            set
            {
                _radioColor = value;
                NotifyChange(nameof(RadioColor));
            }
        }

        private Brush _entryLightColor;
        public Brush EntryLightColor
        {
            get => _entryLightColor;
            set
            {
                _entryLightColor = value;
                NotifyChange(nameof(EntryLightColor));
            }
        }

        private Brush _LivingroomLightColor;
        public Brush LivingroomLightColor
        {
            get => _LivingroomLightColor;
            set
            {
                _LivingroomLightColor = value;
                NotifyChange(nameof(LivingroomLightColor));
            }
        }

        private Brush _kitchenLightColor;
        public Brush KitchenLightColor
        {
            get => _kitchenLightColor;
            set
            {
                _kitchenLightColor = value;
                NotifyChange(nameof(KitchenLightColor));
            }
        }

        private Brush _bathLightColor;
        public Brush BathLightColor
        {
            get => _bathLightColor;
            set
            {
                _bathLightColor = value;
                NotifyChange(nameof(BathLightColor));
            }
        }

        private Brush _diningLightColor;
        public Brush DiningLightColor
        {
            get => _diningLightColor;
            set
            {
                _diningLightColor = value;
                NotifyChange(nameof(DiningLightColor));
            }
        }

        private Brush _officeLightColor;
        public Brush OfficeLightColor
        {
            get => _officeLightColor;
            set
            {
                _officeLightColor = value;
                NotifyChange(nameof(OfficeLightColor));
            }
        }

        private Brush _room1LightColor;
        public Brush Room1LightColor
        {
            get => _room1LightColor;
            set
            {
                _room1LightColor = value;
                NotifyChange(nameof(Room1LightColor));
            }
        }

        private Brush _room2LightColor;
        public Brush Room2LightColor
        {
            get => _room2LightColor;
            set
            {
                _room2LightColor = value;
                NotifyChange(nameof(Room2LightColor));
            }
        }

        private Brush _room3LightColor;
        public Brush Room3LightColor
        {
            get => _room3LightColor;
            set
            {
                _room3LightColor = value;
                NotifyChange(nameof(Room3LightColor));
            }
        }

        private Brush _panoramaWindowColor;
        public Brush PanoramaWindowColor
        {
            get => _panoramaWindowColor;
            set
            {
                _panoramaWindowColor = value;
                NotifyChange(nameof(PanoramaWindowColor));
            }
        }

        private Brush _bigWindowColor;
        public Brush BigWindowColor
        {
            get => _bigWindowColor;
            set
            {
                _bigWindowColor = value;
                NotifyChange(nameof(BigWindowColor));
            }
        }

        private Brush _kitchenWindowColor;
        public Brush KitchenWindowColor
        {
            get => _kitchenWindowColor;
            set
            {
                _kitchenWindowColor = value;
                NotifyChange(nameof(KitchenWindowColor));
            }
        }

        private Brush _diningWindowColor;
        public Brush DiningWindowColor
        {
            get => _diningWindowColor;
            set
            {
                _diningWindowColor = value;
                NotifyChange(nameof(DiningWindowColor));
            }
        }

        private Brush _officeWindowColor;
        public Brush OfficeWindowColor
        {
            get => _officeWindowColor;
            set
            {
                _officeWindowColor = value;
                NotifyChange(nameof(OfficeWindowColor));
            }
        }

        private Brush _room1WindowColor;
        public Brush Room1WindowColor
        {
            get => _room1WindowColor;
            set
            {
                _room1WindowColor = value;
                NotifyChange(nameof(Room1WindowColor));
            }
        }

        private Brush _room2WindowColor;
        public Brush Room2WindowColor
        {
            get => _room2WindowColor;
            set
            {
                _room2WindowColor = value;
                NotifyChange(nameof(Room2WindowColor));
            }
        }

        private Brush _room3WindowColor;
        public Brush Room3WindowColor
        {
            get => _room3WindowColor;
            set
            {
                _room3WindowColor = value;
                NotifyChange(nameof(Room3WindowColor));
            }
        }

        private Brush _bathLeftWindowColor;
        public Brush BathLeftWindowColor
        {
            get => _bathLeftWindowColor;
            set
            {
                _bathLeftWindowColor = value;
                NotifyChange(nameof(BathLeftWindowColor));
            }
        }

        private Brush _bathRightWindowColor;
        public Brush BathRightWindowColor
        {
            get => _bathRightWindowColor;
            set
            {
                _bathRightWindowColor = value;
                NotifyChange(nameof(BathRightWindowColor));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public SimulationPanelViewModel()
        {
            ElectronicClickedCommand = new DelegateCommand<Rectangle>(OnElectronicClicked);
            CheckMotionCommand = new DelegateCommand<Rectangle>(OnCheckMotion);
            WindowLeftClickedCommand = new DelegateCommand<Rectangle>(OnWindowLeftClicked);
            WindowRightClickedCommand = new DelegateCommand<Rectangle>(OnWindowRightClicked);
            LightClickedCommand = new DelegateCommand<Rectangle>(OnLightClicked);

            _actualExternalFactors = ExtFactDataProvider.Get().ToList()[0];
            _lightsInside = new()
            {
                _actualExternalFactors.bathLights,
                _actualExternalFactors.diningLights,
                _actualExternalFactors.entryLights,
                _actualExternalFactors.kitchenLights,
                _actualExternalFactors.livingroomLights,
                _actualExternalFactors.officeLights,
                _actualExternalFactors.roomno1Lights,
                _actualExternalFactors.roomno2Lights,
                _actualExternalFactors.roomno3Lights
            };

            _shadings = new()
            {
                _actualExternalFactors.bathLeftWindowShading,
                _actualExternalFactors.bathRightWindowShading,
                _actualExternalFactors.livingroomPanoramaShading,
                _actualExternalFactors.livingroomShading,
                _actualExternalFactors.officeShading,
                _actualExternalFactors.kitchenShading,
                _actualExternalFactors.diningShading,
                _actualExternalFactors.roomno1Shading,
                _actualExternalFactors.roomno2Shading,
                _actualExternalFactors.roomno3Shading
            };

            foreach (var shading in _shadings)
            {
                ShadeWindow(shading, ShadePreference.NONE);
            }

            TVColor = Brushes.Black;
            RadioColor = Brushes.Black;
            EntryLightColor = Brushes.Black;
            LivingroomLightColor = Brushes.Black;
            KitchenLightColor = Brushes.Black;
            DiningLightColor = Brushes.Black;
            OfficeLightColor = Brushes.Black;
            BathLightColor = Brushes.Black;
            Room1LightColor = Brushes.Black;
            Room2LightColor = Brushes.Black;
            Room3LightColor = Brushes.Black;

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            CheckElectronics();
            CheckLights();
            CheckWindows();
            ExtFactDataProvider.Update(_actualExternalFactors);
        }

        public void CheckElectronics()
        {
            foreach (var ev in _actualExternalFactors.ElectronicEvents)
            {
                if (ev.EventTime.ToLongTimeString().Equals(ToolKit.SecToMilitaryTime(DashboardViewModel.time)))
                {
                    if (ev.Type.Equals("TV"))
                    {
                        TVColor = Brushes.LightGreen;
                    }
                    else
                    {
                        RadioColor = Brushes.LightGreen;
                    }
                }
            }
        }

        public async void CheckLights()
        {
            await Task.Delay(0);
            foreach (var light in _lightsInside)
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

        public async void CheckWindows()
        {
            await Task.Delay(0);
            LightValue = TemperatureDataProvider.GenerateLight(DashboardViewModel.time / 60);
            foreach (var shading in _shadings)
            {
                if (shading.ShadePreference == ShadePreference.PHOTOSENSITIVTY)
                {
                    if (shading.State != 5 && shading.Photosensitivity < LightValue + (shading.Level - 1) * 50)
                    {
                        ShadeWindow(shading, ShadePreference.PHOTOSENSITIVTY);
                    }
                }
                else if (shading.ShadePreference == ShadePreference.TIME)
                {
                    var actualTime = ToolKit.SecToMilitaryTime(DashboardViewModel.time);
                    if (shading.State != 5 && shading.Date.ToLongTimeString().Equals(actualTime))
                    {
                        shading.State = 5;
                        ShadeWindow(shading, ShadePreference.NONE);
                    }
                    else if (shading.State != 5 && shading.Date.AddHours((shading.Level - shading.State - 1) * -0.5).ToLongTimeString().Equals(actualTime))
                    {
                        ShadeWindow(shading, ShadePreference.TIME);
                    }
                }
            }
        }

        public void TurnOffLamp(Lights light)
        {
            switch (light.Place)
            {
                case "Entry":
                    EntryLightColor = Brushes.Black;
                    _actualExternalFactors.entryLights.State = 0;
                    break;
                case "Livingroom":
                    LivingroomLightColor = Brushes.Black;
                    _actualExternalFactors.livingroomLights.State = 0;
                    break;
                case "Kitchen":
                    KitchenLightColor = Brushes.Black;
                    _actualExternalFactors.kitchenLights.State = 0;
                    break;
                case "Office":
                    OfficeLightColor = Brushes.Black;
                    _actualExternalFactors.officeLights.State = 0;
                    break;
                case "Bath":
                    BathLightColor = Brushes.Black;
                    _actualExternalFactors.bathLights.State = 0;
                    break;
                case "Dining":
                    DiningLightColor = Brushes.Black;
                    _actualExternalFactors.diningLights.State = 0;
                    break;
                case "Room1":
                    Room1LightColor = Brushes.Black;
                    _actualExternalFactors.roomno1Lights.State = 0;
                    break;
                case "Room2":
                    Room2LightColor = Brushes.Black;
                    _actualExternalFactors.roomno2Lights.State = 0;
                    break;
                default:
                    Room3LightColor = Brushes.Black;
                    _actualExternalFactors.roomno3Lights.State = 0;
                    break;
            }
        }

        public void OnLightClicked(Rectangle r)
        {
            if (dispatcherTimer.IsEnabled)
            {
                bool light;
                switch (r.Name)
                {
                    case "KitchenL":
                        if (_actualExternalFactors.kitchenLights.State == 1)
                        {
                            _actualExternalFactors.kitchenLights.State = 0;
                            KitchenLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.kitchenLights.State = 1;
                            light = _actualExternalFactors.kitchenLights.strenght <= 50;
                            KitchenLightColor = _actualExternalFactors.kitchenLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.kitchenLights.motionDetection = false;
                        break;
                    case "LivingL":
                        if (_actualExternalFactors.livingroomLights.State == 1)
                        {
                            _actualExternalFactors.livingroomLights.State = 0;
                            LivingroomLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.livingroomLights.State = 1;
                            light = _actualExternalFactors.livingroomLights.strenght <= 50;
                            LivingroomLightColor = _actualExternalFactors.livingroomLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.livingroomLights.motionDetection = false;
                        break;
                    case "Room1L":
                        if (_actualExternalFactors.roomno1Lights.State == 1)
                        {
                            _actualExternalFactors.roomno1Lights.State = 0;
                            Room1LightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.roomno1Lights.State = 1;
                            light = _actualExternalFactors.roomno1Lights.strenght <= 50;
                            Room1LightColor = _actualExternalFactors.roomno1Lights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.roomno1Lights.motionDetection = false;
                        break;
                    case "Room2L":
                        if (_actualExternalFactors.roomno2Lights.State == 1)
                        {
                            _actualExternalFactors.roomno2Lights.State = 0;
                            Room2LightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.roomno2Lights.State = 1;
                            light = _actualExternalFactors.roomno2Lights.strenght <= 50;
                            Room2LightColor = _actualExternalFactors.roomno2Lights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.roomno2Lights.motionDetection = false;
                        break;
                    case "Room3L":
                        if (_actualExternalFactors.roomno3Lights.State == 1)
                        {
                            _actualExternalFactors.roomno3Lights.State = 0;
                            Room3LightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.roomno3Lights.State = 1;
                            light = _actualExternalFactors.roomno3Lights.strenght <= 50;
                            Room3LightColor = _actualExternalFactors.roomno3Lights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.roomno3Lights.motionDetection = false;
                        break;
                    case "OfficeL":
                        if (_actualExternalFactors.officeLights.State == 1)
                        {
                            _actualExternalFactors.officeLights.State = 0;
                            OfficeLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.officeLights.State = 1;
                            light = _actualExternalFactors.officeLights.strenght <= 50;
                            OfficeLightColor = _actualExternalFactors.officeLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.officeLights.motionDetection = false;
                        break;
                    case "BathL":
                        if (_actualExternalFactors.bathLights.State == 1)
                        {
                            _actualExternalFactors.bathLights.State = 0;
                            BathLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.bathLights.State = 1;
                            light = _actualExternalFactors.bathLights.strenght <= 50;
                            BathLightColor = _actualExternalFactors.bathLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.bathLights.motionDetection = false;
                        break;
                    case "DiningL":
                        if (_actualExternalFactors.diningLights.State == 1)
                        {
                            _actualExternalFactors.diningLights.State = 0;
                            DiningLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.diningLights.State = 1;
                            light = _actualExternalFactors.diningLights.strenght <= 50;
                            DiningLightColor = _actualExternalFactors.diningLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.diningLights.motionDetection = false;
                        break;
                    default:
                        if (_actualExternalFactors.entryLights.State == 1)
                        {
                            _actualExternalFactors.entryLights.State = 0;
                            EntryLightColor = Brushes.Black;
                        }
                        else
                        {
                            _actualExternalFactors.entryLights.State = 1;
                            light = _actualExternalFactors.entryLights.strenght <= 50;
                            EntryLightColor = _actualExternalFactors.entryLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                        }
                        _actualExternalFactors.entryLights.motionDetection = false;
                        break;
                }
            }
        }

        public void OnElectronicClicked(Rectangle r)
        {
            if (r.Name.Equals("TV"))
            {
                TVColor = Brushes.Black;
            }
            else
            {
                RadioColor = Brushes.Black;
            }
        }

        public void OnCheckMotion(Rectangle r)
        {
            if (dispatcherTimer.IsEnabled)
            {
                bool light;
                switch (r.Tag.ToString())
                {
                    case "Entry":
                        if (_actualExternalFactors.entryLights.motionDetection)
                        {
                            light = _actualExternalFactors.entryLights.strenght <= 50;
                            EntryLightColor = _actualExternalFactors.entryLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.entryLights.TimeLeft = _actualExternalFactors.entryLights.activeSpan;
                            _actualExternalFactors.entryLights.State = 1;
                        }
                        break;
                    case "Livingroom":
                        if (_actualExternalFactors.livingroomLights.motionDetection)
                        {
                            light = _actualExternalFactors.livingroomLights.strenght <= 50;
                            LivingroomLightColor = _actualExternalFactors.livingroomLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.livingroomLights.TimeLeft = _actualExternalFactors.livingroomLights.activeSpan;
                            _actualExternalFactors.livingroomLights.State = 1;
                        }
                        break;
                    case "Kitchen":
                        if (_actualExternalFactors.kitchenLights.motionDetection)
                        {
                            light = _actualExternalFactors.kitchenLights.strenght <= 50;
                            KitchenLightColor = _actualExternalFactors.kitchenLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.kitchenLights.TimeLeft = _actualExternalFactors.kitchenLights.activeSpan;
                            _actualExternalFactors.kitchenLights.State = 1;
                        }
                        break;
                    case "Office":
                        if (_actualExternalFactors.officeLights.motionDetection)
                        {
                            light = _actualExternalFactors.officeLights.strenght <= 50;
                            OfficeLightColor = _actualExternalFactors.officeLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.officeLights.TimeLeft = _actualExternalFactors.officeLights.activeSpan;
                            _actualExternalFactors.officeLights.State = 1;
                        }
                        break;
                    case "Bath":
                        if (_actualExternalFactors.bathLights.motionDetection)
                        {
                            light = _actualExternalFactors.bathLights.strenght <= 50;
                            BathLightColor = _actualExternalFactors.bathLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.bathLights.TimeLeft = _actualExternalFactors.bathLights.activeSpan;
                            _actualExternalFactors.bathLights.State = 1;
                        }
                        break;
                    case "Dining":
                        if (_actualExternalFactors.diningLights.motionDetection)
                        {
                            light = _actualExternalFactors.diningLights.strenght <= 50;
                            DiningLightColor = _actualExternalFactors.diningLights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.diningLights.TimeLeft = _actualExternalFactors.diningLights.activeSpan;
                            _actualExternalFactors.diningLights.State = 1;
                        }
                        break;
                    case "Room1":
                        if (_actualExternalFactors.roomno1Lights.motionDetection)
                        {
                            light = _actualExternalFactors.roomno1Lights.strenght <= 50;
                            Room1LightColor = _actualExternalFactors.roomno1Lights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.roomno1Lights.TimeLeft = _actualExternalFactors.roomno1Lights.activeSpan;
                            _actualExternalFactors.roomno1Lights.State = 1;
                        }
                        break;
                    case "Room2":
                        if (_actualExternalFactors.roomno2Lights.motionDetection)
                        {
                            light = _actualExternalFactors.roomno2Lights.strenght <= 50;
                            Room2LightColor = _actualExternalFactors.roomno2Lights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.roomno2Lights.TimeLeft = _actualExternalFactors.roomno2Lights.activeSpan;
                            _actualExternalFactors.roomno2Lights.State = 1;
                        }
                        break;
                    default:
                        if (_actualExternalFactors.roomno3Lights.motionDetection)
                        {
                            light = _actualExternalFactors.roomno3Lights.strenght <= 50;
                            Room3LightColor = _actualExternalFactors.roomno3Lights.color == LightColor.warm ? light ? Brushes.LightYellow : Brushes.Yellow :
                                light ? Brushes.LightSteelBlue : Brushes.SteelBlue;
                            _actualExternalFactors.roomno3Lights.TimeLeft = _actualExternalFactors.roomno3Lights.activeSpan;
                            _actualExternalFactors.roomno3Lights.State = 1;
                        }
                        break;
                }
            }
        }

        public void OnWindowLeftClicked(Rectangle r)
        {
            if (dispatcherTimer.IsEnabled)
            {
                ManuallyChangeWindowState(false, r.Name);
            }
        }

        public void OnWindowRightClicked(Rectangle r)
        {
            if (dispatcherTimer.IsEnabled)
            {
                ManuallyChangeWindowState(true, r.Name);
            }
        }

        public void ManuallyChangeWindowState(bool up, string windowName)
        {
            int value = up ? -1 : 1;
            switch (windowName)
            {
                case "LivingPanoramaW":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.livingroomPanoramaShading.State))
                    {
                        _actualExternalFactors.livingroomPanoramaShading.State += value;
                        PanoramaWindowColor = GetColorBasedOnShadingState(_actualExternalFactors.livingroomPanoramaShading.State);
                    }
                    break;
                case "LivingBigW":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.livingroomShading.State))
                    {
                        _actualExternalFactors.livingroomShading.State += value;
                        BigWindowColor = GetColorBasedOnShadingState(_actualExternalFactors.livingroomShading.State);
                    }
                    break;
                case "BathLeftW":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.bathLeftWindowShading.State))
                    {
                        _actualExternalFactors.bathLeftWindowShading.State += value;
                        BathLeftWindowColor = GetColorBasedOnShadingState(_actualExternalFactors.bathLeftWindowShading.State);
                    }
                    break;
                case "BathRightW":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.bathRightWindowShading.State))
                    {
                        _actualExternalFactors.bathRightWindowShading.State += value;
                        BathRightWindowColor = GetColorBasedOnShadingState(_actualExternalFactors.bathRightWindowShading.State);
                    }
                    break;
                case "OfficeW":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.officeShading.State))
                    {
                        _actualExternalFactors.officeShading.State += value;
                        OfficeWindowColor = GetColorBasedOnShadingState(_actualExternalFactors.officeShading.State);
                    }
                    break;
                case "DiningW":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.diningShading.State))
                    {
                        _actualExternalFactors.diningShading.State += value;
                        DiningWindowColor = GetColorBasedOnShadingState(_actualExternalFactors.diningShading.State);
                    }
                    break;
                case "KitchenW":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.kitchenShading.State))
                    {
                        _actualExternalFactors.kitchenShading.State += value;
                        KitchenWindowColor = GetColorBasedOnShadingState(_actualExternalFactors.kitchenShading.State);
                    }
                    break;
                case "Room1W":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.roomno1Shading.State))
                    {
                        _actualExternalFactors.roomno1Shading.State += value;
                        Room1WindowColor = GetColorBasedOnShadingState(_actualExternalFactors.roomno1Shading.State);
                    }
                    break;
                case "Room2W":
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.roomno2Shading.State))
                    {
                        _actualExternalFactors.roomno2Shading.State += value;
                        Room2WindowColor = GetColorBasedOnShadingState(_actualExternalFactors.roomno2Shading.State);
                    }
                    break;
                default:
                    if (CanExecuteWindowStateChange(value, _actualExternalFactors.roomno3Shading.State))
                    {
                        _actualExternalFactors.roomno3Shading.State += value;
                        Room3WindowColor = GetColorBasedOnShadingState(_actualExternalFactors.roomno3Shading.State);
                    }
                    break;
            }
        }

        public bool CanExecuteWindowStateChange(int value, int actualState)
        {
            return actualState + value < 6 && actualState + value > -1;
        }

        public void ShadeWindow(Shading shading, ShadePreference shadePreference)
        {
            if (shadePreference == ShadePreference.PHOTOSENSITIVTY)
            {
                shading.State = CalculateStateBasedOnLight(shading);
            }
            else if (shadePreference == ShadePreference.TIME)
            {
                shading.State = CalculateStateBasedOnTime(shading);
            }

            Brush color = GetColorBasedOnShadingState(shading.State);
            switch (shading.Place)
            {
                case "LivingBig":
                    BigWindowColor = color;
                    break;
                case "Kitchen":
                    KitchenWindowColor = color;
                    break;
                case "Office":
                    OfficeWindowColor = color;
                    break;
                case "BathRight":
                    BathRightWindowColor = color;
                    break;
                case "BathLeft":
                    BathLeftWindowColor = color;
                    break;
                case "Dining":
                    DiningWindowColor = color;
                    break;
                case "LivingPanorama":
                    PanoramaWindowColor = color;
                    break;
                case "Room1":
                    Room1WindowColor = color;
                    break;
                case "Room2":
                    Room2WindowColor = color;
                    break;
                default:
                    Room3WindowColor = color;
                    break;
            }
        }

        public Brush GetColorBasedOnShadingState(int shadingState)
        {
            switch (shadingState)
            {
                case 5:
                    return Brushes.DarkBlue;
                case 4:
                    return Brushes.DimGray;
                case 3:
                    return Brushes.Gray;
                case 2:
                    return Brushes.DarkGray;
                case 1:
                    return Brushes.LightGray;
                default:
                    return Brushes.SkyBlue;
            }
        }

        public int CalculateStateBasedOnLight(Shading shading)
        {
            int state = 5;

            for (int i = 1; i < shading.Level; i++)
            {
                if (shading.Photosensitivity + i * 50 > LightValue)
                {
                    state = i;
                    break;
                }
            }

            return state < shading.State ? shading.State : state;
        }

        public int CalculateStateBasedOnTime(Shading shading)
        {
            return ++shading.State;
        }
    }
}