using System;
using System.Collections.Generic;
using System.Text;

namespace BookingResource.Application.BookingValidation.ErrorModel
{
    public class BookingValidationResultDto
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
