using Hotel.Models;
using Hotel.Repositories.Hotels_Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public DetailsController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }






        public IActionResult PropDetails(int id)
        {
            HotelModel hotel = _hotelRepository.GetHotelById(id);
            ViewData["hotel"] = hotel;


            // Shuffle the hotels list using a random seed
            Random random = new Random();
            List<HotelModel> shuffledHotels = _hotelRepository.GetHotels().OrderBy(x => random.Next()).ToList();

            // Select the first 4 hotels from the shuffled list
            List<HotelModel> randomHotels = shuffledHotels.Take(4).ToList();
            ViewData["randomHotels"] = randomHotels;

            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
