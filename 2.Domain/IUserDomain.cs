using _3.Data.Model;

namespace _2.Domain;

public interface IUserDomain
{
    bool Create(User user);
    bool Update(User user,string id);
    bool Delete(string id);
    User Authenticate(string email, string password);
}