using DeskFlowApi.Context;
using DeskFlowApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace DeskFlowApi.Repositories
{
    public class CategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Categoria> Listar()
        {
            return _context.Categorias.ToList();
        }
        public Categoria? BuscarPorID(int Id)
        {
            return _context.Categorias
            .FirstOrDefault(c => c.Id == Id);
        }
        public void Adicionar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }
        public void Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }
        public bool PossuiChamados(int categoriaId)
        {
            return _context.Chamados.Any(c => c.CategoriaId == categoriaId);
        }
        public void Deletar(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
    }
}