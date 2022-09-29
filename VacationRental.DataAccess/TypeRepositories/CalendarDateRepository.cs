using System.Collections.Generic;
using System.Linq;
using VacationRental.Domain;
using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;

namespace VacationRental.DataAccess.TypeRepositories
{
    public class CalendarDateRepository : ICalendarDateRepository
    {
        public void CreateCalendarDates(ref CalendarCompleteViewModel calendar, CalendarDataBindingModel calendarData)
        {
            for (var i = 0; i < calendarData.Nights; i++)
            {
                var date = new CalendarDateCompleteViewModel
                {
                    Date = calendarData.Start.Date.AddDays(i),
                    Bookings = new List<CalendarBookingCompleteViewModel>(),
                    PreparationTimes = new List<CalendarPreparationTimesViewModel>()
                };

                foreach (var booking in calendarData.Bookings.Values)
                {
                    if (booking.RentalId == calendarData.RentalId)
                    {
                        if (booking.Start <= date.Date && booking.Start.AddDays(booking.Nights) > date.Date)
                        {
                            date.Bookings.Add(new CalendarBookingCompleteViewModel { Id = booking.Id, Unit = booking.Unit });
                        }
                        else {
                            int preparationTimeInDays = calendarData.Rentals.Where(r => r.Value.Id == booking.RentalId).Select(ptd => ptd.Value.PreparationTimeInDays).FirstOrDefault();
                            if (preparationTimeInDays > 0 && booking.Start.AddDays(booking.Nights).AddDays(preparationTimeInDays) > date.Date)
                            {
                                date.PreparationTimes.Add(new CalendarPreparationTimesViewModel { Unit = booking.Unit });
                            }
                        }
                    }
                }
                calendar.Dates.Add(date);
            }
        }
    }
}
