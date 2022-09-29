using System;
using System.Collections.Generic;
using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain
{
    public class CalendarDataBindingModel : BookingViewModel
    {
        public CalendarDataBindingModel(int rentalId, DateTime start, int nights, IDictionary<int, BookingCompleteViewModel> bookings, IDictionary<int, RentalPrepTimeViewModel> rentals)
        {
            RentalId = rentalId;
            Start = start;
            Nights = nights;
            Bookings = bookings;
            Rentals = rentals;
        }
        public IDictionary<int, BookingCompleteViewModel> Bookings { get; set; }
        public IDictionary<int, RentalPrepTimeViewModel> Rentals { get; set; }
    }
}
