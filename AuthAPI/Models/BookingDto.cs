namespace AltenAPI.Models
{
    public class BookingDto
    {
        public Guid? bookingNumber { get; set; }
        public int? userId { get; set; }
        public DateTime? beginDate { get; set; }
        public DateTime? endDate { get; set; }
        public bool? isCancelled { get; set; }
    }
}
