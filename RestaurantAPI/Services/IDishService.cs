﻿using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
        public DishDto GetById(int restaurantId, int dishId);
        public List<DishDto> GetAll(int restaurantId);
    }
}