using System.Collections.Generic;
using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain.Interfaces
{
    public interface IRentalRepository
    {
        RentalViewModel GetNewRental(int id, int units);
        void Add(ref IDictionary<int, RentalViewModel> rentals, int rentalId, int units);
    }
}