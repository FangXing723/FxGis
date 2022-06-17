using Mapsui.UI.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.MapsuiModule.ViewModels
{
    public class MapViewModel: BindableBase
    {
        internal MapControl _mapControl;

        public MapViewModel()
        {
            RegisterCommand();
        }



        public DelegateCommand MapTestCommand { get; set; }

        private void RegisterCommand()
        {
            MapTestCommand = new DelegateCommand(() => MapTest());
        }

        private void MapTest()
        {
            System.Diagnostics.Debug.WriteLine("hello!");
            System.Diagnostics.Debug.WriteLine("_mapControl:"+(_mapControl == null ? "未创建" : "已创建"));
        }
    }
}
