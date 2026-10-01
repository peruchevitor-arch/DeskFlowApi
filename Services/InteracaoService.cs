using DeskFlowApi.Models;
using DeskFlowApi.Repositories;
namespace DeskFlowApi.Services
{
    public class InteracaoService
    {
        private readonly InteracaoRepository _repository;

        public InteracaoService(InteracaoRepository repository)
        {
            _repository = repository;
        }
         public List<Interacao> Listar()
        {
            return _repository.Listar();
        }
        public void BuscarPorId(int id)
        {
            _repository.BuscarPorId(id);
        }
        public void Adicionar(Interacao interacao)
        {
            _repository.Adicionar(interacao);
        }
        public void Atualizar(Interacao interacao)
        {
            _repository.Atualizar(interacao);
        }
        public void Deletar(Interacao interacao)
        {
            _repository.Deletar(interacao);
        }
    }
}