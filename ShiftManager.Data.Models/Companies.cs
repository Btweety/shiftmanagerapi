using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShiftManager.Services {
	public class Companies {
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement("name")]
		public string name { get; set; }

		[BsonElement("email")]
		public string email { get; set; }

		[BsonElement("address")]
		public string address { get; set; }

		[BsonElement("phone")]
		public string phone { get; set; }

	}
}
