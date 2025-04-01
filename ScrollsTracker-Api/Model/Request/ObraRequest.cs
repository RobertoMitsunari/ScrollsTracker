namespace ScrollsTracker.Api.Model.Request
{
    public class ObraRequest
    {
        public int Id { get; set; }
        public Guid? IdExterno { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public int TotalCapitulos { get; set; }
        public int UltimoCapituloLido { get; set; }
        public byte[]? Imagem { get; set; }

        public Obra ToDomain()
        {
            return new Obra
            {
                Id = this.Id,
                IdExterno = this.IdExterno,
                Titulo = this.Titulo,
                Descricao = this.Descricao,
                TotalCapitulos = this.TotalCapitulos,
                UltimoCapituloLido = this.UltimoCapituloLido
            };
        }
    }
}
