namespace _3.Data.Model;

public class Automobile:ModelBase
{
    public string Brand { get; set; }
  
    public double Price { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    
    public int QuantitySeat{ get; set; }
    
    public AutomovilTransmissionType TransmissionType { get; set; }
    public AutomovilClassType ClassType { get; set; }
    public bool IsAvailable { get; set; }
    
    public string Place { get; set; }
    public string TimeRent { get; set; }
    //public byte[] Image { get; set; }
    
    public int UserId { get; set; }
    private User User { get; set; }
}