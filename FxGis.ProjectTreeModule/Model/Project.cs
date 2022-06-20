using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.ProjectTreeModule.Model
{
   public class Project
    {

        public ObservableCollection<BaseProjectData> ProjectDatas { get; set; } = new ObservableCollection<BaseProjectData>();

    }
}
