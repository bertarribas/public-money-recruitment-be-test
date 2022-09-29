namespace VacationRental.Domain.Interfaces
{
    public interface ICalendarDataRepository
    {        
        string Validate(CalendarDataBindingModel calendarData);
    }
}
