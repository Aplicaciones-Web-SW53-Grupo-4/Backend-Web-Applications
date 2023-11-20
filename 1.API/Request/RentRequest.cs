using _3.Data.Model;

namespace _1.API.Request;

public class RentRequest
{
    public AutomobileRentStatus StatusRequest { get; set; }
    public DateTime StartRent { get; set; }
    public DateTime EndRent { get; set; }
    public long TimeCollect { get; set; }
    public string TenantId { get; set; }
    public string AutomobileId { get; set; }
    public string OwnerId { get; set; }
}