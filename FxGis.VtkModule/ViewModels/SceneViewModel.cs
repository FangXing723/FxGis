using FxGis.App.Core.Tool;
using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.VtkModule.ViewModels
{
    public class SceneViewModel : BaseViewModel
    {
        public SceneViewModel(IContainerExtension container, IEventAggregator eventAggregator) : base(container, eventAggregator)
        {
        }
    }
}
