using _3.Data.Model;

namespace _2.Domain;

public class AutomobileDomain: IAutomobileDomain
{
    private const int IntervalMinutes = 10; // Define el intervalo de tiempo en minutos
    private const int MaxAutomobilesPerInterval = 5; // Define el número máximo de automóviles por intervalo
    
    IAutomobileData _automobileData;
    IUserData _userData;
    
    public AutomobileDomain(IAutomobileData automobileData, IUserData userData)
    {
        _automobileData = automobileData;
        _userData = userData;
    }
    
    public bool Create(Automobile automobile, string userId)
    {
        if (!IsUserValid(userId))
        {
            throw new InvalidOperationException("User is not valid");
        }

        // Verificar la frecuencia de creación de automóviles
        var user = _userData.GetById(userId);

        if (user.LastAutomobileCreation != null)
        {
            var elapsedTime = DateTime.Now - user.LastAutomobileCreation.Value;

            if (elapsedTime.TotalMinutes < IntervalMinutes && user.AutomobilesCreatedInInterval >= MaxAutomobilesPerInterval)
            {
                throw new InvalidOperationException($"No se permite crear más de {MaxAutomobilesPerInterval} automóviles cada {IntervalMinutes} minutos.");
            }
        }

        automobile.statusRequest = AutomobileRentStatus.Pending;

        // Actualizar la información del usuario
        user.LastAutomobileCreation = DateTime.Now;
        user.AutomobilesCreatedInInterval++;

        _userData.Update(user, userId);

        return _automobileData.Create(automobile);
    }

    private bool IsUserValid(string userId)
    {
        var user = _userData.GetById(userId);
        return user != null;

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