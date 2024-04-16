﻿namespace CleanArchitecture.Blazor.DataModels
{
    public class GameCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameGenre Genre { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}