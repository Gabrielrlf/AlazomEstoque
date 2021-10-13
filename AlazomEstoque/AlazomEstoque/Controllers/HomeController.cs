using AlazomEstoque.Core.Domain.Model;
using AlazomEstoque.Infra.Interface;
using AlazomEstoque.Infra.Repository;
using AlazomEstoque.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AlazomEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IVagaRepository _vagaRepository;
        public HomeController(IVagaRepository vagaRepository)
        {
            _vagaRepository = vagaRepository;
        }


        [HttpPost, Route("AlterarVaga/{ativo}")]
        public IActionResult AlterarVagas(bool ativo)
        {
            try
            {
                EstoqueVagas est = _vagaRepository.BuscarEstoqueVagas();
                if (est.QtdAtual >= 3 && est.QtdAtual >= 0  && ativo.Equals(true) || new HorasSK().CalcularHoras(est.UltimaData).TotalMinutes <= 30) { return BadRequest(new JsonResult("Sem vaga restante ou aguarde 30 minutos!")); }

                est.UltimaData = DateTime.Now;
                est.QtdAtual = ativo ? est.QtdAtual += 1 : est.QtdAtual -= 1;

                _vagaRepository.AlterarQuantidadeVaga(est);
                return Ok(new JsonResult(est));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
