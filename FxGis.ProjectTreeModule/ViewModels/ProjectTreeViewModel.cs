﻿using FxGis.App.Core.Tool;
using FxGis.ProjectTreeModule.Model;
using FxGis.ProjectTreeModule.Tool;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

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
            ProjectTreeTestCommand = new DelegateCommand(() => ProjectTreeTest());
            AddShpCommand = new DelegateCommand(() => AddShp());
            AddDEMCommand = new DelegateCommand(() => AddDEM());
            AddTileCommand = new DelegateCommand(() => AddTile());
        }


        public DelegateCommand ProjectTreeTestCommand { get; set; }
        public DelegateCommand AddShpCommand { get; set; }
        public DelegateCommand AddDEMCommand { get; set; }
        public DelegateCommand AddTileCommand { get; set; }

        private void ProjectTreeTest()
        {
            if (MapTool != null)
            {
                MapTool.AddShapeFile("");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("_mapTool 未获取");
            }
        }

        private void AddShp()
        {
            TreeTool.AddShp("");
        }

        private void AddDEM()
        {
            TreeTool.AddDEM("");
        }

        private void AddTile()
        {
            TreeTool.AddTile("");
        }
    }
}
