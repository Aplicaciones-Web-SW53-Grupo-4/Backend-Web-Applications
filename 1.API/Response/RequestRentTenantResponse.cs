using _3.Data.Model;

namespace _1.API.Response;

public class RequestRentTenantResponse
{
    public int Id { get; set; }
    public AutomobileRentStatus StatusRequest { get; set; }
    public AutomobileResponse Automobile { get; set; }
    public OwnerResponse Owner { get; set; }
    public DateTime CreatedAt { get; set; }
    
}