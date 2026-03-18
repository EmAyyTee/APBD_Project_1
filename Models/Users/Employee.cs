namespace APBD_Zadanie_Pierwsze.Models;

public class Employee : User
{
    public override int MaxRentals => 5;
}