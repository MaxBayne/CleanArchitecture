﻿using CleanArchitecture.Application.ObjectMapping.AutoMapper.Abstract;


namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game
{
    public class CreateGameDto: BaseDto
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
