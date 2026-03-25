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
}