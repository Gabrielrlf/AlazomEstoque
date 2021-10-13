using AlazomEstoque.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlazomEstoque.Infra.Interface
{
    public interface IVagaRepository
    {
        void AlterarQuantidadeVaga(EstoqueVagas estoqueVagas);
        EstoqueVagas BuscarEstoqueVagas();

    }
}
