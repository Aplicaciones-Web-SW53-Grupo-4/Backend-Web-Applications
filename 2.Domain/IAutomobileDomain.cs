using _3.Data.Model;

namespace _2.Domain;

public interface IAutomobileDomain
{
    string Create(Automobile automobile, string userId);  //crea el auto y devuelve el id para utilizar en contrato
    bool Delete(string id);
    Task<List<Automobile>> GetAll();
    Task<List<Automobile>> GetCarsByOwnerID(string ownerId);
    
    Task<Automobile> GetById(string id);
    Task<List<Automobile>> GetBySearch(string Brand, string Model);
    Task<List<Automobile>> SearchByFilter(Automobile filter);
}