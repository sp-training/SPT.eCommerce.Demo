using System;
using System.Collections.Generic;
using System.Linq;

namespace SPT.eCommerce.Api.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal Price => ProductVariants?.Where(s => s.IsInStock).OrderBy(p => p.Price).FirstOrDefault() == null
                                    ? 0m 
                                    : ProductVariants.Where(s => s.IsInStock).OrderBy(p => p.Price).FirstOrDefault().Price;

        public bool IsInStock => ProductVariants.Any(x => x.IsInStock);
        public string CurrencySymbol { get; set; }

        private List<ProductVariant> _productVariant;

        public List<ProductVariant> ProductVariants
        {
            get => _productVariant ??= new List<ProductVariant>();
            set => _productVariant = value;
        }
        public decimal ShippingCost { get; set; }
        public decimal TaxPercent { get; set; }
    }
}
