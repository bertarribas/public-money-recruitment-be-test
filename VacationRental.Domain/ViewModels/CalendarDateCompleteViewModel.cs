using System;
using System.Collections.Generic;

namespace VacationRental.Domain.ViewModels
{
    public class CalendarDateCompleteViewModel 
    {
        public DateTime Date { get; set; }
        public List<CalendarBookingCompleteViewModel> Bookings { get; set; }
        public List<CalendarPreparationTimesViewModel> PreparationTimes { get; set; }
    }
}
