namespace _3.Data.Model;

public class ModelBase
{
    public string Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdate { get; set; }
    public bool IsActive { get; set; }
}