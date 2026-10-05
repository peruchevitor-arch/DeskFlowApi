using DeskFlowApi.Models;
using DeskFlowApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowApi.Controllers
{
    [ApiController]
    [Route("api/chamados")]
    public class ChamadosController : ControllerBase
    {
        private readonly ChamadoService _service;

        public ChamadosController(ChamadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Listar(Status? status, Prioridade? prioridade, int? categoriaId)
        {
            return Ok(_service.Listar(status, prioridade, categoriaId));
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var chamado = _service.BuscarPorId(id);

            if (chamado == null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Chamado chamado)
        {
            _service.Adicionar(chamado);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = chamado.Id },
                chamado
            );
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Chamado chamado)
        {
            _service.Atualizar(chamado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var chamado = _service.BuscarPorId(id);

            if (chamado == null)
            {
                return NotFound();
            }

            _service.Deletar(chamado);
            return NoContent();
        }

        [HttpPost("{id}/iniciar")]
        public IActionResult IniciarChamado(int id)
        {
            _service.IniciarChamado(id);
            return NoContent();
        }

        [HttpPost("{id}/encerrar")]
        public IActionResult FecharChamado(int id, [FromBody] string solucao)
        {
            _service.FecharChamado(id, solucao);
            return NoContent();
        }
    }
}