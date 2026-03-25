# APBD_Project_1 - Equipment Rental System (C#)

## Opis projektu

Projekt przedstawia prosty system wypożyczalni sprzętu napisany w C#.  
Umożliwia zarządzanie użytkownikami, sprzętem oraz wypożyczeniami, wraz z obsługą limitów, dostępności oraz naliczania opłat za opóźnienia.

System wspiera:
- dodawanie użytkowników (Student, Employee),
- dodawanie sprzętu (Laptop, Camera, Projector),
- wypożyczanie sprzętu,
- zwrot sprzętu (w terminie i po terminie),
- blokowanie operacji niepoprawnych,
- oznaczanie sprzętu jako niedostępnego,
- wyświetlanie raportów.

---

## Struktura projektu

Projekt podzielony jest na warstwy:

### Models
Zawiera klasy domenowe:
- `User`, `Student`, `Employee`
- `Equipement` oraz jego typy (`Laptop`, `Camera`, `Projector`)
- `Rental`

### Services
Zawiera logikę biznesową:
- `RentalService` – obsługa wypożyczeń
- `EquipmentService` – zarządzanie sprzętem
- `UserService` – zarządzanie użytkownikami
- `FeesCalculator` – obliczanie opłat
- `LimitChecker` – kontrola limitów wypożyczeń

---

## Decyzje projektowe

### Podział odpowiedzialności
Zastosowano zasadę pojedynczej odpowiedzialności (SRP):

- `RentalService` odpowiada tylko za wypożyczenia
- `EquipmentService` odpowiada za sprzęt
- `UserService` odpowiada za użytkowników

### Kohezja
Każda klasa ma jasno określony zakres odpowiedzialności:
- `Rental` przechowuje dane wypożyczenia
- `FeesCalculator` liczy opłaty
- `LimitChecker` sprawdza limity

### Coupling (sprzężenie)
Zredukowano sprzężenie między klasami:
- serwisy komunikują się przez metody, nie przez bezpośrednie zależności
- logika nie jest umieszczona w `Program.cs`

### Dziedziczenie
Zastosowano dziedziczenie:
- `Student` i `Employee` dziedziczą po `User`
- różne typy sprzętu dziedziczą po `Equipement`

---

## Dlaczego taki podział?

Podział na Models i Services pozwala:
- oddzielić dane od logiki,
- łatwo rozwijać system,
- testować poszczególne elementy niezależnie,
- zachować czytelność projektu.

---

## Raport systemu

System umożliwia wyświetlenie:
- listy sprzętu wraz ze statusem,
- aktywnych wypożyczeń,
- przeterminowanych wypożyczeń,
- opłat za zwroty.

---

## Instrukcja uruchomienia

### Wymagania
- .NET 6 lub nowszy

### Kroki

1. Sklonuj repozytorium
2. Uruchom projekt: dotnet run
3. Program uruchomi się w konsoli i wyświetli:
- listę użytkowników,
- listę sprzętu,
- przebieg wypożyczeń,
- przykłady błędnych operacji,
- raport końcowy systemu.

### Alternatywnie (Rider / Visual Studio)

- Otwórz projekt
- Ustaw projekt jako startowy
- Kliknij **Run**
