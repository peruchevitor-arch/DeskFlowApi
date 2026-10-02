using DeskFlowApi.Models;
using DeskFlowApi.Repositories;

namespace DeskFlowApi.Services
{
    public class ChamadoService
    {
        private readonly ChamadoRepository _repository;
        private readonly CategoriaRepository _categoriaRepository;

        public ChamadoService(
            ChamadoRepository repository,
            CategoriaRepository categoriaRepository)
        {
            _repository = repository;
            _categoriaRepository = categoriaRepository;
        }

        public List<Chamado> Listar()
        {
            return _repository.Listar();
        }

        public Chamado? BuscarPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public void Adicionar(Chamado chamado)
        {
            var categoria = _categoriaRepository.BuscarPorID(chamado.CategoriaId);

            if (categoria == null)
            {
                throw new KeyNotFoundException("Categoria não encontrada.");
            }

            chamado.Status = Status.Aberto;
            chamado.DataAbertura = DateTime.Now;

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

        public void IniciarChamado(int id)
        {
            var chamado = _repository.BuscarPorId(id);

            if (chamado == null)
            {
                throw new KeyNotFoundException("Chamado não encontrado.");
            }

            if (chamado.Status != Status.Aberto)
            {
                throw new InvalidOperationException(
                    "O chamado não pode ser iniciado.");
            }

            chamado.Status = Status.EmAndamento;

            _repository.Atualizar(chamado);
        }

        public void FecharChamado(int id, string solucao)
        {
            var chamado = _repository.BuscarPorId(id);

            if (chamado == null)
            {
                throw new KeyNotFoundException("Chamado não encontrado.");
            }

            if (chamado.Status != Status.EmAndamento)
            {
                throw new InvalidOperationException(
                    "O chamado não pode ser fechado.");
            }

            chamado.Status = Status.Fechado;
            chamado.DataFechamento = DateTime.Now;
            chamado.Solucao = solucao;

            _repository.Atualizar(chamado);
        }
    }
}