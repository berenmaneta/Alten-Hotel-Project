using AltenAPI.Entities;
using AltenAPI.Models;

namespace AltenAPI.Repository.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> ListAllBookings();     
        Task<IEnumerable<Booking>> ListBooking(string userId);  
        Task<Booking> GetBooking(string bookingNumber);
        Task<int> CreateBooking(Booking booking);     
        Task<int> UpdateBooking(BookingDto booking, string userId);
        Task<int> CancelBooking(string id, string userId);
        Task<int> DeleteBooking(string id, string userId);
        Task<bool> CheckAvailability(BookingDto dto);
        Task<bool> GetAvailability(BookingDto dto);
    }
}
