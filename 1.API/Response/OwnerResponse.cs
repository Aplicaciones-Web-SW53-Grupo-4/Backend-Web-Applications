using _3.Data.Model;

namespace _1.API.Response;

public class OwnerResponse
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    
    public Adress Adress { get; set; }
    public string phone { get; set; }
}