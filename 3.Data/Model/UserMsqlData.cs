using _3.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace _3.Data.Model;

public class UserMsqlData :IUserData
{
    private AutomovileUnitBD _automovileUnitBd;
    
    public UserMsqlData( AutomovileUnitBD automovileUnitBd)
    {
        _automovileUnitBd = automovileUnitBd;
    }
    public User GetById(string id)
    {
        User user = _automovileUnitBd.TUsers.Where(t => t.Id == id && t.IsActive).FirstOrDefault();
        _automovileUnitBd.Entry(user).Collection(u=>u.Automobiles).Load();
        return user;
    }
    
    public User GetByName(string name)
    {
        return _automovileUnitBd.TUsers.Where(t => t.Name ==name && t.IsActive).FirstOrDefault();
    }
    
    public async Task<List<User>> GetAllAsync()
    {
        return await _automovileUnitBd.TUsers.Where(t => t.IsActive).ToListAsync();
    }
    public bool Create(User user)
    {
        try
        {
            _automovileUnitBd.TUsers.Add(user);
            _automovileUnitBd.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            //Logear
            return false;
        }
    }
    public bool Update(User tuser, string id)
    {    try
        {
            var userToBeUpdated = _automovileUnitBd.TUsers.Where(t => t.Id == id).First();

            userToBeUpdated.Name = tuser.Name;
            userToBeUpdated.Lastname = tuser.Lastname;
            userToBeUpdated.Adress = tuser.Adress;
            userToBeUpdated.phone = tuser.phone;
            
            userToBeUpdated.DateUpdate = DateTime.Now;

            _automovileUnitBd.TUsers.Update(userToBeUpdated);
            _automovileUnitBd.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            //Logear
            return false;
        }
    }
    
    
    public bool Delete(string id)
    {  try
        {
            var userToBeUpdated = _automovileUnitBd.TUsers.Where(t => t.Id == id).First();
            
            userToBeUpdated.DateUpdate = DateTime.Now;
            userToBeUpdated.IsActive = false;

            //_learningCenterBd.Tutorials.Remove(tutorialToBeUpdated);/// ELimina física
            
            _automovileUnitBd.TUsers.Update(userToBeUpdated);
            _automovileUnitBd.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            //Logear
            return false;
        }
    }
    public User ValidateCredentials(string email, string password, UserType userType)
    {
        // Implementa la validación de credenciales aquí
        // Puedes buscar al usuario por correo electrónico y comparar contraseñas, y luego retornar el usuario válido si las credenciales son correctas
        return _automovileUnitBd.TUsers.FirstOrDefault(t => t.username == email
                                                            && t.password == password
                                                            && t.UserType == userType);
    }
}