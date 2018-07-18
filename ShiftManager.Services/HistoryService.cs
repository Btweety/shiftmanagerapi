using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ShiftManager.Services {
	class HistoryService {
		MongoClient _client;
		IMongoDatabase _db;
		IMongoCollection<History> historyColl;

		/* Dados da ligação */
		string ip = "mongodb://192.168.4.78:27017";
		string database = "shiftworker";

		/* Iniciar ligação */
		public HistoryService () {
			_client = new MongoClient(ip);
			_db = _client.GetDatabase(database);
			historyColl = _db.GetCollection<History>("History");
		}

		/* inserir uma history */
		public void insertHistory(History history) {
			historyColl.InsertOne(history);
		}

		/* Obter um histório pelo ID */
		public History getHistory (ObjectId id) {
			var filter = new BsonDocument("_id", id);
			var res = historyColl.Find(filter);
			long num = res.CountDocuments();
			if ( num > 0 )
				return res.First();
			else
				return null;
		}

	}
}
