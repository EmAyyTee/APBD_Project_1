using System.Reflection.Metadata;
using APBD_Zadanie_Pierwsze.Models;
using APBD_Zadanie_Pierwsze.Services;

var rentalService = new RentalService();
var equipmentService = new EquipmentService();
var userService = new UserService();

var user = userService.AddUser(new Student()
{
    FirstName = "John",
    LastName = "Doe",
});


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

var rental = rentalService.Rent(user, laptop);

Console.WriteLine($"Rented: {rental.RentedItem.Name}");
Console.WriteLine($"User: {user.FUllName}");
Console.WriteLine($"Max rentals: {user.MaxRentals}");

var fee = rentalService.ReturnEquipment(rental);

Console.WriteLine($"Rental Fee: {fee}");