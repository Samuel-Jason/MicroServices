using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    Route[(["api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _Repository;
        public ProductController(IProductRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll(long id)
        {
            var product = await _Repository.FindAll();
            if (product != null) return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(long id)
        {
            var product = await _Repository.FindById(id);
            if (product != null) return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Update(ProductVO vo)
        {
            if (vo != null)
            {
                var res = await _Repository.Update(vo);
            }

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVO>> Delete(long id)
        {
            var res = await _Repository.Delete(id);
            return Ok();
        }
    }
}
