using AlazomEstoque.Core.Domain.Model;
using System.Threading.Tasks;

namespace AlazomEstoque.Infra.Interface
{
    public interface ICadFornecedor
    {
        bool CadastrarForn(CadastroFornecedor cadFornecedor);
    }
}
