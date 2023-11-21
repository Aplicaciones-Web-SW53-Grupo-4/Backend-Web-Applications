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
        return _automovileUnitBd.TRentRequests.Where(p => p.TenantId==id && 
                                                          p.StatusRequest==AutomobileRentStatus.Accepted)
            .Include(p => p.Automobile)
            .Include(p => p.Tenant).
            Include(p => p.Owner).
            ToListAsync();
    }

    public bool UpdateRequestRent(RequestRent requestRent, string id)
    {
        try
        {
            RequestRent requestRentToUpdate = _automovileUnitBd.TRentRequests.FirstOrDefault(p => p.Id == id);
            if (requestRentToUpdate != null)
            {
                requestRentToUpdate.StatusRequest = requestRent.StatusRequest;
                requestRentToUpdate.DateUpdate = DateTime.Now;
                _automovileUnitBd.SaveChanges();
                
                Automobile automobile = _automovileUnitBd.TAutomobiles.FirstOrDefault(p => p.Id == requestRentToUpdate.AutomobileId);
                
                automobile.statusRequest = requestRentToUpdate.StatusRequest;
                automobile.DateUpdate = DateTime.Now;
                _automovileUnitBd.SaveChanges();
                
                if(requestRentToUpdate.StatusRequest == AutomobileRentStatus.Accepted)
                {
                    var requestRentToReject = _automovileUnitBd.TRentRequests.Where(p => 
                        p.AutomobileId == requestRentToUpdate.AutomobileId &&
                        p.Id != requestRentToUpdate.Id);
                    
                    foreach (var requestReject in requestRentToReject)
                    {
                        requestReject.StatusRequest = AutomobileRentStatus.Rejected;
                        requestReject.DateUpdate = DateTime.Now;
                        _automovileUnitBd.SaveChanges();
                    }
                }
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