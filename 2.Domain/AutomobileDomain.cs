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
    
    public bool Create(Automobile automobile, int userId)
    {
        var user = _userData.GetById(userId);
        user.Automobiles.Add(automobile);
        _userData.Update(user, userId);
        return true;
    }
    public bool Update(Automobile automobile, int id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Automobile>> GetAll()
    {
        return _automobileData.GetAllAsync();
    }

    public Task<Automobile> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Automobile> SearchByFilter(Automobile filter)
    {
        throw new NotImplementedException();
    }
}