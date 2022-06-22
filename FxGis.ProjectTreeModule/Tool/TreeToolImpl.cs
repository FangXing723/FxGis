using FxGis.App.Core.Tool;
using FxGis.ProjectTreeModule.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.ProjectTreeModule.Tool
{
    public class TreeToolImpl : ITreeTool
    {
        internal Project _project;

        public TreeToolImpl(IEventAggregator ea)
        {
            //通过Prism的订阅发布机制，完成MapControl（代操作对象）的注入
            ea.GetEvent<TreeProjectPubSubEvent>().Subscribe((project) => { _project = project; });
        }


        public string AddDEM(string demDataPath)
        {
            DemData dem = new DemData
            {
                DataName = "DEM数据",
                DataPath = "/xxx/a.dem",
            };

            _project.ProjectDatas.Add(dem);

            return dem.DataName;
        }

        public string AddShp(string shpPath, string dataName)
        {
            ShpData shp = new ShpData
            {
                DataName = dataName,
                DataPath = shpPath,
            };

            _project.ProjectDatas.Add(shp);

            return shp.DataName;
        }


        public bool RemoveData(string dataName)
        {
            return _project.ProjectDatas.Remove(_project.ProjectDatas.Where(d => d.DataName == dataName).First());
        }
    }
}
