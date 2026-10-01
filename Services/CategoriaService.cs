using DeskFlowApi.Models;
using DeskFlowApi.Repositories;
namespace DeskFlowApi.Services
{
    public class CategoriaService
    {
        private readonly CategoriaRepository _repository;

        public CategoriaService(CategoriaRepository repository)
        {
            _repository = repository;
        }
         public List<Categoria> Listar()
        {
            return _repository.Listar();
        }
        public Categoria? BuscarPorId(int Id)
        {
            return _repository.BuscarPorID(Id);
        }
        public void Adicionar(Categoria categoria)
        {
            _repository.Adicionar(categoria);
        }
        public void Atualizar(Categoria categoria)
        {
            _repository.Atualizar(categoria);
        }
        public void Deletar(Categoria categoria)
        {
            _repository.Deletar(categoria);
        }
    }
}