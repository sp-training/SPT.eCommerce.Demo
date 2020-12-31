using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SPT.eCommerce.Api.Entity;

using Verve.Utility.Core.ContractResult;

namespace SPT.eCommerce.Api.Service
{
    public interface IProductService
    {
        Task<Result<Product>> GetProductByIdAsync(Guid productId);
        Task<Result<Product[]>> GetProductsAsync();
    }
}