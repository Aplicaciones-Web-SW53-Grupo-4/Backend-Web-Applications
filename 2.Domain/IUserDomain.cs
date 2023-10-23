using _3.Data.Model;

namespace _2.Domain;

public interface IUserDomain
{
    bool Create(User user);
    bool Update(User user,int id);
    bool Delete(int id);
}