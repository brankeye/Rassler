using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlas.Forms.Interfaces.Pages;
using Atlas.Forms.Interfaces.Services;
using Atlas.Forms.Services;
using rassler.frontend.core.Phone.ViewModels;
using Xamarin.Forms;

namespace rassler.frontend.core.Phone.Views.Pages
{
    public partial class Dashboard : MasterDetailPage, IInitializeAware
    {
        private ViewModels.Pages.Dashboard ViewModel => _vm ?? (_vm = BindingContext as ViewModels.Pages.Dashboard);
        private ViewModels.Pages.Dashboard _vm;

        public Dashboard()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Pages.Dashboard();
            MasterListView.ItemsSource = ViewModel.DashboardItems;
            MasterListView.ItemSelected += MasterListView_OnItemSelected;
            
        }

        public void Initialize(IParametersService parameters)
        {
            var firstItem = MasterListView.ItemsSource.Cast<DashboardItem>().FirstOrDefault();
            MasterListView.SelectedItem = firstItem;
        }

        private void MasterListView_OnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            var dashboardItem = (DashboardItem) selectedItemChangedEventArgs.SelectedItem;
            ViewModel.PresentPage(dashboardItem.NavigationInfo);
            IsPresented = false;
        }
    }
}
