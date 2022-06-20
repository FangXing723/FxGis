using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.App.Core.Tool
{
    /// <summary>
    /// AppCore模块VM基类
    /// 集中管理工具对业务模块暴露，业务模块本身做工具的具体实现，通过Prism.IOC实现解耦，通过Prism.事件聚合实现工具类内对象的注入
    /// </summary>
    public class BaseViewModel : BindableBase
    {
        /// <summary>
        /// Prism.IOC容器
        /// </summary>
        public IContainerExtension _container { get; private set; }
        /// <summary>
        /// Prism.事件聚合器
        /// </summary>
        public IEventAggregator _eventAggregator { get; private set; }

        /// <summary>
        /// 地图工具
        /// 工具在最开始注入到Prism的IOC容器
        /// </summary>
        public IMapTool MapTool { get; private set; }

        /// <summary>
        /// 工程目录树工具
        /// </summary>
        public ITreeTool TreeTool { get; private set; }


        public BaseViewModel(IContainerExtension container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;

            /// 通过IOC获取注册的模块工具
            /// 此时获取的工具内部操作的核心数据对象还没有注入，在各模块完成初始化后基于事件聚合器实现注入
            TreeTool = (ITreeTool)_container.Resolve(typeof(ITreeTool));
            MapTool = (IMapTool)_container.Resolve(typeof(IMapTool));

            System.Diagnostics.Debug.WriteLine("当前加载的VM模块：" + this.GetType().ToString());
        }

    }
}
