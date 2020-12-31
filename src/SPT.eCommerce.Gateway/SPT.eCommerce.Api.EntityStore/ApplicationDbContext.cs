using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

using SPT.eCommerce.Api.Entity;

namespace SPT.eCommerce.Api.EntityStore
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext()
        {
            Initialize();
        }

        public static IList<Product> Products { get; set; }

        public static IList<ProductVariant> ProductVariants { get; set; }

        public static IList<Refinement> Refinements { get; set; }

        public static void Initialize()
        {           
            CreateProducts();
        }

        private static void CreateProducts()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    CurrencySymbol = ApplicationConstants.CurrencySymbol,
                    Name = "Men's Full Sleeves Cotton Stripe Shirt",
                    Description = "Men's Full Sleeves Cotton Stripe Shirt",
                    Sku = "MFSC001",
                    ProductVariants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Id = Guid.NewGuid(),
                            AvailableQuantity = 10,
                            Name = "Men's Full Sleeves Cotton Stripe Shirt - Blue - Small",
                            Price = 15.99m,
                            Refinements = new List<Refinement>
                            {
                                new Refinement
                                {
                                    Id = "color",
                                    Title = "Color",
                                    Value = new RefinementValue
                                    {
                                        Id = "blue",
                                        Title = "Blue"
                                    }
                                },
                                new Refinement
                                {
                                    Id = "size",
                                    Title = "Size",
                                    Value = new RefinementValue
                                    {
                                        Id = "small",
                                        Title = "Small"
                                    }
                                }
                            },
                            Sku = "MFSC001-BLSM",
                        },
                        new ProductVariant
                        {
                            Id = Guid.NewGuid(),
                            AvailableQuantity = 5,
                            Name = "Men's Full Sleeves Cotton Stripe Shirt - Green - Small",
                            Price = 15.99m,
                            Refinements = new List<Refinement>
                            {
                                new Refinement
                                {
                                    Id = "color",
                                    Title = "Color",
                                    Value = new RefinementValue
                                    {
                                        Id = "green",
                                        Title = "Green"
                                    }
                                },
                                new Refinement
                                {
                                    Id = "size",
                                    Title = "Size",
                                    Value = new RefinementValue
                                    {
                                        Id = "small",
                                        Title = "Small"
                                    }
                                }
                            },
                            Sku = "MFSC001-GRSM"
                        },
                        new ProductVariant
                        {
                            Id = Guid.NewGuid(),
                            AvailableQuantity = 7,
                            Name = "Men's Full Sleeves Cotton Stripe Shirt - Blue - Medium",
                            Price = 14.99m,
                            Refinements = new List<Refinement>
                            {
                                new Refinement
                                {
                                    Id = "color",
                                    Title = "Color",
                                    Value = new RefinementValue
                                    {
                                        Id = "blue",
                                        Title = "Blue"
                                    }
                                },
                                new Refinement
                                {
                                    Id = "size",
                                    Title = "Size",
                                    Value = new RefinementValue
                                    {
                                        Id = "medium",
                                        Title = "Medium"
                                    }
                                }
                            },
                            Sku = "MFSC001-BLMD"
                        },
                        new ProductVariant
                        {
                            Id = Guid.NewGuid(),
                            AvailableQuantity = 0,
                            Name = "Men's Full Sleeves Cotton Stripe Shirt - Green - Medium",
                            Price = 13.99m,
                            Refinements = new List<Refinement>
                            {
                                new Refinement
                                {
                                    Id = "color",
                                    Title = "Color",
                                    Value = new RefinementValue
                                    {
                                        Id = "green",
                                        Title = "Green"
                                    }
                                },
                                new Refinement
                                {
                                    Id = "size",
                                    Title = "Size",
                                    Value = new RefinementValue
                                    {
                                        Id = "medium",
                                        Title = "Medium"
                                    }
                                }
                            },
                            Sku = "MFSC001-GRMD"
                        }
                    }
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    CurrencySymbol = ApplicationConstants.CurrencySymbol,
                    Name = "Men's Half Sleeves Cotton Stripe Shirt",
                    Description = "Men's Half Sleeves Cotton Stripe Shirt",
                    Sku = "MHSC002",
                    ProductVariants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Id = Guid.NewGuid(),
                            AvailableQuantity = 9,
                            Name = "Men's Half Sleeves Cotton Stripe Shirt - Blue - Small",
                            Price = 13.99m,
                            Refinements = new List<Refinement>
                            {
                                new Refinement
                                {
                                    Id = "color",
                                    Title = "Color",
                                    Value = new RefinementValue
                                    {
                                        Id = "blue",
                                        Title = "Blue"
                                    }
                                },
                                new Refinement
                                {
                                    Id = "size",
                                    Title = "Size",
                                    Value = new RefinementValue
                                    {
                                        Id = "small",
                                        Title = "Small"
                                    }
                                }
                            },
                            Sku  = "MHSC002-BLSM"
                        },
                        new ProductVariant
                        {
                            Id = Guid.NewGuid(),
                            AvailableQuantity = 12,
                            Name = "Men's Half Sleeves Cotton Stripe Shirt - Red - Small",
                            Price = 13.99m,
                            Refinements = new List<Refinement>
                            {
                                new Refinement
                                {
                                    Id = "color",
                                    Title = "Color",
                                    Value = new RefinementValue
                                    {
                                        Id = "red",
                                        Title = "Red"
                                    }
                                },
                                new Refinement
                                {
                                    Id = "size",
                                    Title = "Size",
                                    Value = new RefinementValue
                                    {
                                        Id = "small",
                                        Title = "Small"
                                    }
                                }
                            },
                            Sku  = "MHSC002-RDSM"
                        },
                        new ProductVariant
                        {
                            Id = Guid.NewGuid(),
                            AvailableQuantity = 3,
                            Name = "Men's Half Sleeves Cotton Stripe Shirt - Blue - Medium",
                            Price = 14.99m,
                            Refinements = new List<Refinement>
                            {
                                new Refinement
                                {
                                    Id = "color",
                                    Title = "Color",
                                    Value = new RefinementValue
                                    {
                                        Id = "blue",
                                        Title = "Blue"
                                    }
                                },
                                new Refinement
                                {
                                    Id = "size",
                                    Title = "Size",
                                    Value = new RefinementValue
                                    {
                                        Id = "small",
                                        Title = "Small"
                                    }
                                }
                            },
                            Sku  = "MHSC002-BLMD"
                        },
                        new ProductVariant
                        {
                            Id = Guid.NewGuid(),
                            AvailableQuantity = 5,
                            Name = "Men's Half Sleeves Cotton Stripe Shirt - Red - Medium",
                            Price = 14.99m,
                            Refinements = new List<Refinement>
                            {
                                new Refinement
                                {
                                    Id = "color",
                                    Title = "Color",
                                    Value = new RefinementValue
                                    {
                                        Id = "red",
                                        Title = "Red"
                                    }
                                },
                                new Refinement
                                {
                                    Id = "size",
                                    Title = "Size",
                                    Value = new RefinementValue
                                    {
                                        Id = "medium",
                                        Title = "Medium"
                                    }
                                }
                            },
                            Sku  = "MHSC002-RDMD"
                        }
                    }
                }
            };
        }
    }
}
