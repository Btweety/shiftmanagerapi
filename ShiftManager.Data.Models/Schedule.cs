using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShiftManager.Services {
	public class Schedule {
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement("name")]
		public string name { get; set; }

		[BsonElement("company")]
		public string company { get; set; }

		[BsonElement("month")]
		public string month { get; set; }

		[BsonElement("days")]
		public Day[] days { get; set; }
	}
}
