using rassler.frontend.core.Domain.Objects;
using rassler.frontend.core.Domain.Services.Cache;

namespace rassler.frontend.core.Phone.ViewModels.Base
{
    public class Core
    {
        public Domain.Objects.UserContext GetUserContext()
        {
            var currentContext = UserContextCache.Current.Get("Context");
            return currentContext;
        }

        public void SaveUserContext(UserContext context)
        {
            UserContextCache.Current.Replace("Context", context);
        }
    }
}
