using AlazomEstoque.Core.Domain.Model;
using AlazomEstoque.Infra.Interface;
using AlazomEstoque.Infra.Repository;
using AlazomEstoque.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AlazomEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly ICadFornecedor _cadFornecedor;
        private readonly IEstoqueAbertura _estoqueAbertura;
        public HomeController(IVagaRepository vagaRepository, ICadFornecedor cadFornecedor, IEstoqueAbertura estoqueAbertura)
        {
            _vagaRepository = vagaRepository;
            _cadFornecedor = cadFornecedor;
            _estoqueAbertura = estoqueAbertura;
        }


        [HttpPost, Route("AlterarVaga/{ativo}")]
        public IActionResult AlterarVagas(bool ativo)
        {
            try
            {
                if(!(DateTime.Now.Hour >= 08 && DateTime.Now.Hour <= 12 || DateTime.Now.Hour >= 14 && DateTime.Now.Hour <= 18))
                {
                    return BadRequest(new JsonResult("O horário permitido é de 8 ás 12 ou 14 ás 18!"));
                }

                EstoqueAbertura estoqueAbertura = _estoqueAbertura.BuscarQtdDia();
                if(estoqueAbertura.QtdDia >= 12)
                {
                    return BadRequest(new JsonResult("Quantidade diária de recebimento já batida!"));
                }

                estoqueAbertura.QtdDia += 1;
                _estoqueAbertura.AdicionarQtd(estoqueAbertura);

                EstoqueVagas est = _vagaRepository.BuscarEstoqueVagas();
                if (est.QtdAtual >= 3 && est.QtdAtual >= 0 && ativo.Equals(true) || new HorasSK().CalcularHoras(est.UltimaData).TotalMinutes <= 30)
                {
                    return BadRequest(new JsonResult("Sem vaga restante ou aguarde 30 minutos!"));
                }

                est.UltimaData = DateTime.Now;
                est.QtdAtual = ativo ? est.QtdAtual += 1 : est.QtdAtual -= 1;


                _vagaRepository.AlterarQuantidadeVaga(est);
                return Ok(new JsonResult(est) { StatusCode = 200, ContentType = "json/application", Value = est });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost, Route("EnviarInfoForn")]
        public IActionResult EnviarInfoFornecedor([FromBody] CadastroFornecedor cadForn)
        {
            try
            {
                cadForn.HorarioEntrada = DateTime.Now;

                bool cadastrado = _cadFornecedor.CadastrarForn(cadForn);
                return Ok(new JsonResult(cadForn.Placa) { StatusCode = 200, 
                    ContentType = "json/application",
                    Value = $"Carreta de placa {cadForn.Placa} cadastrada \n com entrada {cadForn.HorarioEntrada}!" });
            }
            catch
            {
                throw;
            }
        }
    }
}
