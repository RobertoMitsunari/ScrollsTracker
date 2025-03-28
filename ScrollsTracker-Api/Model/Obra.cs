using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScrollsTracker.Api.Model
{
    public class Obra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid? IdExterno { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public int TotalCapitulos { get; set; }
        public int UltimoCapituloLido { get; set; }
        public string? Imagem { get; set; }
    }
}