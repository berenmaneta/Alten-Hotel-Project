using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltenAPI.Entities
{
    [Table("tbHotel")]
    public class Hotel
    {
        [Key]
        public int hotelId { get; set; }
        public string name { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
    }
}
