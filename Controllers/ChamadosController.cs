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
            _service.BuscarPorId(id);
            return Ok();
        }
        [HttpPost]
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
        [HttpPost("{id}/iniciar")]
        public IActionResult IniciarChamado(int id)
        {
            _service.IniciarChamado(id);
            return Ok();
        }
        [HttpPost("{id}/fechar")]
        public IActionResult FecharChamado(int id,string solucao)
        {
            _service.FecharChamado(id,solucao);
            return Ok();
        }
        
    }
}