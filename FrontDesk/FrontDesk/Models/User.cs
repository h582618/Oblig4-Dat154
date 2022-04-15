using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_app_customer.Models
{

    public partial class User
    {
        
        public User()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Key]
        public string Username { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
