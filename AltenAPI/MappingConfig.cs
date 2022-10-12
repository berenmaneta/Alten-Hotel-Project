using AltenAPI.Entities;
using AltenAPI.Models;
using AutoMapper;

namespace AltenAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, User>().ReverseMap();
                config.CreateMap<BookingDto, Booking>().ReverseMap();
                config.CreateMap<RoomDto, Room>().ReverseMap();
                config.CreateMap<HotelDto, Hotel>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
