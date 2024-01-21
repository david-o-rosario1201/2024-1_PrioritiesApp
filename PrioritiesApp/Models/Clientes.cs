using System.ComponentModel.DataAnnotations;
namespace PrioritiesApp.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [Required (ErrorMessage = "Error, debe ingresar un nombre")]
    public string? Nombre { get; set; }

    [Phone(ErrorMessage = "Error, el formato del numero de telefono no es valido")]
    [Required(ErrorMessage = "Error, debe ingresar un numero de teléfono")]
    public string? Telefono { get; set; }

    [Phone (ErrorMessage = "Error, el formato del numero de telefono no es valido")]
    [Required(ErrorMessage = "Error, debe ingresar un numero de celular")]
    public string? Celular { get; set; }

	[Required(ErrorMessage = "Error, debe ingresar un RNC")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "El RNC debe tener exactamente 11 caracteres")]
	public string RNC { get; set; }


	[EmailAddress (ErrorMessage = "Error, el formato del email no es valido")]
    [Required(ErrorMessage = "Error, debe un ingresar un email")]
    public string? Email { get; set; }

    [Required (ErrorMessage = "Error, debe una dirección")]
    public string? Direccion { get; set; }
}
