using DeskFlowApi.Models;
using DeskFlowApi.Repositories;
namespace DeskFlowApi.Services
{
    public class ChamadoService
    {
        private readonly ChamadoRepository _repository;

        public ChamadoService(ChamadoRepository repository)
        {
            _repository = repository;
        }
         public List<Chamado> Listar()
        {
            return _repository.Listar();
        }
        public void BuscarPorId(int id)
        {
            _repository.BuscarPorId(id);
        }
        public void Adicionar(Chamado chamado)
        {
            _repository.Adicionar(chamado);
        }
        public void Atualizar(Chamado chamado)
        {
            _repository.Atualizar(chamado);
        }
        public void Deletar(Chamado chamado)
        {
            _repository.Deletar(chamado);
        }
    }
}