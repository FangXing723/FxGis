using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.App.Core.Tool
{
    public interface ITreeTool
    {
        string AddShp(string shpPath, string dataName);

        string AddDEM(string demDataPath);

        string AddTile(string tileDataPath);

        string MoveDataUp(string dataName);

        string MoveDataDown(string dataName);

        bool RemoveData(string dataName);
        
    }
}
