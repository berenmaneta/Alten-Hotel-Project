using AltenAPI.Models;

namespace AltenAPI.Application.Interfaces
{
    public interface IHotelApplication
    {
        Task<int> CreateHotel(HotelDto hotel);
        Task<IEnumerable<HotelDto>> ListHotels();
        Task<HotelDto> GetHotel(int id);
        Task<HotelDto> UpdateHotel(HotelDto booking);
        bool DeleteHotel(int id);
    }
}
