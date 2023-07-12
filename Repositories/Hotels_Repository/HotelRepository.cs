using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Repositories.Hotels_Repository
{
    public class HotelRepository : IHotelRepository
	{



		private readonly string connectionString;



		public HotelRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}


		public HotelModel GetHotelById(int id)
		{
			var hotels = GetHotels();
            var hotel = hotels.FirstOrDefault(hotel => hotel.Id == id);
			return hotel;
		}





		public List<HotelModel> GetHotels()
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = "SELECT * FROM hotels";

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					connection.Open();

					using (SqlDataReader reader = command.ExecuteReader())
					{
						List<HotelModel> hotels = new List<HotelModel>();

						while (reader.Read())
						{
							int hotelID = reader.GetInt32(reader.GetOrdinal("hotelID"));
							string hotelImageUrl = reader.GetString(reader.GetOrdinal("hotelImageURL"));
							string hotelName = reader.GetString(reader.GetOrdinal("hotelName"));
							string hotelLocation = reader.GetString(reader.GetOrdinal("hotelLocation"));
							decimal hotelPrice = reader.GetDecimal(reader.GetOrdinal("hotelPrice"));
							string hotelDescription = reader.GetString(reader.GetOrdinal("hotelDescription"));
							string hotelPopularity = reader.GetString(reader.GetOrdinal("hotelPopularity"));
                            string hotelImageUrl2 = reader.GetString(reader.GetOrdinal("hotelImageUrl2"));
                            string hotelImageUrl3 = reader.GetString(reader.GetOrdinal("hotelImageUrl3"));
                            string hotelAboutDPlace = reader.GetString(reader.GetOrdinal("hotelAboutDPlace"));
                            int bedRoom = reader.GetInt32(reader.GetOrdinal("bedRoom"));
                            int livingRoom = reader.GetInt32(reader.GetOrdinal("livingRoom"));
                            int bathRoom  = reader.GetInt32(reader.GetOrdinal("bathRoom"));
                            int diningRoom = reader.GetInt32(reader.GetOrdinal("dinningRoom"));
                            int mbps = reader.GetInt32(reader.GetOrdinal("mbps"));
                            int unitsReady = reader.GetInt32(reader.GetOrdinal("unitsReady"));
                            int refrigerator = reader.GetInt32(reader.GetOrdinal("refrigerator"));
                            int television = reader.GetInt32(reader.GetOrdinal("television"));

                            var hotel = new HotelModel(hotelID, hotelImageUrl, hotelName, hotelLocation, hotelPrice, 
								hotelDescription, hotelPopularity, hotelImageUrl2, hotelImageUrl3, hotelAboutDPlace, bedRoom, 
								livingRoom, bathRoom, diningRoom, mbps, unitsReady, refrigerator,television);

							hotels.Add(hotel);
						}

						return hotels;
					}
				}
			}
		}






	}
}
