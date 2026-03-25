using APBD_Zadanie_Pierwsze.Models;

namespace APBD_Zadanie_Pierwsze.Services;

public class RentalService : IRentalService
{
 private int _nextId = 1;
 private List<Rental> _rentals = new List<Rental>();
 private FeesCalculator _feesCalculator = new FeesCalculator();
 private LimitChecker _limitChecker = new LimitChecker();
 
 public Rental Rent(User user, Equipement equipment)
 {
  if (!CanUserRent(user))
  throw new InvalidOperationException("User reached rental limit");
  
  if (!isEquipmentAvaliable(equipment))
   throw new InvalidOperationException("Equipment is not available");
  
  var rental = new Rental()
  {
   Id = _nextId++,
   Renter = user,
   RentedItem = equipment,
   RentDate = DateTime.Now,
   DueDate = DateTime.Now.AddDays(7),
   ReturnDate = null
  };
  
  _rentals.Add(rental);
  equipment.Status = EquipementStatus.Rented;
  
  return rental;
 }

 public decimal ReturnEquipment(Rental rental)
 {
  rental.ReturnDate = DateTime.Now;
  rental.RentedItem.Status = EquipementStatus.Available;
  
  return _feesCalculator.CalculateFee(rental);
 }

 public List<Equipement> GetAvailableEquipment(List<Equipement> allEquipment)
 {
  return allEquipment.Where(e => e.Status == EquipementStatus.Available).ToList();
 }

 public int GetActiveRentals(User user)
 {
  return _rentals.Count(r => r.Renter ==  user && r.ReturnDate == null);
 }

 public bool CanUserRent(User user)
 {
  return _limitChecker.CanUserRent(user, GetActiveRentals(user));
 }

 public bool isEquipmentAvaliable(Equipement equipment)
 {
  return !_rentals.Any(r => r.RentedItem == equipment && r.ReturnDate == null);
 }

 public List<T> GetEquipmentsByType<T>(List<Equipement> allEquipment) where T : Equipement
 {
  return allEquipment.OfType<T>().ToList();
 }

 public void MarkAsUnavailiable(Equipement equipment)
 {
  if (equipment.Status == EquipementStatus.Rented)
   throw new InvalidOperationException("Cannot make rented equipment unavailable");
  
  equipment.Status = EquipementStatus.Unavailable;
 }
}