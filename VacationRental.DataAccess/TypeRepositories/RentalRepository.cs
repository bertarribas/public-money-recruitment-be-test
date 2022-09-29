using System.Collections.Generic;
using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;

namespace VacationRental.DataAccess.TypeRepositories
{
    public class RentalRepository : IRentalRepository
    {
        public void Add(ref IDictionary<int, RentalViewModel> rentals, int rentalId, int units)
        {
            rentals.Add(rentalId, new RentalViewModel
            {
                Id = rentalId,
                Units = units
            });
        }
        public RentalViewModel GetNewRental(int id, int units) => new RentalViewModel { Id = id, Units = units };
    }
}
