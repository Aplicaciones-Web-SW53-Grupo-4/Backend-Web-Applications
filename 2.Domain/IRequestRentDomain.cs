using _3.Data.Model;

namespace _2.Domain;

public interface IRequestRentDomain
{
    public bool CreateRequestRent(RequestRent requestRent);
    public Task<List<RequestRent>> GetAllRequestRentByIdForOwner(string id);
    public Task<List<RequestRent>> GetAllRequestRentByIdForTenant(string id);
    public Task<List<RequestRent>> GetAllRequestRentByIdForTenantForRent(string id);
    public bool UpdateRequestRent(RequestRent requestRent, string id);
}