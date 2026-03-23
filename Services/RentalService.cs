using APBD_Zadanie_Pierwsze.Models;

namespace APBD_Zadanie_Pierwsze.Services;

public class RentalService
{
 public Rental Rent(User user, Equipement equipment)
 {
  return new Rental();
 }

 public void ReturnEquipement(Rental rental)
 {
  
 }

 public List<Equipement> GetAvaliableEquipments()
 {
  
 }
}