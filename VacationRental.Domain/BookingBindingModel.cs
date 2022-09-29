using System;
using System.ComponentModel.DataAnnotations;

namespace  VacationRental.Domain
{
    public class BookingBindingModel
    {
        public int RentalId { get; set; }

        public DateTime Start
        {
            get => _startIgnoreTime;
            set => _startIgnoreTime = value.Date;
        }

        private DateTime _startIgnoreTime;

        [Range(1, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}")]
        public int Nights { get; set; }
    }
}
