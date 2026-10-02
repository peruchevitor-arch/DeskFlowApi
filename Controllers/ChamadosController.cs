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
        public IActionResult Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_service.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Chamado chamado)
        {
            _service.Adicionar(chamado);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Chamado chamado)
        {
            _service.Atualizar(chamado);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar([FromBody] Chamado chamado)
        {
            _service.Deletar(chamado);
            return Ok();
        }

        [HttpPost("{id}/iniciar")]
        public IActionResult IniciarChamado(int id)
        {
            _service.IniciarChamado(id);
            return Ok();
        }

        [HttpPost("{id}/encerrar")]
        public IActionResult FecharChamado(int id, [FromBody] string solucao)
        {
            _service.FecharChamado(id, solucao);
            return Ok();
        }
    }
}

