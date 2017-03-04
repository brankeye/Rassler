using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace rassler.frontend.core.Phone.Views.Pages
{
    public partial class Login : ContentPage
    {
        public ViewModels.Pages.Login ViewModel => _vm ?? (_vm = BindingContext as ViewModels.Pages.Login);
        private ViewModels.Pages.Login _vm;

        public Login()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Pages.Login();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void NewUserSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            LoginRegisterButton.Text = e.Value ? "Register" : "Login";
        }

        private void PasswordVisibility_OnClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
            var visible = "ic_visibility_white_24dp.png";
            var notVisible = "ic_visibility_off_white_24dp.png";
            button.Image = PasswordEntry.IsPassword ? notVisible : visible;
        }
    }
}
