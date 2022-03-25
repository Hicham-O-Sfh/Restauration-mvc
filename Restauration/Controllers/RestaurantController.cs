using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restauration.Models;
using Restauration.Services;

namespace Restauration.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _restaurantService;
        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController
           (
           ILogger<RestaurantController> logger,
           IRestaurantService restaurantService
           )
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        [HttpGet("/Restaurants")]
        public ActionResult Index()
        {
            List<Restaurant> restaurants = this._restaurantService.GetAllRestaurants();
            return View(restaurants);
        }

        [HttpGet("/Restaurants/Details/{id}")]
        public ActionResult Details(int id)
        {
            return View(this._restaurantService.GetRestaurant(id));
        }

        [HttpGet("/Restaurants/Création")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("/Restaurants/Création")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                this._restaurantService.AddRestaurant(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("/Restaurants/Modifier/{id}")]
        public ActionResult Edit(int id)
        {
            return View(this._restaurantService.GetRestaurant(id));
        }

        [HttpPost("/Restaurants/Modifier/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                this._restaurantService.EditRestaurant(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("/Restaurants/Supprimer/{id}")]
        public ActionResult Delete(int id)
        {
            return View(
                this._restaurantService.GetRestaurant(id)
            );
        }

        [HttpPost("/Restaurants/Supprimer/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                this._restaurantService.DeleteRestaurant(this._restaurantService.GetRestaurant(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
