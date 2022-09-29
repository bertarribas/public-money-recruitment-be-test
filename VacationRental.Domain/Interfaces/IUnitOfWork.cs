namespace VacationRental.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRentalRepository Rentals { get; }
        IRentalPrepTimeRepository RentalsPrepTime { get; }
        IResourceIdViewModelRepository ResourceId { get; }
        IBookingRepository Bookings { get; }
        IBookingCompleteRepository BookingsComplete { get; }
        ICalendarRepository Calendars { get; }
        ICalendarCompleteRepository CalendarsComplete { get; }
        ICalendarDataRepository CalendarsData { get; }
        ICalendarDateRepository CalendarDates { get; }

        CalendarDataBindingModel CalendarsDataBM(CalendarDataBindingModel calendarDataBindingModel);
    }
}
