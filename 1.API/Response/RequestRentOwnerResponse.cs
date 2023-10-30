using _3.Data.Model;

namespace _1.API.Response;

public class RequestRentOwnerResponse
{
    public int Id { get; set; }
    public AutomobileRentStatus StatusRequest { get; set; }
    public User Tenant { get; set; }
    public Automobile Automobile { get; set; }
    public DateTime CreatedAt { get; set; }
}