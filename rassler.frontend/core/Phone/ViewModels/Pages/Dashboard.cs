using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlas.Forms.Infos;
using Atlas.Forms.Interfaces.Managers;
using Atlas.Forms.Interfaces.Pages;
using Atlas.Forms.Interfaces.Services;
using Atlas.Forms.Services;

namespace rassler.frontend.core.Phone.ViewModels.Pages
{
    public class Dashboard : Base.Core, IMasterDetailPageProvider
    {
        public Dashboard()
        {
            DashboardItems = CreateDashboardItems();
        }

        public void PresentPage(NavigationInfo navigationInfo)
        {
            PageManager.PresentPage(navigationInfo);
        }

        private IList<DashboardItem> CreateDashboardItems()
        {
            var dashboardItems = new List<DashboardItem>
            {
                new DashboardItem
                {
                    Title = "My profile",
                    NavigationInfo = Nav.Get<ViewModels.Pages.Details.Profile>().AsNavigationPage().Info()
                },
                new DashboardItem
                {
                    Title = "My classes",
                    NavigationInfo = Nav.Get<ViewModels.Pages.MyClasses>().AsNavigationPage().Info()
                },
                new DashboardItem
                {
                    Title = "Schedule",
                    NavigationInfo = Nav.Get<ViewModels.Pages.Schedule>().AsNavigationPage().Info()
                }
            };
            return dashboardItems;
        }

        public IList<DashboardItem> DashboardItems { get; set; }

        public IMasterDetailPageManager PageManager { get; set; }
    }
}
