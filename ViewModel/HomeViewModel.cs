using Hotel.Models;

namespace Hotel.ViewModel
{
	public class HomeViewModel
	{
		

		public List<Property> mostpicks { get; set; }
        public List<Property> backyards { get; set; }

        public List<Property> livingRooms { get; set; }
        public List<Property> withKitchen { get; set; }

		public HomeViewModel(List<Property> mostpicks, List<Property> backyards, List<Property> livingRooms, List<Property> withKitchen)
		{
			this.mostpicks = mostpicks;
			this.backyards = backyards;
			this.livingRooms = livingRooms;
			this.withKitchen = withKitchen;
		}

	}
}
