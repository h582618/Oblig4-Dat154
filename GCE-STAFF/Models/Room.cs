using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_app_customer.Models
{
    public partial class Room
    {

        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int RoomId { get; set; }
        public int NumOfBeds { get; set; }
        public int Size { get; set; }


        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }


    
}
