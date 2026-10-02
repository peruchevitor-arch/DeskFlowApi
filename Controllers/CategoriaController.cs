using DeskFlowApi.Models;
using DeskFlowApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowApi.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _service;

        public CategoriaController(CategoriaService categoria)
        {
            _service = categoria;
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
        public IActionResult Adicionar([FromBody] Categoria categoria)
        {
            _service.Adicionar(categoria);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Categoria categoria)
        {
            _service.Atualizar(categoria);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar([FromBody] Categoria categoria)
        {
            _service.Deletar(categoria);
            return Ok();
        }
    }
}
