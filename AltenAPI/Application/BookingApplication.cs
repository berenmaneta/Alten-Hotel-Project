using AltenAPI.Application.Interfaces;
using AltenAPI.Entities;
using AltenAPI.Models;
using AltenAPI.Repository.Interfaces;
using AltenAPI.Utils;
using AutoMapper;
using System.Reflection;

namespace AltenAPI.Application
{
    public class BookingApplication : IBookingApplication
    {

        private readonly IBookingRepository bookingRepository;
        private IMapper mapper;

        public BookingApplication(IBookingRepository _bookingRepository, IMapper _mapper)
        {
            this.bookingRepository = _bookingRepository;
            this.mapper = _mapper;
        }

        public async Task<IEnumerable<BookingDto>> ListAllBookings()
        {
            try
            {
                var list = await bookingRepository.ListAllBookings();
                var listDto = mapper.Map<List<BookingDto>>(list);
                return listDto;
            }
            catch (Exception ex)
            {
                throw new BookingException("An error occurred while listing the bookings!");
            }
        }

        public async Task<IEnumerable<BookingDto>> ListBooking(string userId)
        {
            try
            {
                var list = await bookingRepository.ListBooking(userId);
                var listDto = mapper.Map<List<BookingDto>>(list);
                return listDto;
            }
            catch (Exception ex)
            {
                throw new BookingException("An error occurred while listing the booking!");
            }

        }

        public async Task<BookingDto> GetBooking(string bookingNumber)
        {
            try
            {
                var booking = await bookingRepository.GetBooking(bookingNumber);
                if (booking != null)
                {
                    var bookingDto = mapper.Map<BookingDto>(booking);
                    return bookingDto;
                }
                else
                {
                    throw new BookingException("We could not get the booking information!");
                }                                    
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public async Task<int> CreateBooking(BookingDto booking, string userId)
        {
            try
            {
                var bkn = this.MountingBooking(booking, userId);
                var available = CheckAvailability(booking).Result;
                if (ValidateCreateBooking(booking) && available)
                {
                    var result = await bookingRepository.CreateBooking(bkn);
                    return result;
                }
                else
                    return -1;
            }
            catch (MissingUserInfoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        public async Task<int> UpdateBooking(BookingDto booking, string userId)
        {
            try
            {
                var upBooking = await bookingRepository.UpdateBooking(booking, userId);
                return upBooking;

            }
            catch(Exception ex)
            {
                throw new BookingException("An error occurred while updating the booking!");
            }
            
        }

        public async Task<int> CancelBooking(string id, string userId)
        {
            try
            {
                var cancelled = await bookingRepository.CancelBooking(id, userId);
                return cancelled;

            }
            catch(Exception ex)
            {
                throw new BookingException("An error occurred while updating the booking!");
            }
            
        }

        public async Task<int> DeleteBooking(string id, string userId)
        {
            try
            {
                var deleted = await bookingRepository.DeleteBooking(id, userId);
                return deleted;

            }
            catch (Exception ex)
            {
                throw new BookingException("An error occurred while deleting the booking!");
            }        
        }


        public async Task<bool> CheckAvailability(BookingDto dto)
        {
            try
            {
                var available = await bookingRepository.CheckAvailability(dto);
                return available;
            }
            catch(BookingException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool ValidateCreateBooking(BookingDto dto)
        {
            if (dto != null)
            {
                foreach (PropertyInfo prop in dto.GetType().GetProperties())
                {
                    if (prop.Name.Equals("beginDate") && prop.GetValue(dto) == null)
                        throw new MissingUserInfoException("Begin date not provided!");

                    if (prop.Name.Equals("endDate") && prop.GetValue(dto) == null)
                        throw new MissingUserInfoException("End date not provided!");
                }
            }

            return true;
        }

        private Booking MountingBooking(BookingDto dto, string userId)
        {
            try
            {
                var bkn = mapper.Map<Booking>(dto);

                // WHEN THE SYSTEM EXPAND, IT WILL BE POSSIBLE TO BOOK THER ROOMS
                // FOR NOW, SINCE WE ONLY HAVE ONE ROOM, WE SET THE ID OF THE ONLY ROOM
                bkn.roomId = 1; 

                // SET THE USER ID TO THE BOOKING
                int id = 0;
                var convert = Int32.TryParse(userId, out id);
                if (convert)
                    bkn.userId = id;
                else
                    throw new MissingUserInfoException("User Id not provided!");

                // SINCE WE ARE BOOKING A ROOM, THE BOOKING IS NOT CANCELLED 
                bkn.isCancelled = false;

                if ((dto.beginDate.Value - DateTime.Now).Days == 0)
                    throw new BookingForTodayException("The reservation must start, at least, on the nex day of booking!");

                if ((dto.beginDate.Value - DateTime.Now).TotalDays > 30)
                    throw new BookingTooFarException("The room can't be reserved more than 30 days in advance!");

                if ((dto.endDate.Value - dto.beginDate.Value).TotalDays > 3)
                    throw new BookingTooLongException("The stay can't be longer than 3 days!");

                return bkn;
            }
            catch(BookingTooLongException ex)
            {
                throw;
            }
            catch(BookingTooFarException ex)
            {
                throw;
            }
            catch(BookingForTodayException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new MissingUserInfoException("User Id not provided!");
            }   
        }

        public async Task<bool> GetAvailability(BookingDto dto)
        {
            var available = await bookingRepository.GetAvailability(dto);
            return available;
        }
    }
}
