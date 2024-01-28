using System.ComponentModel.DataAnnotations;

namespace PrioritiesApp.Models;

public class Sistemas
{
	[Key]
	public int SistemaId { get; set; }

	[Required(ErrorMessage = "Error, debe incluir un nombre")]
	public string Nombre { get; set; }
}
