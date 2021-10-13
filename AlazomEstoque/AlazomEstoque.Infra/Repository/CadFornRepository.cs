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
    public class CadFornRepository : ICadFornecedor
    {
        public bool CadastrarForn(CadastroFornecedor cadFornecedor)
        {
            try
            {
                using (ServicoRepository<CadastroFornecedor> rep = new ServicoRepository<CadastroFornecedor>())
                {
                    rep.Create(cadFornecedor);
                    return true;
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }
    }
}
