using FxGis.ProjectTreeModule.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.ProjectTreeModule.Model
{
   public abstract class BaseProjectData
    {

        /// <summary>
        /// 数据名称
        /// </summary>
        public virtual string DataName { get; set; }

        /// <summary>
        /// 数据路径
        /// </summary>
        public virtual string DataPath { get; set; }

        public abstract string ImagePath { get;}

        public abstract ProjectDataTypeEnum DataType { get; }
    }
}
