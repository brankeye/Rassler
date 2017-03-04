using Atlas.Forms;
using Atlas.Forms.Interfaces;
using Atlas.Forms.Services;
using Xamarin.Forms;

namespace rassler.frontend.core.Phone
{
    public partial class App : AtlasApplication
    {
        public App()
        {
            InitializeComponent();
            NavigationService.SetMainPage(Nav.Get<Views.Pages.Login>().AsNavigationPage().Info());
        }

        protected override void RegisterPagesForNavigation(IPageNavigationRegistry registry)
        {
            registry.RegisterPage<NavigationPage>();
            registry.RegisterPage<Views.Pages.Login, ViewModels.Pages.Login>();
            registry.RegisterPage<Views.Pages.Dashboard, ViewModels.Pages.Dashboard>();
            registry.RegisterPage<Views.Pages.Details.Profile, ViewModels.Pages.Details.Profile>();
            registry.RegisterPage<Views.Pages.MyClasses, ViewModels.Pages.MyClasses>();
            registry.RegisterPage<Views.Pages.Schedule, ViewModels.Pages.Schedule>();
        }

        protected override void RegisterPagesForCaching(IPageCacheRegistry registry)
        {

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
