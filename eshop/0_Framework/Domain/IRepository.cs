using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    public interface IRepository<Tkey, T> where T : class
    {
        T Get(Tkey id);
        List<T> Get();
        void Create(T en);
        void Save();
        bool Exists(Expression<Func<T, bool>> expression);


    }
}
