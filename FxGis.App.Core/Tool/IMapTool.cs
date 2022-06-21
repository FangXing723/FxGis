using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.App.Core.Tool
{
    /// <summary>
    /// 二维地图工具
    /// </summary>
    public interface IMapTool
    {
        string AddShp(string filePath, string layerName = "");




        bool ExistLayer(string layerName);

        bool RemoveLayer(string layerName);

        void SetLayerVisible(string layerName);

        void GetLayerIndex(string layerName);

        void MoveLayer(int index);

        void MoveLayerUp();

        void MoveLayerDown();

        void ZoomToLayer(string layerName);

        void ZoomToFull();

    }
}
