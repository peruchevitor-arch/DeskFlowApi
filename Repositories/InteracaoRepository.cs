using DeskFlowApi.Context;
using DeskFlowApi.Models;
namespace DeskFlowApi.Repositories
{
    public class InteracaoRepository
    {
        private readonly AppDbContext _context;
   
        public InteracaoRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Interacao> Listar()
        {
            return _context.Interacoes.ToList();
        }
        public Interacao? BuscarPorId(int Id)
        {
            return _context.Interacoes.FirstOrDefault(x => x.Id == Id);
        }
        public void Adicionar(Interacao interacao)
        {
            _context.Interacoes.Add(interacao);
            _context.SaveChanges();
        }
        public void Atualizar(Interacao interacao)
        {
            _context.Interacoes.Update(interacao);
            _context.SaveChanges();
        }
        public void Deletar(Interacao interacao)
        {
            _context.Interacoes.Remove(interacao);
            _context.SaveChanges();
        }
    }
}