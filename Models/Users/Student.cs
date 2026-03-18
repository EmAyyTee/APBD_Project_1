namespace APBD_Zadanie_Pierwsze.Models;

public class Student : User
{
    public override int MaxRentals => 2;
}