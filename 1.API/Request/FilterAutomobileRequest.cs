using _3.Data.Model;

namespace _1.API.Request;

public class FilterAutomobileRequest
{
    public string? Department { get; set; }
    public float? Price { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? TimeRent { get; set; }
    public AutomovilTransmissionType? TransmissionType { get; set; }
    public AutomovilClassType? ClassType { get; set; }
    public int? QuantitySeat{ get; set; }
}