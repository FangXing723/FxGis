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

        bool RemoveData(string dataName);
        
    }
}
