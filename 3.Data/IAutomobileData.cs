namespace _3.Data.Model;

public interface IAutomobileData
{
    public Automobile GetById(long id);
    public Task<List<Automobile>> GetAllAsync();
    public bool Create(Automobile automobile);
    public bool Update(Automobile automobile, long id);
    public bool Delete(long id);
    
    public Task<List<Automobile>> SearchCarByFilter(Automobile automobile);
}