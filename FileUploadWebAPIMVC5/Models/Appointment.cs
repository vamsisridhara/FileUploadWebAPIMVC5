using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileUploadWebAPIMVC5.Models
{
    public class Appointment
    {
        [Required(ErrorMessage = "please select")]
        public string ClientName { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Please select date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="please select")]
        public bool TermsAccepted { get; set; }
    }
}