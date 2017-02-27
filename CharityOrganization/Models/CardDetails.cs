using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharityOrganization.Models
{
    [MetadataType(typeof(SaveCardDetailsData))]
    public partial class SaveCardDetails
    {
        
    }

    public class SaveCardDetailsData
    {
        [Required]
        [Display(Name = "Name On Card")]
        public string NameOnCard { get; set; }

        [Required]
        [Display(Name ="Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name ="Card Expiry Date")]
        public string CardExpiryDate { get; set; }

        [Required]
        [Display(Name ="Card CVV")]
        public string CardCVV { get; set; }
    }
}