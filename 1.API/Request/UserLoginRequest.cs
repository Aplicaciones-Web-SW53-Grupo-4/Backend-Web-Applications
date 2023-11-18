using _3.Data.Model;

namespace _1.API.Request;

public class UserLoginRequest
{
    public string Username { get; set; } // Campo para el nombre de usuario
    public string Password { get; set; } // Campo para la contraseña
    
    public UserType UserType { get; set; } // Campo para el tipo de usuario
}