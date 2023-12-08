using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Persistence
{
    public interface ICacheService<T>
    {
        T Get(string key);
        List<T> GetCollection(string key);
        void Set(string key, T value, TimeSpan timeSpan);

        void Set(string key, List<T> values, TimeSpan timeSpan);

        void Delete(string key);
    }
}
