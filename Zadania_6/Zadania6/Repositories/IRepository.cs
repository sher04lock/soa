using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        int Add(TEntity value);
        bool Delete(int id);
        TEntity Get(int id);
        List<TEntity> GetAll();
        bool Update(TEntity value);
    }
}
