using System;
using System.Collections.Generic;
using System.Text;

namespace BookingResource.Application.Helper
{
    public class RequestResponse
    {
        public const string RequiredNotAvailable = "Error, Required quantity greater than available quantity";
        public const string ModelStateNotValid = "Model Not Valid";
        public const string SuccessBooking = "Success, Resource booked successfully";
        public const string FailTooBookUnExpected = "Error, failed to book resource";
    }
}
