using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace rassler.frontend.core.Phone.Views.Pages
{
    public partial class Schedule : ContentPage
    {
        private ViewModels.Pages.Schedule ViewModel => _vm ?? (_vm = BindingContext as ViewModels.Pages.Schedule);
        private ViewModels.Pages.Schedule _vm;

        public Schedule()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Pages.Schedule();
        }
    }
}
