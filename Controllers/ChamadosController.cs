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
    }
}