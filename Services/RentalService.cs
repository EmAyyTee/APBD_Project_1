using APBD_Zadanie_Pierwsze.Models;

namespace APBD_Zadanie_Pierwsze.Services;

public class RentalService
{
 private List<Rental> _rentals = new List<Rental>();
 public Rental Rent(User user, Equipement equipment)
 {
  if (!CanUserRent(user))
   return new Rental();
  
  if (!isEquipmentAvaliable(equipment))
   return  new Rental();
  
  var rental = new Rental()
  {
   Renter = user,
   RentedItem = equipment,
   RentDate = DateTime.Now,
   DueDate = DateTime.Now.AddDays(7),
   ReturnDate = null
  };
  
  _rentals.Add(rental);
  
  return rental;
 }

 public void ReturnEquipement(Rental rental)
 {
  rental.ReturnDate = DateTime.Now;
  rental.RentedItem.Status = EquipementStatus.Available;
 }

 public List<Equipement> GetAvaliableEquipments()
 {
  return _rentals
   .Where(r => r.RentedItem.Status == EquipementStatus.Available)
   .Select(r => r.RentedItem)
   .ToList();
 }

 public int GetActiveRentals(User user)
 {
  return _rentals.Count(r => r.Renter ==  user && r.ReturnDate == null);
 }

 public bool CanUserRent(User user)
 {
  return GetActiveRentals(user) < user.MaxRentals;
 }

 public bool isEquipmentAvaliable(Equipement equipment)
 {
  return !_rentals.Any(r => r.RentedItem == equipment && r.ReturnDate == null);
 }
}