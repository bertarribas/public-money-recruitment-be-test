using VacationRental.Domain.ViewModels;

namespace VacationRental.Domain.Interfaces
{
    public interface ICalendarDateRepository
    {
        void CreateCalendarDates(ref CalendarCompleteViewModel calendar, CalendarDataBindingModel calendarData);
    }
}
