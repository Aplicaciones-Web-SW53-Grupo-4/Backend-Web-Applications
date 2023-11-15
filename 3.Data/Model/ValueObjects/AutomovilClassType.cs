using System.ComponentModel.DataAnnotations;

namespace _3.Data.Model;

public enum AutomovilClassType
{
    [Display(Name = "Economic")]
    Economic,
    
    [Display(Name = "Medium")]
    Medium,
    
    [Display(Name = "Luxury")]
    Luxury
}