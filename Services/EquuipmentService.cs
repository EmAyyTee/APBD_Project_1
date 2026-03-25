using APBD_Zadanie_Pierwsze.Models;

namespace APBD_Zadanie_Pierwsze.Services;

public class EquuipmentService
{
    private int _nextId = 1;
    private List<Equipement> _equipement = new List<Equipement>();

    public T AddEquipment<T>(T equipment) where T : Equipement
    {
        equipment.Id = _nextId++;
        equipment.Status = EquipementStatus.Available;
        _equipement.Add(equipment);
        
        return equipment;
    }

    public List<Equipement> GetAllEquipement()
    {
        return _equipement;
    }

    public List<Equipement> GetAvailableEquipement()
    {
        return _equipement
            .Where(e => e.Status == EquipementStatus.Available)
            .ToList();
    }

    public Equipement? GetById(int id)
    {
        return _equipement.FirstOrDefault(e => e.Id == id);
    }
    
    public List<T> GetEquipmentsByType<T>(List<Equipement> allEquipment) where T : Equipement
    {
        return allEquipment.OfType<T>().ToList();
    }
}