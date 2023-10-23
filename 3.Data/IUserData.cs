using Microsoft.EntityFrameworkCore;

namespace _3.Data.Model;

public interface IUserData
{
    User GetById(int id);
    User GetByName(string name);
    Task<List<User>> GetAllAsync();

    bool Create(User user);
    bool Update(User user,int id);
    bool Delete(int id);
    User ValidateCredentials(string email, string password);
}