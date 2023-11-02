using _3.Data.Model;

namespace _2.Domain;

public interface IAutomobileDomain
{
    bool Create(Automobile automobile, int userId);
    bool Delete(int id);
    Task<List<Automobile>> GetAll();
    Task<Automobile> GetById(int id);
    
    Task<List<Automobile>> GetBySearch(string Brand, string Model);
    
    Task<Automobile> SearchByFilter(Automobile filter);
}