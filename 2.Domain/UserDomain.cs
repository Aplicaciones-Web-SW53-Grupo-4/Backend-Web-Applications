using _3.Data.Model;

namespace _2.Domain;

public class UserDomain :IUserDomain
{
    private IUserData _userData;

    public UserDomain(IUserData tUserData)
    {
        _userData= tUserData;
    }
    
    public bool Create(User tuser)
    {
        var existinguser = _userData.GetByName(tuser.Name);

        if (existinguser == null)
        {
            return _userData.Create(tuser);
        }
        else
        {
            return false;
        }
    }

    public bool Update(User tuser, string id)
    {       
        
        var existinguser = _userData.GetByName(tuser.Name);

        if (existinguser == null)
        {
            return _userData.Update(tuser,id);
        }
        else
        {
            return false;
        }
    }
    public bool Delete(string id)
    {
        return _userData.Delete(id);
    }
    public User Authenticate(string email, string password, UserType userType)
    {
        return _userData.ValidateCredentials(email, password, userType);
    }
}