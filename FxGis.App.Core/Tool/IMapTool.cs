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

        string AddTile(string tileName);

        bool ExistLayer(string layerName);

        bool RemoveLayer(string layerName);

        int GetLayerIndex(string layerName);

        void MoveLayerUp(string layerName);

        void MoveLayerDown(string layerName);

        void ZoomToLayer(string layerName);

        void ZoomToFull();

    }
}
