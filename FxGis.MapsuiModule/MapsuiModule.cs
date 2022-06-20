using FxGis.App.Core.Tool;
using FxGis.MapsuiModule.Tool;
using FxGis.MapsuiModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.MapsuiModule
{
    public class MapsuiModule : IModule
    {
        public static string RegionName = "MapRegion";

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionName, typeof(MapView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            /// 问题原因：原本将各模块的工具都在各子的Module配置中进行注册，但是由于将多个模块的工具都放在了基础的ViewModel父类中（方便调用），因此获取时会由于其它模块还没有被加载，导致获取失败。
            /// 解决方法：将三个工具放置在App模块中进行单例注册，工具所操作的数据对象（地图控件、场景控件、工程数据）通过订阅发布机制，在其数据对象在被创建时发布，在工具接口实现类中通过订阅获取
            
            ///// 注册地图工具
            ///// 单例注册
            ///// 此系统中地图等部分是不变的，改变的是工程数据，因此采用单例模式注册
            ///// 通过Prism的IOC容器进行工具注册，其它模块使用Core模块的工具接口，实现模块间解耦
            //containerRegistry.RegisterSingleton<IMapTool, MapToolImpl>();
            //System.Diagnostics.Debug.WriteLine("MapToolImpl 单例模式完成IOC注册");

        }
    }
}
