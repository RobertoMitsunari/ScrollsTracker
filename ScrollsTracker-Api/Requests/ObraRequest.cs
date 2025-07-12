namespace ScrollsTracker.Api.Requests
{
	public class ObraRequest
	{
		public int Id { get; set; }
		public string? Titulo { get; set; }
		public string? Descricao { get; set; }
		public int TotalCapitulos { get; set; }
		public int UltimoCapituloLido { get; set; }
		public string? Imagem { get; set; }
		public string? Status { get; set; }
	}
}
