using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuperProductsCatalog.Model;
using SuperProductsCatalog.Model.Data;

namespace SuperProductsCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDBContext db;
        public ProductsController(ProductsDBContext db)
        {
            this.db = db;
        }

        // endpoint
        // type - GET/POST/PUT/DELETE
        // design url

        // EX: expose an endpoint for getting all products
        // M
        // C

        // GET .../api/products
        [HttpGet]
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        // get product by id
        // URL: GET........./api/products/123

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = db.Products.Find(id);
            if(product == null)
            {
                return NotFound($"Product {id} not found");  // 404
            }

            return Ok(product); // 200 + data
        }


        // create, design, implement and test below endpoints

        //1. get product by name
        //2. get all products by category
        //3. get all products by availability
        //4. get all products by brand
        //5. get all products by country
        //6. get all products by price range (300 -600)
        //7. get costliest product
        //8. get cheapest product
        //9. get all products based on desc (partial match) "a"
        //10. get total products by country
        //11. get total cost of all products based on brand
        //12. get the costliest products based on the category


        //1. get product by name
        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetProductByName(string name)
        {
            var product = from item in db.Products
                           where item.Name == name
                           select item;
            if (product.IsNullOrEmpty())
            {
                return NotFound($"Product having name {name} not found"); 
            }
            return Ok(product); 
        }

        //2. get all products by category
        [HttpGet]
        [Route("category/{name}")]
        public IActionResult GetProductByCategory(string name)
        {
            var product = from item in db.Products
                           where item.Category == name
                           select item;
            if (product.IsNullOrEmpty())
            {
                return NotFound($"Product with category {name} not found");
            }
            return Ok(product);
        }

        //3. get all products by availability
        [HttpGet]
        [Route("isavailability/{type}")]
        public IActionResult GetProductByAvailability(bool type)
        {
            var product = from item in db.Products
                          where item.IsAvailable == type
                          select item;
            if (product.IsNullOrEmpty())
            {
                return NotFound($"Product with availability {type} not found");
            }
            return Ok(product);
        }

        //4. get all products by brand
        [HttpGet]
        [Route("brand/{name}")]
        public IActionResult GetProductByBrand(string name)
        {
            var product = from item in db.Products
                          where item.Brand == name
                          select item;
            if (product.IsNullOrEmpty())
            {
                return NotFound($"Product with brand {name} not found");
            }
            return Ok(product);
        }

        //5. get all products by country
        [HttpGet]
        [Route("country/{name}")]
        public IActionResult GetProductByCountry(string name)
        {
            var product = from item in db.Products
                          where item.Country == name
                          select item;
            if (product.IsNullOrEmpty())
            {
                return NotFound($"Product with country {name} not found");
            }
            return Ok(product);
        }

        //6. get all products by price range (300 -600)
        // GET ...api/products/min/300/max/600
        [HttpGet]
        [Route("min/{min:int}/max/{max:int}")]
        public IActionResult GetProductByPrice(int min, int max)
        {
            var product = from item in db.Products
                          where item.Price >= min && item.Price <= max
                          select item;
            if (product.IsNullOrEmpty())
            {
                return NotFound("No Product lies between range 300 and 600");
            }
            return Ok(product);
        }

        //7. get costliest product
        [HttpGet]
        [Route("costliestProduct")]
        public IActionResult GetCostliestProduct()
        {
            var product = (from item in db.Products
                          orderby item.Price descending
                          select item).First();
            if (product == null)
            {
                return NotFound("No Product found");
            }
            return Ok(product);
        }

        //8. get cheapest product
        [HttpGet]
        [Route("cheapestProduct")]
        public IActionResult GetCheapestProduct()
        {
            var product = (from item in db.Products
                           orderby item.Price
                           select item).First();
            if (product == null)
            {
                return NotFound("No Product found");
            }
            return Ok(product);
        }

        //9. get all products based on desc (partial match) "a"

        // 10. get total products by country
        [HttpGet]
        [Route("totalProductByCountry/{name}")]
        public IActionResult GetTotalProductsByCountry(string name)
        {
            var totalProduct = (from item in db.Products
                           where item.Country==name
                           select item).Count();
            return Ok($"{totalProduct} products found with country name {name}");
        }

        //11. get total cost of all products based on brand
        [HttpGet]
        [Route("totalCostProductByBrand/{name}")]
        public IActionResult GetTotalCostProductsByBrand(string name)
        {
            var totalCostProduct = (from item in db.Products
                                where item.brand == name
                                select item).Sum(x=>x.Price);
            return Ok($"{totalCostProduct} amount found with brand name {name}");
        }
    }
}
