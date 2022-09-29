using System.ComponentModel.DataAnnotations;

namespace VacationRental.Domain
{
    public class RentalBindingModel
    {
        [Range(1, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}")]
        public int Units { get; set; }
    }
}
