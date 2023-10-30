using _3.Data.Model;

namespace _1.API.Response;

public class AutomobileResponse
{
    public string Brand { get; set; }
  
    public double Price { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string MaxSpeed { get; set; }
    
    public string Kilometers { get; set; }
    
    public int QuantityDoors { get; set; }
    
    public AutomovilTransmissionType TransmissionType { get; set; }
    public AutomovilClassType ClassType { get; set; }
    public bool IsAvailable { get; set; }
    
    public string Place { get; set; }
    public int TimeRent { get; set; }
}