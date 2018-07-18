using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShiftManager.Services {
	public class UserHistory {
		[BsonElement("name")]
		public string name { get; set; }

		[BsonElement("originalShift")]
		public Day originalShift { get; set; }

		[BsonElement("newShift")]
		public Day newShift { get; set; }
	}
}
