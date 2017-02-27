using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharityOrganization.Models
{
    [MetadataType(typeof(CreateAccountData))]
    public partial class CreateAccount
    {
    }

    public class CreateAccountData
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(32, ErrorMessage = "The First Name should be of length greater than 3 characters", MinimumLength = 4)]
        [RegularExpression("^([a-zA-Z '-]+)$", ErrorMessage = "Enter only alphabets with hyphen allowed")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(32, ErrorMessage = "The Last Name should be of length greater than 3 characters", MinimumLength = 4)]
        [RegularExpression("^([a-zA-Z '-]+)$", ErrorMessage = "Enter only alphabets with hyphen allowed")]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [Display(Name = "Verify Email address")]
        [Compare("EmailAddress")]
        public string VerifyEmailAddress { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone Number should be of format xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string CurrentAddress { get; set; }

        [Required]
        [Display(Name = "Create Password")]
        [DataType(DataType.Password)]
        public string CreatePassword { get; set; }

        [Required]
        [Display(Name = "Verify Password")]
        [DataType(DataType.Password)]
        [Compare("CreatePassword")]
        public string VerifyPassword { get; set; }
    }
}