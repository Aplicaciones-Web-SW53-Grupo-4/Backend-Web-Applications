using System.ComponentModel.DataAnnotations;

namespace _1.API.Request;

public class UserRequest
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
    
    // [Required]
    // [Range(1990,2023)]
    // public int Year { get; set; }
    [Required]
    [MaxLength(20)]
    public string Lastname { get; set; }
    public string Country { get; set; }

    public string phone { get; set; }

    
    
}