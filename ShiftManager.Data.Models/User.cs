using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManager.Services {
	public class User {
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement("name")]
		public string name { get; set; }

		[BsonElement("email")]
		public string email { get; set; }

		[BsonElement("phone")]
		public string phone { get; set; }

		[BsonElement("age")]
		public int age { get; set; }

		[BsonElement("gender")]
		public string gender { get; set; }

		[BsonElement("companies")]
		public string[] companies { get; set; }

		[BsonElement("schedules")]
		public ObjectId[] schedules { get; set; }
	}
}
