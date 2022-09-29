using System.Collections.Generic;
using VacationRental.Domain;
using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;

namespace VacationRental.DataAccess.TypeRepositories
{
    public class RentalPrepTimeRepository :  IRentalPrepTimeRepository
    {
        public void Add(ref IDictionary<int, RentalPrepTimeViewModel> rentals, int rentalId, RentalPrepTimeBindingModel model)
        {
            rentals.Add(rentalId, new RentalPrepTimeViewModel
            {
                Id = rentalId,
                Units = model.Units,
                PreparationTimeInDays = model.PreparationTimeInDays
            });
        }
    }
}
