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
                IsChecked = true,
            };

            _project.ProjectDatas.Add(dem);

            return dem.DataName;
        }

        public string AddShp(string shpDataPath)
        {
            ShpData shp = new ShpData
            {
                DataName = "SHP数据",
                DataPath = "/xxx/a.shp",
                IsChecked = true,
            };

            _project.ProjectDatas.Add(shp);

            return shp.DataName;
        }

        public string AddTile(string tileDataPath)
        {
            TileData tile = new TileData
            {
                DataName = "Tile数据",
                DataPath = "/xxx/b.tile",
                IsChecked = true,
            };

            _project.ProjectDatas.Add(tile);

            return tile.DataName;
        }

        public string MoveDataDown(string dataName)
        {
            throw new NotImplementedException();
        }

        public string MoveDataUp(string dataName)
        {
            throw new NotImplementedException();
        }

        public bool RemoveData(string dataName)
        {
           return _project.ProjectDatas.Remove(_project.ProjectDatas.Where(d => d.DataName == dataName).First());
        }
    }
}
