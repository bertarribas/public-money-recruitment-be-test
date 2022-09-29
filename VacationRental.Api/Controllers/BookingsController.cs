using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Domain.ViewModels;
using VacationRental.Domain;
using Microsoft.AspNetCore.Http;
using VacationRental.Domain.Interfaces;
using System.Linq;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IDictionary<int, RentalPrepTimeViewModel> _rentals;
        private IDictionary<int, BookingCompleteViewModel> _bookings;
        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IDictionary<int, RentalPrepTimeViewModel> rentals, IDictionary<int, BookingCompleteViewModel> bookings,
                                  IUnitOfWork unitOfWork)
        {
            _rentals = rentals;
            _bookings = bookings;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the booking info with given booking id 
        /// </summary>  
        /// <response code="200">Returns booking info</response>
        /// <response code="400">Booking not found</response>
        [HttpGet]
        [Route("{bookingId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int bookingId)
        {
            ModelState.AddModelError(nameof(Get), Resources.ExceptionMessages.BookingNotFound);
            return !_bookings.ContainsKey(bookingId) ? ValidationProblem(ModelState) : Ok(_bookings[bookingId]);
        }

        /// <summary>
        /// Create a new booking for a rental with start date and number of nights
        /// </summary>  
        /// <response code="201">Returns the newly created booking id</response>
        /// <response code="400">Rental not found</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(BookingBindingModel model)
        {
            int lastUnitBookingRental = 0;

            if (!_rentals.ContainsKey(model.RentalId))
            {
                ModelState.AddModelError(nameof(Get), Resources.ExceptionMessages.RentalNotFound);
                return ValidationProblem(ModelState);
            }
            else
            {
                if (_bookings.Count > 0)
                {
                    for (var i = 0; i < model.Nights; i++)
                    {
                        int bookedUnits = _unitOfWork.BookingsComplete.GetOccupiedUnits(model, _bookings, _rentals[model.RentalId].PreparationTimeInDays);

                        if (bookedUnits >= _rentals[model.RentalId].Units)
                        {
                            ModelState.AddModelError(nameof(Get), Resources.ExceptionMessages.RentalNotAvailable);
                            return ValidationProblem(ModelState);
                        }
                    }
                    lastUnitBookingRental = _bookings.Where(ri => ri.Value.RentalId == model.RentalId).Select(u => u.Value.Unit).LastOrDefault();
                }
                if (lastUnitBookingRental < _rentals[model.RentalId].Units) lastUnitBookingRental += 1;                

                var resourceId = _unitOfWork.ResourceId.GetNewResourceId(_bookings.Keys.Count);

                _unitOfWork.BookingsComplete.Add(ref _bookings, resourceId.Id, model, lastUnitBookingRental);
                return CreatedAtAction(nameof(Post), resourceId);
            }
        }
    }
}
