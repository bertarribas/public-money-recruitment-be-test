using System.Collections.Generic;
using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain.Interfaces
{
    public interface IBookingCompleteRepository
    {
        void Add(ref IDictionary<int, BookingCompleteViewModel> bookings, int bookingId, BookingBindingModel model, int unit);
        int GetOccupiedUnits(BookingBindingModel model, IDictionary<int, BookingCompleteViewModel> _bookings, int preparationTimeInDays);
    }
}
