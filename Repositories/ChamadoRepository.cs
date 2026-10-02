using DeskFlowApi.Context;
using DeskFlowApi.Models;
using Microsoft.EntityFrameworkCore;
namespace DeskFlowApi.Repositories
{
    public class ChamadoRepository
    {
        private readonly AppDbContext _context;
   
        public ChamadoRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Chamado> Listar(Status? status, Prioridade? prioridade, int? categoriaId)
        {
            var consulta = _context.Chamados.AsQueryable();

            if (status.HasValue)
            {
                consulta = consulta.Where(c => c.Status == status.Value);
            }

            if (prioridade.HasValue)
            {
                consulta = consulta.Where(c => c.Prioridade == prioridade.Value);
            }

            if (categoriaId.HasValue)
            {
                consulta = consulta.Where(c => c.CategoriaId == categoriaId.Value);
            }

            return consulta.ToList();
        }
        public Chamado? BuscarPorId(int Id)
        {
            return _context.Chamados
                .Include(c => c.Categoria)
                .Include(c => c.Interacoes)
                .FirstOrDefault(c => c.Id == Id);
        }
        public void Adicionar(Chamado chamado)
        {
            _context.Chamados.Add(chamado);
            _context.SaveChanges();
        }
        public void Atualizar(Chamado chamado)
        {
            _context.Chamados.Update(chamado);
            _context.SaveChanges();
        }
        public void Deletar(Chamado chamado)
        {
            _context.Chamados.Remove(chamado);
            _context.SaveChanges();
        }
    }
}