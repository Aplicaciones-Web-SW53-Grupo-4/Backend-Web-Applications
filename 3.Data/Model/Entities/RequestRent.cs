namespace _3.Data.Model;

public class RequestRent:ModelBase
{
    public string automovile_id{ get; set; }
    public Automobile Automobile { get; set; }
    public string tenant_id { get; set; }
    public string owner_id { get; set; }
    public User Tenant { get; set; }
    public User Owner { get; set; }
}