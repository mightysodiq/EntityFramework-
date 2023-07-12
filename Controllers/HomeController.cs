using Hotel.Models;
using Hotel.Repositories.Hotels_Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Hotel.Controllers
{
    public class HomeController : Controller
    {


        private readonly IHotelRepository _hotelRepository;
        public HomeController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }



        public IActionResult Index()
        {
            List<HotelModel> AllHotels = _hotelRepository.GetHotels();

            //filter for most picks
            var mostpicks = AllHotels.Where(prop => prop.Popularity == "Most Picks").ToList();
            ViewData["mostpicks"] = mostpicks;

            //filter for Houses with beautiful Backyards
            var backyards = AllHotels.Where(prop => prop.Description == "Houses with beautiful Backyards").ToList();
            ViewData["backyards"] = backyards;

            //filter for Hotels with large living rooms
            var livingRooms = AllHotels.Where(prop => prop.Description == "Hotels with large living rooms").ToList();
            ViewData["livingRooms"] = livingRooms;

            //filter for Apartments with Kitchen set
            var withKitchen = AllHotels.Where(prop => prop.Description == "Apartments with Kitchen set").ToList();
            ViewData["withKitchen"] = withKitchen;


            //HomeViewModel homeViewModel = new HomeViewModel(mostpicks, backyards, livingRooms, withKitchen);
            //return View(homeViewModel)

            string? LoggedInuserId = HttpContext.Session.GetString("loggedIn_UserId");

            ViewBag.SuccessMessage = TempData["Message"]?.ToString();
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}