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
        [HttpGet("{id}")]
        public IActionResult Listar()
        {
            return Ok(_service.Listar());
        }
        [HttpPost]
        public IActionResult BuscarPorId(int id)
        {
            _service.BuscarPorId(id);
            return Ok();
        }
        public IActionResult Adicionar(Chamado chamado)
        {
            _service.Adicionar(chamado);
            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar(Chamado chamado)
        {
            _service.Atualizar(chamado);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Deletar(Chamado chamado)
        {
            _service.Deletar(chamado);
            return Ok();
        }
    }
}