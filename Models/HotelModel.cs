namespace Hotel.Models
{
    public partial class HotelModel
    {
        public int HotelId { get; set; }

        public string HotelImageUrl { get; set; } = null!;

        public string HotelName { get; set; } = null!;

        public string HotelLocation { get; set; } = null!;

        public decimal? HotelPrice { get; set; }

        public string HotelDescription { get; set; } = null!;

        public string? HotelPopularity { get; set; }

        public string? HotelImageUrl2 { get; set; }

        public string? HotelImageUrl3 { get; set; }

        public string? HotelAboutDplace { get; set; }

        public int? BedRoom { get; set; }

        public int? LivingRoom { get; set; }

        public int? BathRoom { get; set; }

        public int? DinningRoom { get; set; }

        public int? Mbps { get; set; }

        public int? UnitsReady { get; set; }

        public int? Refrigerator { get; set; }

        public int? Television { get; set; }
    }   
}
