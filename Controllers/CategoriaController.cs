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
            var categoria = _service.BuscarPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Categoria categoria)
        {
            _service.Adicionar(categoria);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = categoria.Id },
                categoria
            );
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Categoria categoria)
        {
            _service.Atualizar(categoria);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var categoria = _service.BuscarPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _service.Deletar(categoria);

            return NoContent();
        }
    }
}