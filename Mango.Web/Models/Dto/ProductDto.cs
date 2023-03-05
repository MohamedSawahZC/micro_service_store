﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.Dto
{
    public class ProductDto
    {
        public int productId { get; set; }
        public string Name { get; set; } 
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
