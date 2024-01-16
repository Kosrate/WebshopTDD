﻿namespace WebshopTDD.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = "";
    }
}
