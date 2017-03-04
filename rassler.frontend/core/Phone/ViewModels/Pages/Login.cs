using System;
using System.Windows.Input;
using Atlas.Forms.Interfaces;
using Atlas.Forms.Interfaces.Services;
using Atlas.Forms.Services;
using Xamarin.Forms;

namespace rassler.frontend.core.Phone.ViewModels.Pages
{
    public class Login : INavigationServiceProvider
    {
        private void LoginOrRegister()
        {
            if (IsNewUser)
            {
                HandleRegister();
            }
            else
            {
                HandleLogin();
            }
        }

        private void HandleRegister()
        {

        }

        private void HandleLogin()
        {
            NavigationService.SetMainPage(Nav.Get<ViewModels.Pages.Dashboard>().Info());
        }

        public bool IsNewUser { get; set; }

        public INavigationService NavigationService { get; set; }

        public ICommand ActionButtonCommand => _actionButtonCommand ?? (_actionButtonCommand = new Command(LoginOrRegister));
        private ICommand _actionButtonCommand;
    }
}
