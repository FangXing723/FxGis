using FxGis.ProjectTreeModule.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.ProjectTreeModule.Model
{
    public class DemData : BaseProjectData
    {
        public override ProjectDataTypeEnum DataType => ProjectDataTypeEnum.DEM;
    }
}
