using FxGis.MapsuiModule.ViewModels;
using Mapsui.UI.Wpf;
using Prism.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FxGis.MapsuiModule.Views
{
    /// <summary>
    /// MapView.xaml 的交互逻辑
    /// </summary>
    public partial class MapView : UserControl
    {
        public MapView()
        {
            InitializeComponent();

            ///// Prisim提供的View视图部分的Context的PropertyChanged事件机制
            ///// 通过这个机制可以将View中的数据对象给到其绑定的VM中，例如将View中创建的Mapsui.MapControl给到其VM中，用作地图控件的封装
            //RegionContext.GetObservableContext(this.mapsuiMapControl).PropertyChanged += MapsuiMapControl_PropertyChanged;



            (DataContext as MapViewModel)._mapControl = mapsuiMapControl;

            mapsuiMapControl?.Map?.Layers.Add(Mapsui.Utilities.OpenStreetMap.CreateTileLayer());
        }

        private void MapsuiMapControl_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var context = (ObservableObject<object>)sender;
            var mapControl_InView = (MapControl)context.Value;
            (DataContext as MapViewModel)._mapControl = mapControl_InView;


        }
    }
}
