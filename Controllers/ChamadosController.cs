using DeskFlowApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowApi.Controllers
{
    [ApiController]
    [Route("api/chamados")]
    public class ChamadosController : ControllerBase
    {
    [HttpGet]
    public IActionResult Listar()
    {
        return Ok("Funcionou!");
    }
    }
}