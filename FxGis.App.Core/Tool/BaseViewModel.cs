using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.App.Core.Tool
{
    /// <summary>
    /// AppCore模块VM基类
    /// 集中管理工具对业务模块暴露，业务模块本身做工具的具体实现
    /// </summary>
    public class BaseViewModel : BindableBase
    {
        /// <summary>
        /// Prism.IOC容器
        /// </summary>
        internal  IContainerExtension _container;
        /// <summary>
        /// 地图工具
        /// </summary>
        public IMapTool _mapTool;
        


        public BaseViewModel(IContainerExtension container)
        {
            //获取IOC容器
            _container = container;

            //通过IOC获取注册的MapTool
            _mapTool = (IMapTool)_container.Resolve(typeof(IMapTool));
        }

    }
}
