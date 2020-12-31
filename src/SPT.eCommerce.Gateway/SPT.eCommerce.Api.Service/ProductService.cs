using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using SPT.eCommerce.Api.Entity;
using SPT.eCommerce.Api.EntityStore;

using Verve.Utility.Core.ContractResult;

namespace SPT.eCommerce.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public Task<Result<Product[]>> GetProductsAsync()

           => Task.FromResult(Result<Product[]>.Success(ApplicationDbContext.Products.ToArray()));

        public async Task<Result<Product>> GetProductByIdAsync(Guid productId)
        {
            var products = await Task.FromResult(ApplicationDbContext.Products);

            var product = products.FirstOrDefault(x => x.Id == productId);

            if (product == null)
            {
                _logger.LogWarning($"No product exist with product id {productId}");
                return Result<Product>.NoContent();
            }

            _logger.LogInformation($"Fetched product details with product id {productId}");
            return Result<Product>.Success(product);
        }
    }
}
