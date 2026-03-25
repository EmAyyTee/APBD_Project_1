using APBD_Zadanie_Pierwsze.Models;

namespace APBD_Zadanie_Pierwsze.Services;

public class FeesCalculator
{
    private decimal _feePerDay = 2m;

    public decimal CalculateFee(Rental rental)
    {
        if (rental.ReturnDate == null || rental.ReturnDate <= rental.DueDate)
            return 0;

        var daysLate = (rental.ReturnDate.Value - rental.DueDate).Days;
        return daysLate* _feePerDay;
    }
}