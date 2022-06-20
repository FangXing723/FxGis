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
        public override ProjectDataTypeEnum DataType => ProjectDataTypeEnum.SHAPE;
    }
}
