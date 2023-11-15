using _3.Data.Model;
using System.ComponentModel.DataAnnotations;
namespace _1.API.Response;

public class SearchAutomovilFilterResponse
{
    public string Id { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public AutomovilTransmissionType TransmissionType { get; set; }
    
    [Display(Name= "Class Type")] 
    public string ClassTypeString => ClassType.ToString();
    public AutomovilClassType ClassType { get; set; }
    public bool IsAvailable { get; set; }
    public string UserId { get; set; }

}