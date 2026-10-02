using DeskFlowApi.Models;
using System.ComponentModel.DataAnnotations;

namespace DeskFlowApi.Models
{
    public class Chamado
    {
        public int Id {get; set;}
        [Required]
        public string Titulo {get; set;}
        [Required]
        public string Descricao {get; set;}
        [Required]
        public Prioridade Prioridade {get; set;}
        public Status Status {get; set;}
        public string SolicitanteNome {get; set;}
        [Required]
        public DateTime DataAbertura {get; set;}
        public DateTime DataFechamento {get; set;}
        public string Solucao {get; set;}
        public int CategoriaId {get; set;}    
        public Categoria Categoria { get; set; }
        public List<Interacao> Interacoes { get; set; }
    }
}