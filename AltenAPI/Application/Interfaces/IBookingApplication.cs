using AltenAPI.Models;

namespace AltenAPI.Application.Interfaces
{
    public interface IBookingApplication
    {
        Task<IEnumerable<BookingDto>> ListAllBookings();
        Task<IEnumerable<BookingDto>> ListBooking(string userId);      
        Task<BookingDto> GetBooking(string bookingNumber);
        Task<int> CreateBooking(BookingDto booking, string userId);                   
        Task<int> UpdateBooking(BookingDto booking, string userId);
        Task<int> CancelBooking(string id, string userId);
        Task<int> DeleteBooking(string id, string userId);
        Task<bool> CheckAvailability(BookingDto dto);
        Task<bool> GetAvailability(BookingDto dto);
    }
}
