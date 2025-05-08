﻿using Fruitables.Models;

namespace Fruitables.ViewModels
{
    public class DetailVM
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<Product> FeatureProducts { get; set; }

    }
}
