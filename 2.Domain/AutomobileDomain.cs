using _3.Data.Model;

namespace _2.Domain;

public class AutomobileDomain: IAutomobileDomain
{
    IAutomobileData _automobileData;
    IUserData _userData;
    
    public AutomobileDomain(IAutomobileData automobileData, IUserData userData)
    {
        _automobileData = automobileData;
        _userData = userData;
    }
    
    public string Create(Automobile automobile,string userId)
    {
        var user = _userData.GetById(userId);
        if (user != null)
        {
            automobile.statusRequest = AutomobileRentStatus.Waiting;
            if (_automobileData.Create(automobile))
            {
                // Devuelve el ID del automóvil creado
                return automobile.Id;
            }
        }
        return null; // Retorna null si no se crea el automóvil o el usuario no existe
    }
    public bool Update(Automobile automobile, string id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Automobile>> GetAll()
    {
        return _automobileData.GetAllAsync();
    }

    public Task<List<Automobile>> GetCarsByOwnerID(string ownerId)
    {
        return _automobileData.GetCarsByOwnerID(ownerId);
    }


    public async Task<UserAutomovileResult> GetByUserAutomobile(string id, string automovileid)
    {
        throw new NotImplementedException();
    }
    public Task<Automobile> GetById(string id)
    {
        throw new NotImplementedException();
    }
    
    public Task<List<Automobile>> GetBySearch(string Brand , string Model)
    {
        throw new NotImplementedException();
    }

    public Task<List<Automobile>> SearchByFilter(Automobile filterAutomobile)
    {
        return _automobileData.SearchCarByFilter(filterAutomobile);
    }
}