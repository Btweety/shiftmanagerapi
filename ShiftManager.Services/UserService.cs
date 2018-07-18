using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;


namespace ShiftManager.Services {
	public class UserService {
		MongoClient _client;
		IMongoDatabase _db;
		IMongoCollection<User> userColl;
		IMongoCollection<Schedule> scheduleColl;

		/* Dados da ligação */
		string ip = "mongodb://192.168.4.78:27017";
		string database = "shiftworker";

		/* Iniciar ligação */
		public UserService () {
			_client = new MongoClient(ip);
			_db = _client.GetDatabase(database);
			userColl = _db.GetCollection<User>("Users");
			scheduleColl = _db.GetCollection<Schedule>("Schedules");
		}

		public IEnumerable<User> Getusers () {
			return userColl.Find(_ => true).ToList();
		}

		/* Inserir um utilizador */
		public void insertUser(User user) {
			userColl.InsertOne(user);
		}

		/* Obter um user a partir do ID */
		public User getUserId (string idString) {
			ObjectId id = new ObjectId(idString);
			var filter = new BsonDocument("_id", id);
			var res = userColl.Find(filter);
			long num = res.CountDocuments();
			if ( num > 0 )
				return res.First();
			else
				return null;
		}

		/* Obter um user a partir do Email */
		public User getUserEmail (String email) {
			var filter = new BsonDocument("email", email);
			var res = userColl.Find(filter);
			if ( res.CountDocuments() > 0 )
				return res.First();
			else
				return null;
		}

		/* Obter o ObjectID de todos os schedules de um user */
		public ObjectId[] getScheduleIDs (String email) {
			User user = getUserEmail(email);
			return user.schedules;
		}

		/** Obter todos os schedules de um user */
		public List<Schedule> getSchedules (String email) {
			/** obter o array de object ID de schedules e procurar na collection de schedules por todos os schedules que possuem o objectID */
			ObjectId[] schedulesId = getScheduleIDs(email);
			List<Schedule> schedules = new List<Schedule>();
			foreach ( var schedId in schedulesId ) {
				var schFilter = new BsonDocument("_id", schedId);
				var schFilRes = scheduleColl.Find(schFilter);
				if ( schFilRes != null )
					schedules.Add(schFilRes.First());
			}
			return schedules;
		}
	}
}
