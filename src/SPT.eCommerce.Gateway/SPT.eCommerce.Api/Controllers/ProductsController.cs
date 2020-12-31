using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SPT.eCommerce.Api.Entity;
using SPT.eCommerce.Api.Service;

using Swashbuckle.AspNetCore.Annotations;

using Verve.Utility.Core.ContractResult.ApiResponse;

namespace SPT.eCommerce.Api.Controllers
{
    /// <summary>
    /// Products controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productService">IProductService Instance</param>
        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <example><code>$"{Request.Scheme}://{Request.Host}/api/products/"</code></example> 
        /// <response code="200"> Returns List of all Products </response>
        [HttpGet]
        [Route("")]
        [FormatFilter]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsAsync()
        {
            _logger.LogInformation("Fetching all products");
            return await ActionResultBuilder.ExecuteAndBuildResult(() => _productService.GetProductsAsync());
        }

        /// <summary>
        /// Get product by Id of type <see cref="Guid"/>
        /// </summary>
        /// <remarks>Product Id must be in correct Guid format otherwise it will throw an exception</remarks>
        /// <param name="productId" example="05e9886d-dacd-4d05-9dab-bfd554002a2c">A <see cref="Guid"/> represents the <paramref name="productId"/> of product to fetch details</param>
        /// <response code="200"> Returns <see cref="Product"/> with matching product id</response>
        /// <response code="204">When product does not exist</response>
        /// <response code="400">The parameter <paramref name="productId"/> value is not valid.</response>
        [HttpGet("{productId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        [SwaggerResponse(200, "Returns product with matching product Id", typeof(Product))]
        public async Task<IActionResult> GetProductByIdAsync(Guid productId)
        {
            _logger.LogInformation($"Fetching product details with id {productId}");

            return await ActionResultBuilder.ExecuteAndBuildResult(() => _productService.GetProductByIdAsync(productId));
        }
    }
}
