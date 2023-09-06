using System;
using System.Collections.Generic;

namespace CarRental.DataModels
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string UserType { get; set; }
    }
}
