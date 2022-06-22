using FxGis.App.Core.Tool;
using FxGis.ProjectTreeModule.Model;
using FxGis.ProjectTreeModule.Tool;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using F = System.Windows.Forms;


namespace FxGis.ProjectTreeModule.ViewModels
{
    public class ProjectTreeViewModel : BaseViewModel
    {
        public Project Project { get; set; } = new Project();


        public ProjectTreeViewModel(IContainerExtension container, IEventAggregator eventAggregator) : base(container, eventAggregator)
        {
            _eventAggregator.GetEvent<TreeProjectPubSubEvent>().Publish(Project);

            InitCommand();

        }


        private void InitCommand()
        {
            AddShpCommand = new DelegateCommand(() => AddShp());
            AddDEMCommand = new DelegateCommand(() => AddDEM());
            ViewInMapCommand = new DelegateCommand<BaseProjectData>((data) => ViewInMap(data));
            RemoveCommand = new DelegateCommand<BaseProjectData>((data) => Remove(data));
        }


        public DelegateCommand AddShpCommand { get; set; }
        public DelegateCommand AddDEMCommand { get; set; }
        public DelegateCommand<BaseProjectData> ViewInMapCommand { get; set; }
        public DelegateCommand<BaseProjectData> RemoveCommand { get; set; }
        private void AddShp()
        {
            F.OpenFileDialog ofd = new F.OpenFileDialog
            {
                Filter = ShpData.FileFilter,
            };
            if (ofd.ShowDialog() != F.DialogResult.OK)
            { return; }

            var layerName = MapTool.AddShp(ofd.FileName, "");
            TreeTool.AddShp(ofd.FileName, layerName);
        }
        private void AddDEM()
        {
            TreeTool.AddDEM("");
        }
        private void ViewInMap(BaseProjectData data)
        {
            if (MapTool.ExistLayer(data.DataName))
            {
                MapTool.ZoomToLayer(data.DataName);
            }
            else
            {
                MapTool.AddShp(data.DataPath, data.DataName);
            }
        }
        private void Remove(BaseProjectData data)
        {
            MapTool.RemoveLayer(data.DataName);
            TreeTool.RemoveData(data.DataName);
        }
    }
}
