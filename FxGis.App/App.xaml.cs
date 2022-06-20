using FxGis.App.Core.Tool;
using FxGis.App.Views;
using FxGis.MapsuiModule.Tool;
using FxGis.ProjectTreeModule.Tool;
using FxGis.VtkModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FxGis.App
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            /// 注册工程数据管理工具
            /// 单例注册
            /// 此系统中地图等部分是不变的，改变的是工程数据，因此采用单例模式注册
            /// 通过Prism的IOC容器进行工具注册，其它模块使用Core模块的工具接口，实现模块间解耦
            containerRegistry.RegisterSingleton<ITreeTool, TreeToolImpl>();
            System.Diagnostics.Debug.WriteLine("TreeToolImpl 单例模式完成IOC注册");
            containerRegistry.RegisterSingleton<IMapTool, MapToolImpl>();
            System.Diagnostics.Debug.WriteLine("MapToolImpl 单例模式完成IOC注册");



        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ProjectTreeModule.ProjectTreeModule>();
            moduleCatalog.AddModule<MapsuiModule.MapsuiModule>();
            moduleCatalog.AddModule<VtkModule.VtkModule>();
        }
    }
}
