using BruTile.Predefined;
using FxGis.App.Core.Tool;
using FxGis.MapsuiModule.Model;
using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Providers.Shapefile;
using Mapsui.UI.Wpf;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace FxGis.MapsuiModule.Tool
{
    public class MapToolImpl : IMapTool
    {
        internal MapControl _mapControl;
        internal LayerCollection _layers => _mapControl?.Map?.Layers;


        internal ObservableCollection<LayerInfo> LayerInfos { get; set; } = new ObservableCollection<LayerInfo>();

        public MapToolImpl(IEventAggregator ea)
        {
            //通过Prism的订阅发布机制，完成MapControl（代操作对象）的注入
            ea.GetEvent<MapPubSubEvent>().Subscribe((mapControl) =>
            {
                _mapControl = mapControl;
                _layers.LayerAdded += _layers_LayerAdded;
                _layers.LayerRemoved += _layers_LayerRemoved;
            });

        }






        public string AddShp(string filePath, string layerName = "")
        {
            //System.Diagnostics.Debug.WriteLine($"MapToolImpl.AddShapeFile({filePath})");

            if (!File.Exists(filePath))
            { throw new Exception($"shp文件不存在：{filePath}"); }

            if (string.IsNullOrEmpty(layerName))
            { layerName = Path.GetFileNameWithoutExtension(filePath); }

            while (ExistLayer(layerName))
            {
                layerName += "_副本";
            }

            IProvider provider = new ShapeFile(filePath);
            ILayer layer = new Layer()
            {
                Name = layerName,
                DataSource = provider,
            };

            _layers.Add(layer);

            return layerName;
        }

        public string AddTile(string tileName)
        {
            KnownTileSource source;
            try
            {
                source=(KnownTileSource)Enum.Parse(typeof(KnownTileSource), tileName);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"MapToolImpl.AddTile(string tileName)----tileName：{tileName}转枚举失败，不在{Enum.GetValues(typeof(KnownTileSource))}中:");

                return "";
            }

            string name = source.ToString();
            while (ExistLayer(name))
            {
                name += "_副本";
            }


            string apiKey = "apiKey";
            ILayer tileLayer = new TileLayer(
                KnownTileSources.Create(source, apiKey),
                dataFetchStrategy: new Mapsui.Fetcher.DataFetchStrategy())
            { Name = name };

            _layers.Add(tileLayer);

            return name;

        }

        public bool ExistLayer(string layerName)
        {
            if (_layers.FindLayer(layerName).Count() > 0)
            {
                return true;
            }

            return false;
        }

        public bool RemoveLayer(string layerName)
        {
            return _mapControl.Map.Layers.Remove(l => l.Name == layerName);
        }

        public int GetLayerIndex(string layerName)
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                if (_layers[i].Name == layerName)
                    return i;
            }

            return -1;
        }

        public void MoveLayerUp(string layerName)
        {
            ILayer layer = GetLayer(layerName);
            if (layer == null) return;

            int curIndex = GetLayerIndex(layerName);
            if (curIndex > 0)
            {
                // Map图层集合中移动
                _layers.Move(curIndex - 1, layer);
                //MapTree中绑定的可观察的图层信息集合移动
                LayerInfos.Move(curIndex, curIndex - 1);
            }

        }

        public void MoveLayerDown(string layerName)
        {
            ILayer layer = GetLayer(layerName);
            if (layer == null) return;

            int curIndex = GetLayerIndex(layerName);
            int curLayersCount = _layers.Count;
            if (curLayersCount == -1) { return; } //没找到不用移动
            if (curLayersCount == 1) { return; } //只有一个不用移动
            if (curIndex == curLayersCount - 1) { return; } //最后一个不用移动


            // Map图层集合中移动
            _layers.Move(curIndex + 1, layer);
            //MapTree中绑定的可观察的图层信息集合移动
            LayerInfos.Move(curIndex, curIndex + 1);
        }




        public void SetLayerVisiblity(string layerName, bool visibility)
        {
            ILayer layer = GetLayer(layerName);
            if (layer != null)
            {
                layer.Enabled = visibility;
            }
        }

        public void ZoomToLayer(string layerName)
        {
            ILayer layer = GetLayer(layerName);
            if (layer == null)
            {
                System.Diagnostics.Debug.WriteLine($"{this.GetType()}.ZoomToLayer(string layerName)----未找到:{layerName}");
                return;
            }
            BoundingBox envelop = layer.Envelope;
            ZoomToBoundingBox(envelop);
        }

        public void ZoomToFull()
        {
            BoundingBox mapEnvelope = _mapControl.Map.Envelope;
            ZoomToBoundingBox(mapEnvelope);
        }




        private void _layers_LayerAdded(ILayer layer)
        {

            LayerInfo layerInfo = new LayerInfo()
            {
                Layer = layer,
                LayerName = layer.Name,
                Opacity = layer.Opacity,
                Visibility = layer.Enabled,
            };
            LayerInfos.Add(layerInfo);
        }

        private void _layers_LayerRemoved(ILayer layer)
        {
            int currentLayerCount = _layers.Count;

            //删除的是最后一个，LayerInfos清空即可
            if (currentLayerCount == 0)
            {
                LayerInfos.Clear();
            }
            //不是最后一个，则更新其它位置的序号
            else
            {
                LayerInfo layerInfo = LayerInfos.Where(l => l.LayerName == layer.Name).First();
                LayerInfos.Remove(layerInfo);
            }

        }

        private ILayer GetLayer(string layerName)
        {
            ILayer layer = null;
            layer = _layers.FirstOrDefault(l => l.Name == layerName);
            return layer;
        }


        /// <summary>
        /// 缩放至指定包围盒
        /// </summary>
        /// <param name="boundingBox"></param>
        private void ZoomToBoundingBox(BoundingBox boundingBox)
        {
            Point startPoint = new Point(boundingBox.MinX, boundingBox.MinY);
            Point endPoint = new Point(boundingBox.MaxX, boundingBox.MaxY);

            _mapControl.ZoomToBox(startPoint, endPoint);
        }


    }
}
