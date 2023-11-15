using Microsoft.EntityFrameworkCore;

namespace _3.Data.Model;

public interface IUserData
{
    User GetById(string id);
    User GetByName(string name);
    Task<List<User>> GetAllAsync();

    bool Create(User user);
    bool Update(User user,string id);
    bool Delete(string id);
    User ValidateCredentials(string email, string password);
}