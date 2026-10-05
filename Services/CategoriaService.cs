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

        public Categoria? BuscarPorId(int id)
        {
            return _repository.BuscarPorID(id);
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
            if (_repository.PossuiChamados(categoria.Id))
            {
                throw new InvalidOperationException(
                    "Não é possível excluir uma categoria que possui chamados associados.");
            }

            _repository.Deletar(categoria);
        }
    }
}