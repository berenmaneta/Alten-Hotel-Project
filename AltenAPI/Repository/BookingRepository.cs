using AltenAPI.DbContexts;
using AltenAPI.Entities;
using AltenAPI.Models;
using AltenAPI.Repository.Interfaces;
using AltenAPI.Updater;
using AltenAPI.Utils;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AltenAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext db;
        private readonly BookingUpdater bookingUpdater;

        public BookingRepository(ApplicationDbContext _db, BookingUpdater _bookingUpdater)
        {
            this.db = _db;
            this.bookingUpdater = _bookingUpdater;
        }

        public async Task<IEnumerable<Booking>> ListAllBookings()
        {
            return await db.Bookings.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Booking>> ListBooking(string userId)
        {
            return await db.Bookings.AsNoTracking().Where(x => x.userId.ToString().Equals(userId)).ToListAsync();
        }

        public async Task<Booking> GetBooking(string bookingNumber)
        {
            var booking = await db.Bookings.AsNoTracking().Where(x => x.bookingNumber.ToString().Equals(bookingNumber)).FirstOrDefaultAsync();
            return booking;        
        }

        public async Task<int> CreateBooking(Booking booking)
        {
            await db.Bookings.AddAsync(booking);
            var inserted = await db.SaveChangesAsync();
            return 1;         
        }

        public async Task<int> UpdateBooking(BookingDto booking, string userId)
        {
            var bkn = await db.Bookings.Where(x => x.bookingNumber.ToString().ToLower().Equals(booking.bookingNumber.ToString().ToLower())).FirstOrDefaultAsync();
            if (bkn != null)
            {
                if (bkn.userId.ToString().Equals(userId))
                {
                    bkn = bookingUpdater.UpdateBooking(bkn, booking);
                    db.Bookings.Attach(bkn);
                    db.Bookings.Update(bkn);
                    await db.SaveChangesAsync();
                    return 1;
                }
                else
                    return -1;
            }
            return 0;

        }

        public async Task<int> CancelBooking(string id, string userId)
        {
            var bkn = await db.Bookings.Where(x => x.bookingNumber.ToString().ToLower().Equals(id.ToLower())).FirstOrDefaultAsync();
            if (bkn != null)
            {
                if (bkn.userId.ToString().Equals(userId))
                {
                    bkn = bookingUpdater.CancelBooking(bkn);
                    db.Bookings.Attach(bkn);
                    db.Bookings.Update(bkn);
                    await db.SaveChangesAsync();
                    return 1;
                }
                else
                    return -1;
            }
            return 0;

        }

        public async Task<int> DeleteBooking(string id, string userId)
        {        
            var bkn = await db.Bookings.Where(x => x.bookingNumber.ToString().Equals(id)).FirstOrDefaultAsync();
            if (bkn != null)
            {
                if(bkn.userId.ToString().Equals(userId))
                {
                    db.Bookings.Attach(bkn);
                    db.Bookings.Remove(bkn);
                    await db.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    return -1;
                }  
            }
            return 0;
        }

        public async Task<bool> CheckAvailability(BookingDto dto)
        {
            var notAvailable = await db.Bookings.AsNoTracking()
            .Where(x =>
            (x.beginDate.Date >= dto.beginDate.Value.Date && x.beginDate.Date <= dto.endDate.Value.Date) ||
            (x.endDate.Date >= dto.beginDate.Value.Date && x.endDate <= dto.endDate.Value.Date))
            .FirstOrDefaultAsync();

            if (notAvailable != null)
            {
                throw new BookingException("The room is not available!");
            }

            return true;
        }

        public async Task<bool> GetAvailability(BookingDto dto)
        {
            var notAvailable = await db.Bookings.AsNoTracking()
            .Where(x => 
            (x.beginDate.Date >= dto.beginDate.Value.Date && x.beginDate.Date <= dto.endDate.Value.Date) || 
            (x.endDate.Date >= dto.beginDate.Value.Date && x.endDate <= dto.endDate.Value.Date))
            .FirstOrDefaultAsync();

            if (notAvailable != null)
            {
                return false;
            }

            return true;
        }





    }
}
