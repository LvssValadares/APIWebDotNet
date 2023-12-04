using API_WEB_CRUD.Data;
using API_WEB_CRUD.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;

namespace API_WEB_CRUD.Controllers
{   // "Fat Controller". This is not the best way to program.
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly DataContext _context;
        public RestaurantController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if(restaurant == null)
            {
                return NotFound("Restaurant not found.");
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return Ok(await _context.Restaurants.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Restaurant>> UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var dbRestaurant = await _context.Restaurants.FindAsync(updatedRestaurant.Id);
            if (dbRestaurant is null)
            {
                return NotFound("Restaurant not found.");
            }
            dbRestaurant.Name = updatedRestaurant.Name;
            dbRestaurant.Specialty = updatedRestaurant.Specialty;
            dbRestaurant.Address = updatedRestaurant.Address;
            dbRestaurant.City = updatedRestaurant.City;
            dbRestaurant.State = updatedRestaurant.State;
            await _context.SaveChangesAsync();
            return Ok(await _context.Restaurants.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<Restaurant>>DeleteRestaurant(int id)
        {
            var dbRestaurant = await _context.Restaurants.FindAsync(id);
            if (dbRestaurant is null)
            {
                return NotFound("Restaurant not found.");
            }
            _context.Restaurants.Remove(dbRestaurant);
            await _context.SaveChangesAsync();
            return Ok(await _context.Restaurants.ToListAsync());
        }
    }
}
