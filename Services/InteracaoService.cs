using DeskFlowApi.Models;
using DeskFlowApi.Repositories;
namespace DeskFlowApi.Services
{
    public class InteracaoService
    {
        private readonly InteracaoRepository _repository;
        private readonly ChamadoRepository _chamadoRepository;

        public InteracaoService(InteracaoRepository repository, ChamadoRepository chamadoRepository)
        {
            _repository = repository;
            _chamadoRepository = chamadoRepository;
        }
         public List<Interacao> Listar()
        {
            return _repository.Listar();
        }
        public Interacao? BuscarPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }
        public void Adicionar(Interacao interacao)
        {
            
            var chamado = _chamadoRepository.BuscarPorId(interacao.ChamadoId);
            if (chamado == null)
            {
                throw new KeyNotFoundException("Chamado não encontrado.");
            }
            if (chamado.Status == Status.Fechado)
            {
                throw new InvalidOperationException(
                    "Não é possível adicionar uma interação em um chamado fechado.");
            }
            interacao.DataRegistro = DateTime.Now;
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
        public List<Interacao> ListarPorChamado(int chamadoId)
        {
            return _repository.ListarPorChamado(chamadoId);
        }
    }
}