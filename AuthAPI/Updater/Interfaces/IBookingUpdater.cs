using AltenAPI.Entities;
using AltenAPI.Models;

namespace AltenAPI.Updater.Interfaces
{
    public interface IBookingUpdater
    {
        Booking UpdateBooking(Booking bkn, BookingDto booking);
    }
}
