using System.ComponentModel.DataAnnotations;

namespace DeskFlowApi.Models
{
    public class Interacao
    {
        public int Id {get; set;}
        public int ChamadoId {get; set;}
        [Required]
        public string Autor {get; set;}
        [Required]
        public string Mensagem {get; set;}
        
        public DateTime DataRegistro {get; set;}
        public Chamado Chamado { get; set; }
    }
}