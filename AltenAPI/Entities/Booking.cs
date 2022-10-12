using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltenAPI.Entities
{
    [Table("tbBooking")]
    public class Booking
    {
        [Key]
        public Guid bookingNumber { get; set; }
        public int userId { get; set; }
        public int roomId { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isCancelled { get; set; }

    }
}
