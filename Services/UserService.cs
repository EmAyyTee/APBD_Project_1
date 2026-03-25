using APBD_Zadanie_Pierwsze.Models;

namespace APBD_Zadanie_Pierwsze.Services;

public class UserService
{
    private int _nextId = 1;
    private readonly List<User> _users = new();

    public T AddUser<T>(T user) where T : User
    {
        user.Id = _nextId++;
        _users.Add(user);
        
        return user;
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}