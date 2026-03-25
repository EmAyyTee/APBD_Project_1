namespace APBD_Zadanie_Pierwsze.Models;

public class Equipement
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EquipementStatus Status { get; set; }

    public Equipement()
    {
        Status = EquipementStatus.Available;
    }
}