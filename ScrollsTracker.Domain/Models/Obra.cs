﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ScrollsTracker.Domain.Models
{
	public class Obra
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[JsonIgnore]
		public int Id { get; set; }
		public string? Titulo { get; set; }
		public string? Descricao { get; set; }
		public int TotalCapitulos { get; set; }
		public int UltimoCapituloLido { get; set; }
		public string? Imagem { get; set; }
		public string? Status { get; set; }
	}
}
