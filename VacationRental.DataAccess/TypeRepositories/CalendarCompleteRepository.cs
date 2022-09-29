using System.Collections.Generic;
using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;
using VacationRental.Domain;

namespace VacationRental.DataAccess.TypeRepositories
{
    public class CalendarCompleteRepository : ICalendarCompleteRepository
    {
        public CalendarCompleteViewModel CreateCalendar(CalendarDataBindingModel calendarData) {
            var calendar = new CalendarCompleteViewModel
            {
                Dates = new List<CalendarDateCompleteViewModel>()
            };            
            return calendar;
        }
    }
}
