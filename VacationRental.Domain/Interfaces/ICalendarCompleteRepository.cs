using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain.Interfaces
{
    public interface ICalendarCompleteRepository
    {
        CalendarCompleteViewModel CreateCalendar(CalendarDataBindingModel calendarData);
    }
}
