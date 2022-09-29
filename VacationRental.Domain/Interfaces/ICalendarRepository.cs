using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain.Interfaces
{
    public interface ICalendarRepository
    {
        CalendarViewModel CreateCalendar(CalendarDataBindingModel calendarData);
    }
}
