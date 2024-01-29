using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrioritiesApp.Models;

public class Tickets
{
	[Key]
	public int TicketId { get; set; }

	[Required(ErrorMessage = "Error, la fecha es requerida")]
	[DataType(DataType.Date)]
	public DateTime Fecha { get; set; }

	[ForeignKey("Clientes")]
	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public int ClienteId { get; set; }

	[ForeignKey("Sistemas")]
	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public int SistemaId { get; set; }

	[ForeignKey("Priorities")]
	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public int PriorityId { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string SolicitadoPor { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Asunto { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Descripcion { get; set; }
}
