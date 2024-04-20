﻿using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Blazor.DataModels.Abstract;

namespace CleanArchitecture.Blazor.DataModels
{
    public class GameModel:BaseDataModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public GenreModel Genre { get; set; } = new();

        [Range(1,0)]
        public decimal Price { get; set; }

        [Range(1,0)]
        public int Year { get; set; }
    }
}
