using MongoDB.Bson;
using ShiftManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShiftManagerWebAPI.Controllers {
	public class UserController : ApiController {
		UserService service = new UserService();

		/** Test: GET de todos os modelos da collection */
		[Route("user/getall")]
		public IEnumerable<User> Get () {
			var get = service.Getusers();
			return get;
		}

		/* inserir um User */
		[Route("user/insert")]
		public void Post ([FromBody]User p) {
			service.insertUser(p);
		}

		/* Obter um user a partir do ID */
		[Route("user/id/{id}")]
		public User GetId (string id) {
			User user = service.getUserId(id);
			return user;
		}

		/* Obter um user a partir do Email */
		[Route("user/email/{email}")]
		public User GetEmail (string email) {
			User user = service.getUserEmail(email);
			return user;
		}

		/* Obter schedule ids a partir do Email */
		[Route("user/scheduleIDs/{email}")]
		public ObjectId[] GetScheduleIds (string email) {
			ObjectId[] ids = service.getScheduleIDs(email);
			return ids;
		}

		/* Obter um user a partir do Email */
		[Route("user/schedules/{email}")]
		public IEnumerable<Schedule> GetSchedules (string email) {
			List<Schedule> schedules = service.getSchedules(email);
			return schedules;
		}
	}
}