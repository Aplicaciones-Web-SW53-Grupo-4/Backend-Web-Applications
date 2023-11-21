namespace _3.Data.Model;

public class RequestRent:ModelBase
{
    public AutomobileRentStatus StatusRequest { get; set; }
    
    public string AutomobileId { get; set; }
    public Automobile Automobile { get; set; }
    
    public string TenantId { get; set; }
    public User Tenant { get; set; }
    
    public string OwnerId { get; set; }
    public User Owner { get; set; }
    
    public DateTime StartRent { get; set; }
    public DateTime EndRent { get; set; }
    
    public long TimeCollect { get; set; }
}