using System.ComponentModel.DataAnnotations;

namespace PrioritiesApp.Models
{
	public class Priorities
	{
        [Key]
        public int PriorityId { get; set; }

		[Required(ErrorMessage = "ERROR, CAMPO OBLIGATORIO")]
		public string Description { get; set; }

        [Range(1, 31, ErrorMessage = "ERROR, CAMPO OBLIGATORIO, RANGO [1-31]")]
        [Required(ErrorMessage = "ERROR, CAMPO OBLIGATORIO")]
        public int DaysCommitment { get; set; }
	}
}