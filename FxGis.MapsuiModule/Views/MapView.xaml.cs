using FxGis.MapsuiModule.Tool;
using FxGis.MapsuiModule.ViewModels;
using Mapsui.UI.Wpf;
using Prism.Common;
using Prism.Events;
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
        public MapView(IEventAggregator ea)
        {
            InitializeComponent();

            //将View的内容给到VM
            //Prism框架构建顺序：View→ViewModel
            //(DataContext as MapViewModel)._mapControl = mapsuiMapControl;
            //增加一个默认的OSM底图
            mapsuiMapControl?.Map?.Layers.Add(Mapsui.Utilities.OpenStreetMap.CreateTileLayer());

            //Prism的订阅发布机制，用作地图工具的操作对象（地图对象）的注入
            //当View初始化后（及MapControl初始化后），将MapControl发布，由地图工具（具体实现类）进行订阅，然后接收被工具操作的MapControl对象，完成工具的初始化
            ea.GetEvent<MapPubSubEvent>().Publish(mapsuiMapControl);
        }

    }
}
