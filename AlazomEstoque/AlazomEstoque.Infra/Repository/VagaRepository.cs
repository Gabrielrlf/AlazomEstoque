using AlazomEstoque.Core.Domain.Model;
using AlazomEstoque.Infra.Interface;
using AlazomEstoque.Infra.Servico;
using AlazomEstoque.Infra.Servico.Interface;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlazomEstoque.Infra.Repository
{
    public class VagaRepository : IVagaRepository
    {

        public EstoqueVagas BuscarEstoqueVagas()
        {
            try
            {
                using (ServicoRepository<EstoqueVagas> rep = new ServicoRepository<EstoqueVagas>())
                {

                    return rep.List().FirstOrDefault();
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }
        public void AlterarQuantidadeVaga(EstoqueVagas estoqueVagas)
        {
            using (ServicoRepository<EstoqueVagas> rep = new ServicoRepository<EstoqueVagas>())
            {
   
                rep.Update(estoqueVagas);
            }
        }
    }
}
