using System.ComponentModel.DataAnnotations;
using _3.Data.Model;

namespace _1.API.Request;

public class UserRegisterRequest
{
    
    [Required]
    [MaxLength(20)]
    public string username { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string password { get; set; }

    public UserType UserType{ get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
    [Required]
    [MaxLength(20)]
    public string Lastname { get; set; }
    [Required]
    public Adress Adress { get; set; }
    [Required]
    [MaxLength(20)]
    public string phone { get; set; }
}