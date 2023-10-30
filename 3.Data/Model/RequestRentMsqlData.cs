using _3.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace _3.Data.Model;

public class RequestRentMsqlData: IRequestRentData
{
    private AutomovileUnitBD _automovileUnitBd;
    
    public RequestRentMsqlData( AutomovileUnitBD automovileUnitBd)
    {
        _automovileUnitBd = automovileUnitBd;
    }
    public bool CreateRequestRent(RequestRent requestRent)
    {
        _automovileUnitBd.TRentRequests.Add(requestRent);
        return _automovileUnitBd.SaveChanges() >= 0;
    }

    public Task<List<RequestRent>> GetAllRequestRentByIdForOwner(int id)
    {
        return _automovileUnitBd.TRentRequests.Where(p => p.Automobile.UserId == id).ToListAsync();
    }
    public Task<List<RequestRent>> GetAllRequestRentByIdForTenant(int id)
    {
        return _automovileUnitBd.TRentRequests.Where(p => p.TenantId== id).ToListAsync();
    }

    public bool UpdateRequestRent(RequestRent requestRent, int id)
    {
        try
        {
            RequestRent requestRent1 = _automovileUnitBd.TRentRequests.FirstOrDefault(p => p.Id == id);
            if (requestRent1 != null)
            {
                requestRent1.StatusRequest = requestRent.StatusRequest;
                _automovileUnitBd.TRentRequests.Update(requestRent1);
                _automovileUnitBd.SaveChanges();
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
      
        
    }
}