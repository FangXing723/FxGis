using FxGis.App.Core.Tool;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.ProjectTreeModule.ViewModels
{
    public class ProjectTreeViewModel : BaseViewModel
    {
        public ProjectTreeViewModel(IContainerExtension container) : base(container)
        {
            RegisterCommand();
        }


        private void RegisterCommand()
        {
            ProjectTreeTestCommand = new DelegateCommand(() => ProjectTreeTest());
        }


        public DelegateCommand ProjectTreeTestCommand { get; set; }

        private void ProjectTreeTest()
        {
            if (_mapTool != null)
            {
                _mapTool.AddShapeFile("");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("_mapTool 未获取");
            }
        }
    }
}
