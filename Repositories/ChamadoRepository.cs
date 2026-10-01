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
        public Chamado? BuscarPorId(int Id)
        {
            return _context.Chamados.FirstOrDefault(x => x.Id == Id);
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