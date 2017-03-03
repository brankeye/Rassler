using System;
using rassler.frontend.core.Domain.Interfaces;
using rassler.frontend.core.Domain.Objects;
using rassler.frontend.core.Domain.Services.Cache.Base;

namespace rassler.frontend.core.Domain.Services.Cache
{
    public class UserContextCache : DataStore<UserContext>
    {
        private static readonly Lazy<IDataStore<UserContext>> _lazy;

        public static IDataStore<UserContext> Current => _lazy.Value;

        static UserContextCache()
        {
            _lazy = new Lazy<IDataStore<UserContext>>(() => new UserContextCache());
        }

        private UserContextCache() { }
    }
}
