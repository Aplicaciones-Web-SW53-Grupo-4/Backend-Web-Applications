using _3.Data.Model;
using Microsoft.Build.Framework;

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
    public string Description { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public AutomovilTransmissionType TransmissionType { get; set; }
    [Required]
    public AutomovilClassType ClassType { get; set; }
    [Required]
    public Adress location { get; set; }
    [Required]
    public int UserId { get; set; }
}