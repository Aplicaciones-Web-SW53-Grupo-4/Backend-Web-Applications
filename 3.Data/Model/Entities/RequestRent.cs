namespace _3.Data.Model;

public class RequestRent:ModelBase
{
    public AutomobileRentStatus StatusRequest { get; set; }
    
    public int AutomobileId { get; set; }
    public Automobile Automobile { get; set; }
    
    public int TenantId { get; set; }
    public User Tenant { get; set; }
}