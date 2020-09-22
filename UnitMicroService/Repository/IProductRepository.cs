using System.Collections.Generic;
using UnitMicroService.Models;

namespace UnitMicroService.Repository
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		Product GetProductById(int id);
		void InsertProduct(Product pdt);
		void DeleteProduct(int id);
		void UpdateProduct(Product pdt);
		void save();
	}
}
