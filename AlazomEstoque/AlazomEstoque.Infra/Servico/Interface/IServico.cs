using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlazomEstoque.Infra.Servico.Interface
{
    public interface IServico<T> where T : class
    {
        IQueryable<T> List();
        void Create(T obj);
        void Update(T obj);
    }
}
