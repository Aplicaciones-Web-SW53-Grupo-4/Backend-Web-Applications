using _3.Data;
using _3.Data.Model;

namespace _2.Domain;

public class RequestRentDomain:IRequestRentDomain
{
    private IRequestRentData _requestRentData;

    public RequestRentDomain(IRequestRentData _requestRentData)
    {
        this._requestRentData = _requestRentData;
    }
    public bool CreateRequestRent(RequestRent requestRent)
    {
        return  _requestRentData.CreateRequestRent(requestRent);
    }
    
    public Task<List<RequestRent>> GetAllRequestRentByIdForOwner(int id)
    {
        return _requestRentData.GetAllRequestRentByIdForOwner(id);
    }

    public Task<List<RequestRent>> GetAllRequestRentByIdForTenant(int id)
    {
        return _requestRentData.GetAllRequestRentByIdForTenant(id);
    }

    public bool UpdateRequestRent(RequestRent requestRent, int id)
    {
        return _requestRentData.UpdateRequestRent(requestRent, id);
    }
}