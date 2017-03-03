using System.Collections.Generic;
using rassler.frontend.core.Domain.Interfaces;

namespace rassler.frontend.core.Domain.Services.Cache.Base
{
    public class DataStore<T> : IDataStore<T>
    {
        protected IDictionary<string, T> Store { get; set; } = new Dictionary<string, T>();

        protected readonly object _mutex = new object();

        public virtual void Replace(string key, T value)
        {
            lock (_mutex)
            {
                Remove(key);
                Add(key, value);
            }
        }

        public virtual bool Add(string key, T value)
        {
            lock (_mutex)
            {
                if (!Store.ContainsKey(key))
                {
                    Store.Add(key, value);
                    return true;
                }
            }
            return false;
        }

        public virtual bool Remove(string key)
        {
            return Store.Remove(key);
        }

        public virtual bool Contains(string key)
        {
            lock (_mutex)
            {
                return Store.ContainsKey(key);
            }
        }

        public virtual T Get(string key)
        {
            T value;
            Store.TryGetValue(key, out value);
            return value;
        }

        public virtual void Clear()
        {
            lock (_mutex)
            {
                Store.Clear();
            }
        }

        public virtual ICollection<string> GetKeys()
        {
            return Store.Keys;
        }

        public virtual ICollection<T> GetValues()
        {
            return Store.Values;
        }
    }
}
