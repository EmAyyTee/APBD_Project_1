using System.Reflection.Metadata;
using APBD_Zadanie_Pierwsze.Models;
using APBD_Zadanie_Pierwsze.Services;

var rentalService = new RentalService();

var user = new Student()
{
    Id = 1,
    FirstName = "Jan",
    LastName = "Kowalski"
};

var laptop = new Laptop()
{
    Id = 1,
    Name = "Gaming Laptop",
    Processor = "i7",
    Graphics = "RTX 3000",
    PricePerDay = 50
};

var camera = new Camera()
{
    Id = 1,
    Name = "Camera",
    Resolution = "1920x1080",
    Weight = 1
};

var projector = new Projector()
{
    Id = 1,
    Name = "Projector",
    Resolution = "1920x1080",
    Brightness = 10
};

var allEquipment = new List<Equipement>()
{
    laptop,
    camera,
    projector
};

var avaliable = rentalService.GetAvailableEquipment(allEquipment);

foreach (var equipment in avaliable)
{
    Console.WriteLine($"{equipment.Name}");
}

var rental = rentalService.Rent(user, laptop);

Console.WriteLine($"Rented: {rental.RentedItem.Name}");
Console.WriteLine($"User: {user.FUllName}");
Console.WriteLine($"Max rentals: {user.MaxRentals}");
    
var availableAfterRent = rentalService.GetAvailableEquipment(allEquipment);
Console.WriteLine($"Available after rent: {availableAfterRent.Count}");

var fee = rentalService.ReturnEquipment(rental);


Console.WriteLine($"Returned. Fee: {fee}");

var availableAfterReturn = rentalService.GetAvailableEquipment(allEquipment);
Console.WriteLine($"Available after return: {availableAfterReturn.Count}");

