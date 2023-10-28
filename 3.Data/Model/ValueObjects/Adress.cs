using Microsoft.EntityFrameworkCore;

namespace _3.Data.Model;

[Owned]
public class Adress
{
    public string Department { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
}