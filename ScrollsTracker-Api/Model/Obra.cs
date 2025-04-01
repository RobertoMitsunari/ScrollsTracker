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

        public void AtualizarDados(Guid? novoIdExterno, string? novoTitulo, string? novaDescricao, int novoTotalCapitulos, string? novaImagem)
        {
            IdExterno = novoIdExterno ?? IdExterno;
            Titulo = string.IsNullOrEmpty(novoTitulo) ? Titulo : novoTitulo;
            Descricao = string.IsNullOrEmpty(novaDescricao) ? Descricao : novaDescricao;
            TotalCapitulos = TotalCapitulos == 0 ? novoTotalCapitulos : TotalCapitulos;
            Imagem = string.IsNullOrEmpty(novaImagem) ? Imagem : novaImagem;
        }
    }
}