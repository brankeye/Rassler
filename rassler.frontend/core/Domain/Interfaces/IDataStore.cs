using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rassler.frontend.core.Domain.Interfaces
{
    public interface IDataStore<T>
    {
        void Replace(string key, T value);

        bool Add(string key, T value);

        bool Remove(string key);

        bool Contains(string key);

        T Get(string key);

        void Clear();

        ICollection<string> GetKeys();

        ICollection<T> GetValues();
    }
}
