using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TripStyle.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
        public string Birthdate { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public Basket Basket { get; set; }
        public int BasketId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public List<Address> Addresses { get; set; }

    }
}