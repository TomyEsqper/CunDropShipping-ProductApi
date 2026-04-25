using Catalog.adapter.restful.v1.controller.Entity;
using Catalog.adapter.restful.v1.controller.Mapper;
using Catalog.application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CunDropShipping.adapter.restful.v1.controller
{
    [ApiController]
    [Route("api/v1/products")] 
    public class ProductController : ControllerBase
    {   
        private readonly IProductService _productService;
        private readonly IProductAdapterMapper _productAdapterMapper;
        
        public ProductController(IProductService productService, IProductAdapterMapper productAdapterMapper)
        {
            _productService = productService;
            _productAdapterMapper = productAdapterMapper;
        }
        
        [HttpGet]
        public ActionResult<List<AdapterProductEntity>> GetAllProducts()
        {
            return Ok(_productAdapterMapper.ToAdapterProductList(_productService.GetAllProducts()));
        }

        [HttpGet("{id}")]
        public ActionResult<AdapterProductEntity> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_productAdapterMapper.ToAdapterProduct(product));
        }

        [HttpPost]
        public ActionResult<AdapterProductEntity> CreateProduct([FromBody] AdapterProductEntity product)
        {
            var domainProduct = _productAdapterMapper.ToDomainProduct(product);
            var createdProduct = _productService.SaveProduct(domainProduct);
            var adapterResult = _productAdapterMapper.ToAdapterProduct(createdProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = adapterResult.IdProduct }, adapterResult);
        }

        [HttpPut("{id}")]
        public ActionResult<AdapterProductEntity> UpdateProduct(int id, [FromBody] AdapterProductEntity product)
        {
            var domainProduct = _productAdapterMapper.ToDomainProduct(product);
            var updatedProduct = _productService.UpdateProduct(id, domainProduct);
            
            if (updatedProduct == null)
            {
                return NotFound();
            }
            
            var adapterResult = _productAdapterMapper.ToAdapterProduct(updatedProduct);
            return Ok(adapterResult);
        }

        /// <summary>
        /// Elimina un producto identificado por su id.
        /// </summary>
        // ¡SOLUCIÓN 2: Método DELETE limpio y corregido!
        [HttpDelete("{id}")]
        public ActionResult<AdapterProductEntity> DeleteProduct(int id)
        {
            // 1. Llama al servicio para borrar el producto
            var deletedProduct = _productService.DeleteProduct(id);
            
            // 2. Si devuelve null, es porque no lo encontró
            if (deletedProduct == null)
            {
                return NotFound(); // Devuelve 404 si no existe
            }
            
            // 3. (Como tu Gateway espera) Traduce el producto borrado y lo devuelve
            var adapterResult = _productAdapterMapper.ToAdapterProduct(deletedProduct);
            return Ok(adapterResult);
        }
        
        // --- ENDPOINTS FILTRADO AVANZADO ---
        
        [HttpGet("search")]
        public ActionResult<List<AdapterProductEntity>> SearchByName([FromQuery] string searchTerm)
        {
            var domainProducts = _productService.SearchProductsByName(searchTerm);
            var adapterProducts = _productAdapterMapper.ToAdapterProductList(domainProducts);
            return Ok(adapterProducts); 
        }

        [HttpGet("filter/price")]
        public ActionResult<List<AdapterProductEntity>> FilterProductByPriceRange([FromQuery] decimal minPrice,
            [FromQuery] decimal maxPrice)
        {
            var domainProducts = _productService.FilterProductsByPriceRange(minPrice, maxPrice);
            var adapterProducts = _productAdapterMapper.ToAdapterProductList(domainProducts);
            return Ok(adapterProducts);
        }
        
        [HttpGet("filter/stock")]
        public ActionResult<List<AdapterProductEntity>> GetProductsWithLowStock([FromQuery] int stockThreshold)
        {
            var domainProducts = _productService.GetProductsWithLowStock(stockThreshold);
            var adapterProducts = _productAdapterMapper.ToAdapterProductList(domainProducts);
            return Ok(adapterProducts);
        }
    }
}