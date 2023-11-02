using System.ComponentModel.DataAnnotations;
using _3.Data.Model;

namespace _1.API.Request;

public class UserRegisterRequest
{
    
    [Required (ErrorMessage = "El nombre de usuario es requerido")]
    [MaxLength(20)]
    public string username { get; set; }
    
    [Required (ErrorMessage = "La contraseña es requerida")]
    [MaxLength(20)]
    public string password { get; set; }
    
    [Required (ErrorMessage = "El tipo de usuario es requerido")]
    public UserType UserType{ get; set; }
    
    [Required (ErrorMessage = "El nombre es requerido")]
    [MaxLength(20)]
    public string Name { get; set; }
    [Required (ErrorMessage = "El apellido es requerido")]
    [MaxLength(20)]
    public string Lastname { get; set; }
    [Required (ErrorMessage = "El correo es requerido")]
    public Adress Adress { get; set; }
    [Required (ErrorMessage = "El teléfono es requerido")]
    [MaxLength(20)]
    public string phone { get; set; }
}