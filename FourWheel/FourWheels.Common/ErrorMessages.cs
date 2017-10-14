using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourWheels.Common
{
    public class ErrorMessages
    {
        public const string LengthEqualOrGreater = "{0} should be equal or greather than {1}";
        public const string LengthEqualOrLess = "{0} should be equal or less than {1}";
        public const string RangeShouldBeBetween = "{0} should be between {1} and {2}";

        // Registration
        public const string PassNotMatchWithConfirmPass = "The password and confirmation password do not match.";
        public const string PhoneNumberNotValid = "{0} should be exactly 10 digits";
    }
}
