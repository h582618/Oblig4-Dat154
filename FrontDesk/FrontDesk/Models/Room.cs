using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Web_app_customer.Models
{
    public class Room
    {


        [Key]
        public int RoomId { get; set; }
        public int NumOfBeds { get; set; }
        public int Size { get; set; }


        public virtual ICollection<Reservation> Reservations { get; private set; } =
            new ObservableCollection<Reservation>();

        public virtual ICollection<Task> Tasks { get; private set; } =
            new ObservableCollection<Task>();
    }


    
}
