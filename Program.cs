using System.Reflection.Metadata;
using APBD_Zadanie_Pierwsze.Models;
using APBD_Zadanie_Pierwsze.Services;

var rentalService = new RentalService();
var equipmentService = new EquuipmentService();

var laptop = equipmentService.AddEquipment(new Laptop
{
    Name = "Gaming Laptop",
    Processor = "i7",
    Graphics = "RTX 3000",
    PricePerDay = 50
});

var camera = equipmentService.AddEquipment(new Camera
{
    Name = "Camera",
    Resolution = "1920x1080",
    Weight = 1
});

var projector = equipmentService.AddEquipment(new Projector
{
    Name = "Projector",
    Resolution = "1920x1080",
    Brightness = 10
});

var availableBeforeRent = equipmentService.GetAvailableEquipement();

foreach (var equipment in availableBeforeRent)
{
    Console.WriteLine(equipment.Name);
}