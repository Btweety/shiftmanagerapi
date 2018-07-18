using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShiftManager.Services {
	public class History {
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement("user1")]
		public UserHistory user1 { get; set; }

		[BsonElement("user2")]
		public UserHistory user2 { get; set; }

		[BsonElement("Date")]
		public DateTime Date { get; set; }
	}
}
