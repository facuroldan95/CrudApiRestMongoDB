using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoDB.Models
{
	public class Product
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public string name { get; set; }
		public int stock { get; set; }
		public DateTime expiryDate { get; set; }
		public string categoriy { get; set; }
	}
}
