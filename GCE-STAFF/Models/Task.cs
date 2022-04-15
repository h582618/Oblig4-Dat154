using System;
namespace Web_app_customer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public partial class Task
    {

        [Key]
        public int TaskId { get; set; }
        public string Note { get; set; }
        public string Info { get; set; }
        public int State { get; set; }
        public int Type { get; set; }
        public int RoomRoomId { get; set; }

        //[JsonIgnore]
        public virtual Room Room { get; set; }
    }
}
