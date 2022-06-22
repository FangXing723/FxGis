using BruTile.Predefined;
using FxGis.App.Core.Tool;
using FxGis.MapsuiModule.Model;
using FxGis.MapsuiModule.Tool;
using Mapsui.UI.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.MapsuiModule.ViewModels
{
    public class MapTreeViewModel : BaseViewModel
    {
        public ObservableCollection<LayerInfo> LayerInfos { get; set; } = new ObservableCollection<LayerInfo>();

        public Array TileLayers => Enum.GetValues(typeof(KnownTileSource));

        public KnownTileSource SelectedTileLayer { get; set; }

        public MapTreeViewModel(IContainerExtension container, IEventAggregator eventAggregator) : base(container, eventAggregator)
        {
            LayerInfos = ((MapToolImpl)MapTool).LayerInfos;

            AddTileCommand = new DelegateCommand(() => AddTile());
            ZoomToLayerCommand = new DelegateCommand<LayerInfo>((layerInfo) => ZoomToLayer(layerInfo));
            MoveLayerUpCommand = new DelegateCommand<LayerInfo>((layerInfo) => MoveLayerUp(layerInfo));
            MoveLayerDownCommand = new DelegateCommand<LayerInfo>((layerInfo) => MoveLayerDown(layerInfo));
            RemoveLayerCommand = new DelegateCommand<LayerInfo>((layerInfo) => RemoveLayer(layerInfo));
        }

        public DelegateCommand AddTileCommand { get; set; }
        public DelegateCommand<LayerInfo> ZoomToLayerCommand { get; set; }
        public DelegateCommand<LayerInfo> MoveLayerUpCommand { get; set; }
        public DelegateCommand<LayerInfo> MoveLayerDownCommand { get; set; }
        public DelegateCommand<LayerInfo> RemoveLayerCommand { get; set; }

        private void AddTile()
        {
            MapTool.AddTile(SelectedTileLayer.ToString());
        }
        private void ZoomToLayer(LayerInfo layerInfo)
        {
            MapTool.ZoomToLayer(layerInfo.LayerName);
        }
        private void MoveLayerUp(LayerInfo layerinfo)
        {
            MapTool.MoveLayerUp(layerinfo.LayerName);
        }
        private void MoveLayerDown(LayerInfo layerinfo)
        {
            MapTool.MoveLayerDown(layerinfo.LayerName);
        }
        private void RemoveLayer(LayerInfo layerinfo)
        {
            MapTool.RemoveLayer(layerinfo.LayerName);
        }
    }
}