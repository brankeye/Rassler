using Atlas.Forms;
using Atlas.Forms.Interfaces;
using Atlas.Forms.Services;
using Newtonsoft.Json;
using rassler.frontend.core.Domain.Objects;
using rassler.frontend.core.Domain.Services.Cache;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace rassler.frontend.core.Phone
{
    public partial class App : AtlasApplication
    {
        public App()
        {
            InitializeComponent();
            LoadUserContext();
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

        protected void LaunchLoginPage()
        {
            NavigationService.SetMainPage(Nav.Get<Views.Pages.Login>().AsNavigationPage().Info());
        }

        protected void LaunchDashboardPage()
        {
            NavigationService.SetMainPage(Nav.Get<Views.Pages.Dashboard>().Info());
        }

        protected void LoadUserContext()
        {
            object contextObject;
            Current.Properties.TryGetValue("Context", out contextObject);
            UserContext userContext = null;
            if (contextObject != null)
            {
                userContext = JsonConvert.DeserializeObject<UserContext>((string)contextObject);
            }
            userContext = userContext ?? new UserContext();
            UserContextCache.Current.Replace("Context", userContext);
        }

        protected void SaveUserContext()
        {
            var userContext = UserContextCache.Current.Get("Context");
            Current.Properties["Context"] = JsonConvert.SerializeObject(userContext);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var userContext = UserContextCache.Current.Get("Context");
            if (userContext != null && userContext.IsAuthenticated)
            {
                LaunchDashboardPage();
            }
            else
            {
                LaunchLoginPage();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            SaveUserContext();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
