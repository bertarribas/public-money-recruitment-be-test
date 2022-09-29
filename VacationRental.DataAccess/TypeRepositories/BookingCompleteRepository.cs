using System.Collections.Generic;
using VacationRental.Domain;
using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;

namespace VacationRental.DataAccess.TypeRepositories
{
    public class BookingCompleteRepository : IBookingCompleteRepository
    {
        public void Add(ref IDictionary<int, BookingCompleteViewModel> bookings, int bookingId, BookingBindingModel model, int unit)
        {
            bookings.Add(bookingId, new BookingCompleteViewModel
            {
                Id = bookingId,
                Nights = model.Nights,
                RentalId = model.RentalId,
                Start = model.Start.Date,
                Unit = unit
            });
        }

        public int GetOccupiedUnits(BookingBindingModel model, IDictionary<int, BookingCompleteViewModel> _bookings, int preparationTimeInDays)
        {
            var bookedUnits = 0;
            foreach (var booking in _bookings.Values)
            {
                if (booking.RentalId == model.RentalId
                    && ((booking.Start <= model.Start.Date && booking.Start.AddDays(booking.Nights).AddDays(preparationTimeInDays) > model.Start.Date)
                    || (booking.Start < model.Start.AddDays(model.Nights) && booking.Start.AddDays(booking.Nights).AddDays(preparationTimeInDays) >= model.Start.AddDays(model.Nights))
                    || (booking.Start > model.Start && booking.Start.AddDays(booking.Nights).AddDays(preparationTimeInDays) < model.Start.AddDays(model.Nights))))
                {
                    bookedUnits++;
                }
            }
            return bookedUnits;
        }
    }
}
