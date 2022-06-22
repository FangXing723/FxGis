using FxGis.App.Core.Tool;
using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.MapsuiModule.ViewModels
{
    public class MapToolViewModel : BaseViewModel
    {
        public MapToolViewModel(IContainerExtension container, IEventAggregator eventAggregator) : base(container, eventAggregator)
        {
        }
    }
}
