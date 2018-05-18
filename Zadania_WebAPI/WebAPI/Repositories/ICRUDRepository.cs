using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICRUDRepository<T>
    {
        int Add(T value);
        bool Delete(int id);
        T Get(int id);
        List<T> GetAll();
        T Update(T value);
    }
}
