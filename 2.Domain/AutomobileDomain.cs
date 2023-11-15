﻿using _3.Data.Model;

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
    
    public bool Create(Automobile automobile,string userId)
    {
        var user = _userData.GetById(userId);
        if (user!=null)
        {
            automobile.statusRequest = AutomobileRentStatus.Waiting;
            return _automobileData.Create(automobile);
            
        }
        else
        {
            return false;
        }
        // user.Automobiles.Add(automobile);
        // _userData.Update(user, userId);
        // return true;
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

    public Task<Automobile> SearchByFilter(Automobile filter)
    {
        throw new NotImplementedException();
    }
}