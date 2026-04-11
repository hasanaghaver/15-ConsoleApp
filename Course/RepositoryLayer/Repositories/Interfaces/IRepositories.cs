using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    interface IRepositories<T>
    {
        void Create(T data);
        void Update(int id, T data);
        void Delete(T data);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}
