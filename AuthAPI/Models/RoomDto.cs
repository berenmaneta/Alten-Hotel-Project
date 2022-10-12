namespace AltenAPI.Models
{
    public class RoomDto
    {
        public int roomId { get; set; }
        public int hotelId { get; set; }
        public int number { get; set; }
        public HotelDto hotel { get; set; } = new HotelDto();
    }
}
