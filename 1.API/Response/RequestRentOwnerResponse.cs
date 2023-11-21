using _3.Data.Model;

namespace _1.API.Response;

public class RequestRentOwnerResponse
{
    public string Id { get; set; }
    public AutomobileRentStatus StatusRequest { get; set; }
    public TenantResponse Tenant { get; set; }
    public AutomobileResponse Automobile { get; set; }
    
    public DateTime StartRent { get; set; }
    public DateTime EndRent { get; set; }
    
    public long TimeCollect { get; set; }
    
    public DateTime CreatedAt { get; set; }
}