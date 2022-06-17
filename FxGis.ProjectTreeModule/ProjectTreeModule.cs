using FxGis.ProjectTreeModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FxGis.ProjectTreeModule
{
    public class ProjectTreeModule : IModule
    {
        public static string RegionName = "ProjectTreeRegion";

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionName, typeof(ProjectTreeView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
