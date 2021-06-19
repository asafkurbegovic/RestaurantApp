using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}
