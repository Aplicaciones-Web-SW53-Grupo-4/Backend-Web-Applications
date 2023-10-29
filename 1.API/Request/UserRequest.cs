using System.ComponentModel.DataAnnotations;
using _3.Data.Model;

namespace _1.API.Request;

public class UserRequest
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Lastname { get; set; }
    
    public Adress Adress{ get; set; }

    public string phone { get; set; }
    
}