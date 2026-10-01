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
        public IActionResult Adicionar(Categoria Categoria)
        {
            _service.Adicionar(Categoria);
            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar(Categoria Categoria)
        {
            _service.Atualizar(Categoria);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Deletar(Categoria Categoria)
        {
            _service.Deletar(Categoria);
            return Ok();
        }
    }
}