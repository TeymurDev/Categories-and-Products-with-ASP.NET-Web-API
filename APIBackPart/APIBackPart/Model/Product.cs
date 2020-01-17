﻿using System.ComponentModel.DataAnnotations;

namespace APIBackPart.Model
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
