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
        requestRent.DateCreated = DateTime.Now;
        _automovileUnitBd.TRentRequests.Add(requestRent);
        return _automovileUnitBd.SaveChanges() >= 0;
    }

    public Task<List<RequestRent>> GetAllRequestRentByIdForOwner(string id)
    {
        return _automovileUnitBd.TRentRequests.Where(p => p.Automobile.UserId == id).
            Include(p => p.Owner).
            Include(p => p.Tenant).
            Include(p => p.Automobile).
            ToListAsync();
    }
    public Task<List<RequestRent>> GetAllRequestRentByIdForTenant(string id)
    {
        return _automovileUnitBd.TRentRequests.Where(p => p.TenantId == id)
            .Include(p => p.Automobile)
            .Include(p => p.Tenant).
            Include(p => p.Owner).
            ToListAsync();
    }
    public Task<List<RequestRent>> GetAllRequestRentByIdForTenantForRent(string id)
    {
        return _automovileUnitBd.TRentRequests.Where(p => p.TenantId == id&&p.StatusRequest==AutomobileRentStatus.Accepted)
            .Include(p => p.Automobile)
            .Include(p => p.Tenant).
            Include(p => p.Owner).
            ToListAsync();
    }

    public bool UpdateRequestRent(RequestRent requestRent, string id)
    {
        try
        {
            RequestRent requestRent1 = _automovileUnitBd.TRentRequests.FirstOrDefault(p => p.Id == id);
            if (requestRent1 != null)
            {
                requestRent1.StatusRequest = requestRent.StatusRequest;
                requestRent1.DateUpdate = DateTime.Now;
                _automovileUnitBd.SaveChanges();
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
      
        
    }
}