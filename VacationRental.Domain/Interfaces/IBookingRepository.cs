using System.Collections.Generic;
using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain.Interfaces
{
    public interface IBookingRepository
    {
        void Add(ref IDictionary<int, BookingViewModel> bookings, int bookingId, BookingBindingModel model);
        int GetOccupiedUnits(BookingBindingModel model, IDictionary<int, BookingViewModel> _bookings, int preparationTimeInDays);
    }
}
