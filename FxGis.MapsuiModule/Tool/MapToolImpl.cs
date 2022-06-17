using FxGis.App.Core.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.MapsuiModule.Tool
{
    public class MapToolImpl : IMapTool
    {
        public void AddShapeFile(string filePath)
        {
            System.Diagnostics.Debug.WriteLine($"MapToolImpl.AddShapeFile({filePath})");
        }
    }
}
