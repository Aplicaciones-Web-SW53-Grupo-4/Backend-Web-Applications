using _3.Data.Model;

namespace _1.API.Request;

public class RentRequest
{
    public int Id { get; set; }
    public AutomobileRentStatus StatusRequest { get; set; }
    public int TenantId { get; set; }
    public int AutomobileId { get; set; }
}