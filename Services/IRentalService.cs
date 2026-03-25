using APBD_Zadanie_Pierwsze.Models;

namespace APBD_Zadanie_Pierwsze.Services;

public interface IRentalService
{
    Rental Rent(User user, Equipement equipment);
    decimal ReturnEquipment(Rental rental);
    
    List<Equipement> GetAvailableEquipment(List<Equipement> equipment);
    
    int GetActiveRentals(User user);
    bool CanUserRent(User user);
}