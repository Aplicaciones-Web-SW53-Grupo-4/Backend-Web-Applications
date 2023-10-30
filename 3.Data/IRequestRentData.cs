using _3.Data.Model;

namespace _3.Data;

public interface IRequestRentData
{
    public bool CreateRequestRent(RequestRent requestRent);
    public Task<List<RequestRent>> GetAllRequestRentByIdForOwner(int id);
    public Task<List<RequestRent>> GetAllRequestRentByIdForTenant(int id);
    public bool UpdateRequestRent(RequestRent requestRent, int id);
}