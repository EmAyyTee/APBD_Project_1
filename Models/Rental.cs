namespace APBD_Zadanie_Pierwsze.Models;

public class Rental
{
    public User Renter { get; set; }
    public int Id { get; set; }
    public Equipement RentedItem { get; set; }
    
    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public bool IsLate => ReturnDate != null && ReturnDate > DueDate;
}