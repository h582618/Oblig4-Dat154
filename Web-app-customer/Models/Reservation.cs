namespace Web_app_customer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Reservation
    {
        public Reservation(DateTime dateStart, DateTime dateEnd, int RoomRoomId, string UserUsername)
        {
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.RoomRoomId = RoomRoomId;
            this.UserUsername = UserUsername;
        }

        public Reservation()
        {

        }

        [Key]
        public int ReservationId { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public int RoomRoomId { get; set; }
        public string UserUsername { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}

