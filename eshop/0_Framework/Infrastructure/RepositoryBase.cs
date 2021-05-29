using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public class RepositoryBase<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Create(T en)
        {
            _context.Add(en);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(Tkey id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();

        }
    }
}
