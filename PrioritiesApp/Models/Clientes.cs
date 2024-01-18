using System.ComponentModel.DataAnnotations;
namespace PrioritiesApp.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [Required (ErrorMessage = "Error, debe ingresar un nombre")]
    public string? Nombre { get; set; }

    [Phone (ErrorMessage = $"Error, este numero de teléfono es invalido")]
    public string? Telefono { get; set; }

    [Phone (ErrorMessage = "Error, este numero de celular es invalido")]
    public string? Celular { get; set; }

    [Required (ErrorMessage = "Error, este RNC ya existe")]
    public string? RNC { get; set; }

    [EmailAddress (ErrorMessage = "Error, este email no es valido")]
    public string? Email { get; set; }

    [Required (ErrorMessage = "Error, debe una dirección")]
    public string? Direccion { get; set; }
}
