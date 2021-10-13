using AlazomEstoque.Infra.Servico.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlazomEstoque.Infra.Servico
{
    public class ServicoRepository<T> : IDisposable, IServico<T> where T : class
    {
        protected readonly AppDbContext dbContext = new AppDbContext();
        public void Create(T obj)
        {
            dbContext.Set<T>().Add(obj);

            dbContext.SaveChanges();
           
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public IQueryable<T> List()
        {
            return dbContext.Set<T>();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;

            dbContext.SaveChanges();
        }
    }
}
