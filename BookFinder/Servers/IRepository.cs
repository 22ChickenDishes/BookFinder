using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Servers
{
    public interface IRepository<T>
    {
        T GetValue(int id);

        IEnumerable<T> GetAll();

        T Update(T t);

        T Create(T t);

        T Delete(int id);
    }
}
