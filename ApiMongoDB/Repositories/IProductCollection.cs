using ApiMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoDB.Repositories
{
	public interface IProductCollection
	{
		Task InsertProcuct(Product product);
		Task UpdateProduct(Product product);
		Task DeleteProduct(string id);

		Task<List<Product>> GetAllProducts();
		Task<Product> GetProductById(string id);
	}
}
