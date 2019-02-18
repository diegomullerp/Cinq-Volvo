namespace MyServices.Web.Controllers
{
    using System;
    using System.Web.Http;
    using DTOs;

    [RoutePrefix("api/product")]
    [ControllerExceptionFilter]
    public class ProductController : ApiController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Add([FromBody] ProductDTO productDTO)
        {
            var product = productDTO.ToProduct();
            _productService.Add(product);
            return Created(string.Format("{0}/{1}", Request.RequestUri, product.Id), product);
        }

        [HttpPut]
        [ValidateModel]
        public IHttpActionResult Update([FromBody] UpdatedProductDTO productDTO)
        {
            var product = productDTO.ToProduct();
            _productService.Update(product);
            return Ok(_productService.Get(product.Id));
        }

        [Route("{id}")]
        public void Delete(Guid id)
        {
            _productService.Remove(id);
        }
    }
}