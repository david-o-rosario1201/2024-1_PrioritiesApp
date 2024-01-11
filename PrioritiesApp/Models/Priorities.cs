using System.ComponentModel.DataAnnotations;

namespace PrioritiesApp.Models
{
	public class Priorities
	{
		[Key]
		public int PriorityId { get; set; }

		[Required(ErrorMessage = "Error, campo obligatorio")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Error, campo obligatorio")]
		public int DaysCommitment { get; set; }
	}
}