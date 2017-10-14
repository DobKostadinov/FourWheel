using FourWheels.Common;
using System.ComponentModel.DataAnnotations;

namespace FourWheels.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(DataModelsConstants.MinLengthUsername,
            ErrorMessage = ErrorMessages.LengthEqualOrGreater)]
        [MaxLength(DataModelsConstants.MaxLengthUsername,
            ErrorMessage = ErrorMessages.LengthEqualOrLess)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(DataModelsConstants.PhoneRegex, 
            ErrorMessage = ErrorMessages.PhoneNumberNotValid)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(DataModelsConstants.MinLengthUserFullName,
            ErrorMessage = ErrorMessages.LengthEqualOrGreater)]
        [MaxLength(DataModelsConstants.MaxLengthUserFullName,
            ErrorMessage = ErrorMessages.LengthEqualOrLess)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(DataModelsConstants.MinLengthPassword,
            ErrorMessage = ErrorMessages.LengthEqualOrGreater)]
        [MaxLength(DataModelsConstants.MaxLengthPassword,
            ErrorMessage = ErrorMessages.LengthEqualOrLess)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = ErrorMessages.PassNotMatchWithConfirmPass)]
        public string ConfirmPassword { get; set; }
    }
}