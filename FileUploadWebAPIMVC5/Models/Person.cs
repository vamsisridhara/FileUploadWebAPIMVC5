using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadWebAPIMVC5.Models
{
    public class Person
    {
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }
        [DataType(DataType.MultilineText)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; }
        public bool IsApproved { get; set; }
        [UIHint("Enum")]
        public Role Role { get; set; }
    }
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
    public enum Role
    {
        Admin,
        User,
        Guest
    }
}