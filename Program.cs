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

var user2 = userService.AddUser(new Employee()
{
    FirstName = "Lady",
    LastName = "Magbet",
});

var user3 = userService.AddUser(new Student()
{
    FirstName = "Patrick",
    LastName = "Star",
});

var allUsers =  userService.GetAllUsers();

foreach (var currentUser in allUsers)
{
    Console.WriteLine($"{currentUser.FUllName}");
}

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

rentalService.MarkAsUnavailiable(projector);

var rental = rentalService.Rent(user, laptop);

try
{
    var secondRental = rentalService.Rent(user, laptop);
}
catch (Exception e)
{
    Console.WriteLine("Error: " + e.Message);
}
rental.RentDate = DateTime.Now.AddDays(-2);
rental.DueDate = DateTime.Now.AddDays(2);

var onTimeFee = rentalService.ReturnEquipment(rental);

Console.WriteLine($"Sprzęt: {rental.RentedItem.Name}");
Console.WriteLine($"Termin zwrotu: {rental.DueDate}");
Console.WriteLine($"Faktyczny zwrot: {rental.ReturnDate}");
Console.WriteLine($"Czy po terminie: {rental.IsLate}");
Console.WriteLine($"Kara/opłata: {onTimeFee}");
Console.WriteLine("\n");

var thirdRental = rentalService.Rent(user2, camera);

thirdRental.RentDate = DateTime.Now.AddDays(-10);
thirdRental.DueDate = DateTime.Now.AddDays(-3);

var lateFee = rentalService.ReturnEquipment(thirdRental);

Console.WriteLine($"Sprzęt: {thirdRental.RentedItem.Name}");
Console.WriteLine($"Termin zwrotu: {thirdRental.DueDate}");
Console.WriteLine($"Faktyczny zwrot: {thirdRental.ReturnDate}");
Console.WriteLine($"Czy po terminie: {thirdRental.IsLate}");
Console.WriteLine($"Kara/opłata: {lateFee}");

var allEq = equipmentService.GetAllEquipement();
foreach (var currentEq in allEq)
{
    Console.WriteLine($"{currentEq.Name} - {currentEq.Status}");
}


Console.WriteLine("\n=== RAPORT SYSTEMU ===");

Console.WriteLine("\n--- Sprzęt ---");
foreach (var eq in equipmentService.GetAllEquipement())
{
    Console.WriteLine($"{eq.Name} - {eq.Status}");
}

Console.WriteLine("\n--- Aktywne wypożyczenia ---");
foreach (var r in rentalService.GetActiveRentalsForUser(user))
{
    Console.WriteLine($"{r.Renter.FUllName} - {r.RentedItem.Name}");
}

Console.WriteLine("\n--- Przeterminowane wypożyczenia ---");
foreach (var r in rentalService.GetOverdueRentals())
{
    Console.WriteLine($"{r.Renter.FUllName} - {r.RentedItem.Name} (due: {r.DueDate})");
}

