using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Domain;
using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;


namespace VacationRental.Api.Controllers
{
    [Route("api/v1/calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IDictionary<int, RentalPrepTimeViewModel> _rentals;
        private readonly IDictionary<int, BookingCompleteViewModel> _bookings;
        private readonly IUnitOfWork _unitOfWork;

        public CalendarController(
            IDictionary<int, RentalPrepTimeViewModel> rentals,
            IDictionary<int, BookingCompleteViewModel> bookings,
            IUnitOfWork unitOfWork)
        {
            _rentals = rentals;
            _bookings = bookings;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the booking info and preparation time for a rental from a start date to the number of nights given
        /// </summary>
        /// <response code="200">Returns calendar info from a date: bookings and preparation time</response>
        /// <response code="400">Rental not found or number of nights not greater than 0</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int rentalId, DateTime start, int nights)
        {          
            CalendarDataBindingModel calendarData = _unitOfWork.CalendarsDataBM(new CalendarDataBindingModel(rentalId, start, nights, _bookings, _rentals));

            string validationError = _unitOfWork.CalendarsData.Validate(calendarData);
            if (String.IsNullOrEmpty(validationError))
            {
                CalendarCompleteViewModel calendar = _unitOfWork.CalendarsComplete.CreateCalendar(calendarData);

                _unitOfWork.CalendarDates.CreateCalendarDates(ref calendar, calendarData);
                return Ok(calendar);
            }
            else
            {
                ModelState.AddModelError(nameof(Get), validationError);
                return ValidationProblem(ModelState);
            }            
        }
    }
}
