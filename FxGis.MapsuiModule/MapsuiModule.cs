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
            /// 注册地图工具
            /// 单例注册
            /// 此系统中地图等部分是不变的，改变的是工程数据，因此采用单例模式注册
            /// 通过Prism的IOC容器进行工具注册，其它模块使用Core模块的工具接口，实现模块间解耦
            containerRegistry.RegisterSingleton<IMapTool, MapToolImpl>();

            System.Diagnostics.Debug.WriteLine("MapToolImpl 单例模式完成IOC注册");

        }
    }
}
