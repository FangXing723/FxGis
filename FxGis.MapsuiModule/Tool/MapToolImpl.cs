using FxGis.App.Core.Tool;
using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Providers.Shapefile;
using Mapsui.UI.Wpf;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FxGis.MapsuiModule.Tool
{
    public class MapToolImpl : IMapTool
    {
        internal MapControl _mapControl;
        internal LayerCollection _layers => _mapControl?.Map?.Layers;


        public MapToolImpl(IEventAggregator ea)
        {
            //通过Prism的订阅发布机制，完成MapControl（代操作对象）的注入
            ea.GetEvent<MapPubSubEvent>().Subscribe((mapControl) => { _mapControl = mapControl; });
        }

        public string AddShp(string filePath, string layerName = "")
        {
            //System.Diagnostics.Debug.WriteLine($"MapToolImpl.AddShapeFile({filePath})");

            if (!File.Exists(filePath))
            { throw new Exception($"shp文件不存在：{filePath}"); }

            if (string.IsNullOrEmpty(layerName))
            { layerName = Path.GetFileNameWithoutExtension(filePath); }

            if (ExistLayer(layerName))
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

        public bool ExistLayer(string layerName)
        {
            if (_layers.FindLayer(layerName).Count() > 0)
            {
                return true;
            }

            return false;
        }

        public void GetLayerIndex(string layerName)
        {
            throw new NotImplementedException();
        }

        public void MoveLayer(int index)
        {
            throw new NotImplementedException();
        }

        public void MoveLayerDown()
        {
            throw new NotImplementedException();
        }

        public void MoveLayerUp()
        {
            throw new NotImplementedException();
        }

        public bool RemoveLayer(string layerName)
        {
            return _mapControl.Map.Layers.Remove(l => l.Name == layerName);
        }

        public void SetLayerVisible(string layerName)
        {
            throw new NotImplementedException();
        }

        public void ZoomToLayer(string layerName)
        {
            ILayer layer = _layers.FindLayer(layerName).First();
            if (layer==null)
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
