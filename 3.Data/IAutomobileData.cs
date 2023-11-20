namespace _3.Data.Model;

public interface IAutomobileData
{
    public Automobile GetById(string id);
    public Task<List<Automobile>> GetBySearch(string Brand , string Model);
    public Task<UserAutomovileResult> GetByUserAutomobile(string id,string automobileid);
    public Task<List<Automobile>> GetAllAsync();
    public bool Create(Automobile automobile);
    public bool Update(Automobile automobile, string id);
    public bool Delete(string id);

    public Task<List<Automobile>> GetCarsByOwnerID(string ownerId);
    
    public Task<List<Automobile>> SearchCarByFilter(Automobile automobile);
}