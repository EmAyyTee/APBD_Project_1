namespace APBD_Zadanie_Pierwsze.Models;

public abstract class Equipement
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal PricePerDay { get; set; }
    public EquipementStatus Status { get; set; }

    protected Equipement()
    {
        Status = EquipementStatus.Available;
    }
}