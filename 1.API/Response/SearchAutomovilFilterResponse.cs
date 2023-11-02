using _3.Data.Model;

namespace _1.API.Response;

public class SearchAutomovilFilterResponse
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public AutomovilTransmissionType TransmissionType { get; set; }
    public AutomovilClassType ClassType { get; set; }
    public bool IsAvailable { get; set; }
    public int UserId { get; set; }

}