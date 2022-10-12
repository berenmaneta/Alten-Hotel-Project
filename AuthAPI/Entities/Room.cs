using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltenAPI.Entities
{
    [Table("tbRoom")]
    public class Room
    {
        [Key]
        public int roomId { get; set; }
        public int hotelId { get; set; }
        public int number { get; set; }
    }
}
