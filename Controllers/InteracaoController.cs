using DeskFlowApi.Models;
using DeskFlowApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowApi.Controllers
{
    [ApiController]
    [Route("api/chamados")]
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
            return Ok(_service.BuscarPorId(id));
        }
        [HttpPost]
        public IActionResult Adicionar(Interacao interacao)
        {
            _service.Adicionar(interacao);
            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar(Interacao interacao)
        {
            _service.Atualizar(interacao);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Deletar(Interacao interacao)
        {
            _service.Deletar(interacao);
            return Ok();
        }
    }
}