using FxGis.App.Core.Tool;
using Prism.Commands;
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
            ZoomInCommand = new DelegateCommand(() => MapTool.ZoomIn());
            ZoomOutCommand = new DelegateCommand(() => MapTool.ZoomOut());
            ZoomToFullCommand = new DelegateCommand(() => MapTool.ZoomToFull());
        }


        public DelegateCommand ZoomInCommand { get; set; }
        public DelegateCommand ZoomOutCommand { get; set; }
        public DelegateCommand ZoomToFullCommand { get; set; }

    }
}
