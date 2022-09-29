using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Domain;
using VacationRental.Domain.Interfaces;
using VacationRental.Domain.ViewModels;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IDictionary<int, RentalPrepTimeViewModel> _rentals;
        private readonly IUnitOfWork _unitOfWork;

        public RentalsController(IDictionary<int, RentalPrepTimeViewModel> rentals, IUnitOfWork unitOfWork)
        {
            _rentals = rentals;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the rental id and its number of units with given rental id
        /// </summary>  
        /// <response code="200">Returns rental id and its units</response>
        /// <response code="400">Rental not found</response>
        [HttpGet]
        [Route("{rentalId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int rentalId)
        {
            ModelState.AddModelError(nameof(Get), Resources.ExceptionMessages.RentalNotFound);
            return !_rentals.ContainsKey(rentalId) ? ValidationProblem(ModelState) : Ok(_unitOfWork.Rentals.GetNewRental(rentalId, _rentals[rentalId].Units));
        }

        /// <summary>
        /// Create a new rental with number of units and number of preparation days
        /// </summary>  
        /// <response code="201">Returns the newly created rental id</response>        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(RentalPrepTimeBindingModel model)
        { 
            var resourceId = _unitOfWork.ResourceId.GetNewResourceId(_rentals.Keys.Count);

            _unitOfWork.RentalsPrepTime.Add(ref _rentals, resourceId.Id, model);
            return CreatedAtAction(nameof(Post), resourceId);
        }
    }
}
