﻿using BAISTGolfCourse.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Models
{
    public partial class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public string PasswordSalt { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
    }
}
