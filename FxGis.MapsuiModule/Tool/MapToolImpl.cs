using FxGis.App.Core.Tool;
using Mapsui.UI.Wpf;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.MapsuiModule.Tool
{
    public class MapToolImpl : IMapTool
    {
        internal MapControl _mapControl;

        public MapToolImpl(IEventAggregator ea)
        {
            //通过Prism的订阅发布机制，完成MapControl（代操作对象）的注入
            ea.GetEvent<MapPubSubEvent>().Subscribe((mapControl) => { _mapControl = mapControl; });
        }

        public void AddShapeFile(string filePath)
        {
            System.Diagnostics.Debug.WriteLine($"MapToolImpl.AddShapeFile({filePath})");
        }

        public bool ExistLayer(string layerName)
        {
            throw new NotImplementedException();
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
            if(_mapControl==null)
            {
                System.Diagnostics.Debug.WriteLine("MapControl为空!");

                return false;
            }
            else
            {
                _mapControl.Map.Layers.Remove(l => l.Name == layerName);
            }

            return true;
        }

        public void SetLayerVisible(string layerName)
        {
            throw new NotImplementedException();
        }
    }
}
