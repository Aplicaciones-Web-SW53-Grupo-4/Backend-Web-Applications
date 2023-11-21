using System.ComponentModel.DataAnnotations;
using _3.Data.Model;

namespace _1.API.Response;

public class AutomobileResponse

{
    public string Id { get; set; }
    public string Brand { get; set; }
  
    public double Price { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    
    public int QuantitySeat { get; set; }
    
    public AutomovilTransmissionType TransmissionType { get; set; }
    [Display(Name= "Class Type")] 
    public string ClassTypeString => ClassType.ToString();
    public AutomovilClassType ClassType { get; set; }
    public bool IsAvailable { get; set; }
    public string imageurl { get; set; }
    public string Place { get; set; }
    public string TimeRent { get; set; }
    
    [Display(Name = "status rent")] 
    public string statusRequestString => statusRequest.ToString();
    public AutomobileRentStatus statusRequest { get; set; }
    
    public string nameofuser { get; set; }   //nombre del dueño del vehiculo con el cual se registro
    
    public string phoneeofuser { get; set; }   //telefono del dueño del vehiculo con el cual se registro
}