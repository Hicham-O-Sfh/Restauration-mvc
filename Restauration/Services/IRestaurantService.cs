using Restauration.Models;

namespace Restauration.Services
{
    public interface IRestaurantService
    {
        public List<Restaurant> GetAllRestaurants();
        public Restaurant GetRestaurant(int id);

        public void AddRestaurant(IFormCollection collection);

        public void EditRestaurant(int id, IFormCollection collection);

        public void DeleteRestaurant(Restaurant restaurant);
    }
}
