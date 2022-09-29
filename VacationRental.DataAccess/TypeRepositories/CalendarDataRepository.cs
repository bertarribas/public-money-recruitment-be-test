using VacationRental.Domain;
using VacationRental.Domain.Interfaces;

namespace VacationRental.DataAccess.TypeRepositories
{
    public class CalendarDataRepository : ICalendarDataRepository
    {
        public string Validate(CalendarDataBindingModel calendarData)
        {
            return !calendarData.Rentals.ContainsKey(calendarData.RentalId)
                ? Resources.ExceptionMessages.RentalNotFound
                : calendarData.Nights <= 0 ? Resources.ExceptionMessages.NightsGreater0 : string.Empty;
        }
    }

}
