using System.Collections.Generic;
using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain.Interfaces
{
    public interface IRentalPrepTimeRepository
    {
        void Add(ref IDictionary<int, RentalPrepTimeViewModel> rentals, int rentalId, RentalPrepTimeBindingModel model);
    }
}