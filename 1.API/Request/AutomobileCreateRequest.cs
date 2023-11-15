using _3.Data.Model;
using Microsoft.Build.Framework;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;

namespace _1.API.Request;

public class AutomobileCreateRequest
{


    [Required]
    public string Brand { get; set; }
    
    [Required]
    public double Price { get; set; }
    
    [Required]
    public string Model { get; set; }
    
    [Required]
    public string Color { get; set; }
    
    [Required]
    public int QuantitySeat{ get; set; }
    
    [Required]
    public AutomovilTransmissionType TransmissionType { get; set; }
    
    [Required]
    
    [Display(Name= "Class Type")] 
    public string ClassTypeString => ClassType.ToString();
    public AutomovilClassType ClassType { get; set; }
    
    [Required]
    public bool IsAvailable { get; set; }
    
    [Required]
    public string Place { get; set; }
    
    [Required]
    public string TimeRent { get; set; }
    
    [Display(Name = "status Request")] 
    public string statusRequestString => statusRequest.ToString();
    public AutomobileRentStatus statusRequest { get; set; }
    
    public string imageurl { get; set; }
    
    [Required]
    public string UserId { get; set; }
}