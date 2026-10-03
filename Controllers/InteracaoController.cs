using DeskFlowApi.Models;
using DeskFlowApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowApi.Controllers
{
    [ApiController]
    [Route("api/interacoes")]
    public class InteracaoController : ControllerBase
    {
        private readonly InteracaoService _service;

        public InteracaoController(InteracaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var interacao = _service.BuscarPorId(id);

            if (interacao == null)
            {
                return NotFound();
            }

            return Ok(interacao);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Interacao interacao)
        {
            _service.Adicionar(interacao);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = interacao.Id },
                interacao
            );
        }

        [HttpPost("~/api/chamados/{id}/interacoes")]
        public IActionResult AdicionarPorChamado(
            int id,
            [FromBody] Interacao interacao)
        {
            interacao.ChamadoId = id;
            _service.Adicionar(interacao);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = interacao.Id },
                interacao
            );
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Interacao interacao)
        {
            _service.Atualizar(interacao);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var interacao = _service.BuscarPorId(id);

            if (interacao == null)
            {
                return NotFound();
            }

            _service.Deletar(interacao);

            return NoContent();
        }

        [HttpGet("chamado/{chamadoId}")]
        public IActionResult ListarPorChamado(int chamadoId)
        {
            return Ok(_service.ListarPorChamado(chamadoId));
        }
    }
}