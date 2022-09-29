using System.Collections.Generic;
using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;
using VacationRental.Domain;

namespace VacationRental.DataAccess.TypeRepositories
{
    public class CalendarRepository : ICalendarRepository
    {
        public CalendarViewModel CreateCalendar(CalendarDataBindingModel calendarData) {
            var calendar = new CalendarViewModel
            {
                Dates = new List<CalendarDateViewModel>()
            };            
            return calendar;
        }
    }
}
