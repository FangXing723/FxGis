using FxGis.App.Core.Tool;
using FxGis.MapsuiModule.Tool;
using Mapsui.UI.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.MapsuiModule.ViewModels
{
    public class MapViewModel : BaseViewModel
    {

        private MapControl _mapControl;

        public MapControl MapControl
        {
            get => _mapControl;
            set
            {
                _mapControl = value;
                _mapControl.MouseMove += _mapControl_MouseMove;

            }
        }
        public string MousePositionInfo { get; set; }

        public MapViewModel(IContainerExtension container, IEventAggregator eventAggregator) : base(container, eventAggregator)
        {
            InitCommand();
        }

        private void _mapControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var screenPosition = e.GetPosition(_mapControl);
            var worldPosition = _mapControl.Viewport.ScreenToWorld(screenPosition.X, screenPosition.Y);
            MousePositionInfo = $"{worldPosition.X:F2}, {worldPosition.Y:F2}";
            RaisePropertyChanged(nameof(MousePositionInfo));
        }


        public DelegateCommand MapTestCommand { get; set; }

        private void InitCommand()
        {
            MapTestCommand = new DelegateCommand(() => MapTest());
        }

        private void MapTest()
        {
            MapTool.RemoveLayer("OpenStreetMap");

            System.Diagnostics.Debug.WriteLine("hello!");
        }
    }
}
