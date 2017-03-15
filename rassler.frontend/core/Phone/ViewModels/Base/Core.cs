using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using inpce.core.Library.Extensions;
using rassler.frontend.core.Domain.Objects;
using rassler.frontend.core.Domain.Services.Cache;

namespace rassler.frontend.core.Phone.ViewModels.Base
{
    public abstract class Core : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Domain.Objects.UserContext GetUserContext()
        {
            var currentContext = UserContextCache.Current.Get("Context");
            return currentContext;
        }

        public void SaveUserContext(UserContext context)
        {
            UserContextCache.Current.Replace("Context", context);
        }

        public void SetProperty<T>(ref T prop, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            this.SetProperty(ref prop, value, PropertyChanged, propertyName, onChanged);
        }

        public void SetPropertyAlways<T>(ref T prop, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            this.SetPropertyAlways(ref prop, value, PropertyChanged, propertyName, onChanged);
        }
    }
}
