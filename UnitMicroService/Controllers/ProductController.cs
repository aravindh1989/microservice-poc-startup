using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using UnitMicroService.Models;
using UnitMicroService.Repository;

namespace UnitMicroService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		// GET: api/Product
		[HttpGet]
		public IActionResult Get()
		{
			IEnumerable<Product> products = _productRepository.GetProducts();
			return new OkObjectResult(products);
		}

		// GET: api/Product/5
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(int id)
		{
			Product product = _productRepository.GetProductById(id);
			return new OkObjectResult(product);
		}

		// POST: api/Product
		[HttpPost]
		public IActionResult Post([FromBody] Product pdt)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				_productRepository.InsertProduct(pdt);
				scope.Complete();
				return CreatedAtAction(nameof(Get), new { id = pdt.Id }, pdt);
			}
		}

		// PUT: api/Product/5
		[HttpPut("{id}")]
		public IActionResult Put([FromBody] Product pdt)
		{
			if (pdt != null)
			{
				using (TransactionScope scope = new TransactionScope())
				{
					_productRepository.UpdateProduct(pdt);
					scope.Complete();
					return new OkResult();
				}
			}
			return new NoContentResult();
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_productRepository.DeleteProduct(id);
			return new OkResult();
		}
	}
}
