using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitMicroService.DBContext;
using UnitMicroService.Models;

namespace UnitMicroService.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly UnitContext _dbContext;

		public ProductRepository(UnitContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteProduct(int id)
		{
			Product product = _dbContext.Products.Find(id);
			_dbContext.Products.Remove(product);
			throw new NotImplementedException();
		}

		public Product GetProductById(int id)
		{
			return _dbContext.Products.Find(id);
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetProducts()
		{
			return _dbContext.Products.ToList();
			throw new NotImplementedException();
		}

		public void InsertProduct(Product pdt)
		{
			_dbContext.Add(pdt);
			save();
			throw new NotImplementedException();
		}

		public void save()
		{
			_dbContext.SaveChanges();
			throw new NotImplementedException();
		}

		public void UpdateProduct(Product pdt)
		{
			_dbContext.Entry(pdt).State = EntityState.Modified;
			save();
			throw new NotImplementedException();
		}
	}
}
