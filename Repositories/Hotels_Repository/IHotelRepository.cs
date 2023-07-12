using Hotel.Models;

namespace Hotel.Repositories.Hotels_Repository
{
    public interface IHotelRepository
	{
		List<HotelModel> GetHotels();
        HotelModel GetHotelById(int id);


    }
}
