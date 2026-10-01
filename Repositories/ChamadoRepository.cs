using DeskFlowApi.Context;
using DeskFlowApi.Models;
namespace DeskFlowApi.Repositories
{
    public class ChamadoRepository
    {
        private readonly AppDbContext _context;
   
        public ChamadoRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Chamado> Listar()
        {
            return _context.Chamados.ToList();
        }
    }
}