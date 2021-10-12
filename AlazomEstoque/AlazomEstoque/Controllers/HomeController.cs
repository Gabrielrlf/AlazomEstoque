using AlazomEstoque.Core.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace AlazomEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost, Route("AlterarQtdVaga")]
        public IActionResult AlterarQtdVaga([FromBody] EstoqueVagas estoqueVagas)
        {
            return Ok();
        }

    }
}
