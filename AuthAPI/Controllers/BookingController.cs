using AltenAPI.Application.Interfaces;
using AltenAPI.Models;
using AltenAPI.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static AltenAPI.Utils.MessageEnums;

namespace AltenAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Cors.EnableCors("CorsAlten")]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingApplication bookingApplication;

        public BookingController(IBookingApplication _bookingApplication)
        {
            this.bookingApplication = _bookingApplication;  
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("list")]
        public async Task<IResult> ListBooking()
        {
            var userId = this.User.Claims.Where(c => c.Type.Equals("UserID")).Select(c => c.Value).SingleOrDefault();
            var list = await bookingApplication.ListBooking(userId);
            return Results.Ok(list);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("listAll")]
        public async Task<IResult> ListAllBookings()
        {
            var list = await bookingApplication.ListAllBookings();
            return Results.Ok(list);
        }

        [HttpGet("get")]
        public async Task<IResult> GetBooking(string id)
        {
            var booking = await bookingApplication.GetBooking(id);
            return Results.Ok(booking);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("create")]
        public async Task<IResult> CreateBooking(BookingDto booking)
        {
            var userId = this.User.Claims.Where(c => c.Type.Equals("UserID")).Select(c => c.Value).SingleOrDefault();
            var created = await bookingApplication.CreateBooking(booking, userId);
            return Results.Ok(MessageEnums.GetEnumDescription((CreateMessageEnum)created));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("delete")]
        public async Task<IResult> DeleteBooking(string id)
        {
            var userId = this.User.Claims.Where(c => c.Type.Equals("UserID")).Select(c => c.Value).SingleOrDefault();
            var deleted = await bookingApplication.DeleteBooking(id, userId);
            return Results.Ok(MessageEnums.GetEnumDescription((DeleteMessageEnum)deleted));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("update")]
        public async Task<IResult> UpdateBooking(BookingDto booking)
        {
            var userId = this.User.Claims.Where(c => c.Type.Equals("UserID")).Select(c => c.Value).SingleOrDefault();
            var updated = await bookingApplication.UpdateBooking(booking, userId);
            return Results.Ok(MessageEnums.GetEnumDescription((UpdateMessageEnum)updated));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("cancel")]
        public async Task<IResult> CancelBooking(string id)
        {
            var userId = this.User.Claims.Where(c => c.Type.Equals("UserID")).Select(c => c.Value).SingleOrDefault();
            var updated = await bookingApplication.CancelBooking(id, userId);
            return Results.Ok(MessageEnums.GetEnumDescription((CancelMessageEnum)updated));
        }

        [HttpGet("availability")]
        public async Task<IResult> GetAvailability([FromQuery] BookingDto booking)
        {
            var available = await bookingApplication.GetAvailability(booking);
            if(available)
                return Results.Ok($"The room is available for reservation between {booking.beginDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)} and {booking.endDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}!");

            return Results.Ok($"The room is not available for reservation between {booking.beginDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)} and {booking.endDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}!");
        }
    }
}
