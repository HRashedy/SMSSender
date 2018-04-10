using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.Tree.Repositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> Get();
        T Get(string id);
        void Create(T data);
        void Update(T data);
        void Delete(string id);
        bool Exists(string id);
    }
}
