using AlazomEstoque.Core.Domain.Model;
using AlazomEstoque.Infra.Interface;
using AlazomEstoque.Infra.Servico;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlazomEstoque.Infra.Repository
{
    public class EstqAberturaRepository : IEstoqueAbertura
    {
        public void AdicionarQtd(EstoqueAbertura estoqueAbertura)
        {
            try
            {
                using (ServicoRepository<EstoqueAbertura> rep = new ServicoRepository<EstoqueAbertura>())
                {
                    rep.Update(estoqueAbertura);
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public EstoqueAbertura BuscarQtdDia()
        {
            try
            {
                using (ServicoRepository<EstoqueAbertura> rep = new ServicoRepository<EstoqueAbertura>())
                {
                    return rep.List().FirstOrDefault();
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }
    }
}
