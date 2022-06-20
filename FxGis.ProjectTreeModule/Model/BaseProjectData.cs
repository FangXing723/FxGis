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

        public abstract ProjectDataTypeEnum DataType { get; }

        /// <summary>
        /// 是否勾选
        /// </summary>
        public virtual bool IsChecked { get; set; }

        /// <summary>
        /// IsChecked属性改变事件
        /// </summary>
        public event EventHandler<BaseProjectData> CheckedChanged;




    }
}
