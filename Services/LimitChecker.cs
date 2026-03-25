using APBD_Zadanie_Pierwsze.Models;

namespace APBD_Zadanie_Pierwsze.Services;

public class LimitChecker
{
    public bool CanUserRent(User user, int activeRentals)
    {
        return activeRentals < user.MaxRentals;
    }
}