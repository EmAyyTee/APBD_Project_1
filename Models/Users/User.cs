namespace APBD_Zadanie_Pierwsze.Models;

public abstract class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FUllName =>  $"{FirstName} {LastName}";
    public abstract int MaxRentals { get; }
}