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

        public MapViewModel(IContainerExtension container, IEventAggregator eventAggregator) : base(container, eventAggregator)
        {
            InitCommand();
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
