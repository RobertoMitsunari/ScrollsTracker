using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public byte[]? Imagem { get; set; }
    }
}