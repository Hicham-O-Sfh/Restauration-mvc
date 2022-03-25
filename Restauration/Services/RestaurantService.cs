using Restauration.Models;

namespace Restauration.Services
{
    public class RestaurantService : IRestaurantService
    {
        private List<Restaurant> _restaurants;
        public RestaurantService()
        {
            this._restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1,Adresse ="Adresse Restaurant 1, Rue 1, Nr 1", Cuisine ="Cuisine 1 Spécialité 1", Nom="Restaurant 1", Note =17.1f},
                new Restaurant() { Id = 2,Adresse ="Adresse Restaurant 2, Rue 1, Nr 2", Cuisine ="Cuisine 2 Spécialité 2", Nom="Restaurant 2", Note =17.2f},
                new Restaurant() { Id = 3,Adresse ="Adresse Restaurant 3, Rue 1, Nr 3", Cuisine ="Cuisine 3 Spécialité 3", Nom="Restaurant 3", Note =17.3f},
                new Restaurant() { Id = 4,Adresse ="Adresse Restaurant 4, Rue 1, Nr 4", Cuisine ="Cuisine 4 Spécialité 4", Nom="Restaurant 4", Note =17.4f},
                new Restaurant() { Id = 5,Adresse ="Adresse Restaurant 5, Rue 1, Nr 5", Cuisine ="Cuisine 5 Spécialité 5", Nom="Restaurant 5", Note =17.5f},
                new Restaurant() { Id = 6,Adresse ="Adresse Restaurant 6, Rue 1, Nr 6", Cuisine ="Cuisine 6 Spécialité 6", Nom="Restaurant 6", Note =17.6f}
            };
        }
        public void AddRestaurant(IFormCollection collection)
        {
            this._restaurants.Add(new Restaurant
            {
                Id = this._restaurants.Last().Id + 1,
                Adresse = collection["Adresse"],
                Cuisine = collection["Cuisine"],
                Nom = collection["Nom"],
                Note = float.Parse(collection["Note"]),
            });
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            this._restaurants.Remove(restaurant);
        }

        public void EditRestaurant(int id, IFormCollection collection)
        {
            this._restaurants.Find(res => res.Id == id).Nom = collection["Nom"];
            this._restaurants.Find(res => res.Id == id).Adresse = collection["Adresse"];
            this._restaurants.Find(res => res.Id == id).Note = float.Parse(collection["Note"]);
            this._restaurants.Find(res => res.Id == id).Cuisine = collection["Cuisine"];
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return this._restaurants;
        }

        public Restaurant GetRestaurant(int id)
        {
            return this._restaurants.Find(res => res.Id == id);
        }
    }
}
