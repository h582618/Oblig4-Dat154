using System;
namespace Web_app_customer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Reservation
    {


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
