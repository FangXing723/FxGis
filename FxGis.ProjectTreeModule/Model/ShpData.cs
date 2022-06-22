using FxGis.ProjectTreeModule.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.ProjectTreeModule.Model
{
    public class ShpData : BaseProjectData
    {
        public const string FileFilter = "shape files(*.shp)|*.shp";

        public override string ImagePath => "/FxGis.ProjectTreeModule;component/Images/Shp数据.png";

        public override ProjectDataTypeEnum DataType => ProjectDataTypeEnum.SHAPE;

   
    }
}
