using System;
using System.Collections.Generic;

namespace SPT.eCommerce.Api.Entity
{
    public class ProductVariant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public decimal AvailableQuantity { get; set; }
        public bool IsInStock => AvailableQuantity > 0;

        private List<Refinement> _refinements;

        public List<Refinement> Refinements
        {
            get => _refinements = _refinements ?? new List<Refinement>();
            set => _refinements = value;
        }
    }
}
