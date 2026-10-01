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
    }
}