﻿using ApiMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoDB.Repositories
{
	public class ProductCollection : IProductCollection
	{
		internal MongoDBRepository _repository = new MongoDBRepository();
		private IMongoCollection<Product> Collection;

		public ProductCollection()
		{
			Collection = _repository.db.GetCollection<Product>("Products");
		}

		public async Task DeleteProduct(string id)
		{
			var filter = Builders<Product>.Filter.Eq(p => p.Id, new ObjectId(id));
			await Collection.DeleteOneAsync(filter);
		}

		public async Task<List<Product>> GetAllProducts()
		{
			return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
		}

		public async Task<Product> GetProductById(string id)
		{
			return await Collection.FindAsync(
				new BsonDocument { { "_id", new ObjectId(id) }  }).Result.FirstAsync();
		}

		public async Task InsertProcuct(Product product)
		{
			await Collection.InsertOneAsync(product);
		}

		public async Task UpdateProduct(Product product)
		{
			var filter = Builders<Product>
				.Filter
				.Eq(p => p.Id, product.Id);
			await Collection.ReplaceOneAsync(filter, product);
		}
	}
}
