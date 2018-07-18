using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShiftManager.Services {
	public class Day {
		[BsonElement("day")]
		public string day { get; set; }

		[BsonElement("weekDay")]
		public string weekDay { get; set; }

		[BsonElement("shift")]
		public string shift { get; set; }

		[BsonElement("weekDayId")]
		public string weekDayId { get; set; }

		[BsonElement("shiftId")]
		public string shiftId { get; set; }

		[BsonElement("hours")]
		public string hours { get; set; }

		[BsonElement("startDate")]
		public DateTime startDate { get; set; }

		[BsonElement("endDate")]
		public DateTime endDate { get; set; }
	}
}
