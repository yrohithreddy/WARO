using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharityOrganization.Models
{
    [MetadataType(typeof(LogInCustomerData))]
    public partial class LogInCustomer
    {

    }

    public class LogInCustomerData
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string CustomerPassword { get; set; }
    }
}