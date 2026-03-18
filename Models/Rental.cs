namespace APBD_Zadanie_Pierwsze.Models;

public class Rental
{
    public User Renter { get; private set; }
    public Equipement RentedItemName { get; private set; }
    
    public DateTime RentDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    
    public bool IsLate => ReturnDate != null && ReturnDate > DueDate;
}