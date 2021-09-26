using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingResource.Application.Booking.Dto
{
    public class BookResourceDto : IValidatableObject
    {
        [Required]
        public int ResourceId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public bool Validated { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateFrom >= DateTo)
            {
                yield return new ValidationResult("Date To must be greater Than Date From.");
            }
            if(DateFrom < DateTime.Now)
            {
                yield return new ValidationResult("Date To must be greater Now.");
            }
            if (Quantity <= 0)
            {
                yield return new ValidationResult("Quantity must be greater Than 0.");
            }
        }
    }
}
