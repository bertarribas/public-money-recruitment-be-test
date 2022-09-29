using VacationRental.DataAccess.TypeRepositories;
using VacationRental.Domain;
using VacationRental.Domain.Interfaces;

namespace VacationRental.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Rentals = new RentalRepository();
            RentalsPrepTime = new RentalPrepTimeRepository();
            ResourceId = new ResourceIdViewModelRepository();
            Bookings = new BookingRepository();
            Calendars = new CalendarRepository();
            CalendarsData = new CalendarDataRepository();
            CalendarDates = new CalendarDateRepository();
            CalendarsComplete = new CalendarCompleteRepository();
            BookingsComplete = new BookingCompleteRepository();
        }
        public IRentalRepository Rentals { get; private set; }
        public IRentalPrepTimeRepository RentalsPrepTime { get; private set; }
        public IResourceIdViewModelRepository ResourceId { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IBookingCompleteRepository BookingsComplete { get; private set; }
        public ICalendarRepository Calendars { get; private set; }
        public ICalendarCompleteRepository CalendarsComplete { get; private set; }
        public ICalendarDataRepository CalendarsData { get; private set; }
        public ICalendarDateRepository CalendarDates { get; private set; }

        public CalendarDataBindingModel CalendarsDataBM(CalendarDataBindingModel calendarDataBindingModel)
        {
            return new CalendarDataBindingModel(calendarDataBindingModel.RentalId, calendarDataBindingModel.Start, calendarDataBindingModel.Nights, calendarDataBindingModel.Bookings, calendarDataBindingModel.Rentals);
        }
    }
}
