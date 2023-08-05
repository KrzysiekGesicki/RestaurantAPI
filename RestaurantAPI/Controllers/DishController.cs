using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/restaurant/{restaurantId}/dish")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDto dto)
        {
            int dishId = _dishService.Create(restaurantId, dto);
            return Created($"api/restaurant/{restaurantId}/dish/{dishId}", null);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = _dishService.GetById(restaurantId, dishId);
            return Ok(dish);
        }

        [HttpGet]
        public ActionResult<List<DishDto>> GetAll([FromRoute] int restaurantId)
        {
            var result = _dishService.GetAll(restaurantId);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int restaurantId)
        {
            _dishService.DeleteAll(restaurantId);
            return NoContent();
        }

        [HttpDelete("{dishId}")]
        public ActionResult DeleteById([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            _dishService.DeleteById(restaurantId, dishId);
            return NoContent();
        }
    }
}
