using _3.Data.Model;

namespace _2.Domain;

public interface IAutomobileDomain
{
    bool Create(Automobile automobile, string userId);
    bool Delete(string id);
    Task<List<Automobile>> GetAll();
    Task<Automobile> GetById(string id);
    Task<List<Automobile>> GetBySearch(string Brand, string Model);
    Task<Automobile> SearchByFilter(Automobile filter);
}