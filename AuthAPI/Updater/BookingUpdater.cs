using AltenAPI.Entities;
using AltenAPI.Models;
using AltenAPI.Updater.Interfaces;

namespace AltenAPI.Updater
{
    public class BookingUpdater : IBookingUpdater
    {
        public Booking UpdateBooking(Booking bkn, BookingDto booking)
        {
            bkn.beginDate = booking.beginDate.HasValue ? booking.beginDate.Value : bkn.beginDate;
            bkn.endDate = booking.endDate.HasValue ? booking.endDate.Value : bkn.endDate;
            bkn.isCancelled = booking.isCancelled.HasValue ? booking.isCancelled.Value : bkn.isCancelled;
            return bkn;
        }

        public Booking CancelBooking(Booking bkn)
        {
            bkn.isCancelled = true;
            return bkn;
        }
    }
}
