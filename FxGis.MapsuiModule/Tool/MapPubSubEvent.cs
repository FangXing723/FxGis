using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.MapsuiModule.Tool
{
    /// <summary>
    /// Prism订阅发布
    /// 实现对MapTool中地图控件对象的依赖注入
    /// </summary>
    public class MapPubSubEvent : PubSubEvent<Mapsui.UI.Wpf.MapControl>
    {
    }
}
