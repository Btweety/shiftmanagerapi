using MongoDB.Bson;
using ShiftManager.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ShiftManagerWebAPI.Controllers {
	public class ValuesController : ApiController {
		ModelAService service = new ModelAService();

		/** GET de todos os modelos da collection */
		[Route("api/getAll")]
		public IEnumerable<Model> Get () {
			var get = service.GetModels();
			return get;
		}

		/** obter um documento segundo o ID */
		[Route("api/getOne/{id}")]
		public Model Get (string id) {
			var model = service.GetModel(new ObjectId(id));
			return model;
		}

		/** obter uma lista segundo o tipo */
		[Route("api/getFromType/{type}")]
		public IEnumerable<Model> GetListOnType (string type) {
			var models = service.GetListFromType(type);
			return models;
		}

		/** inserir um documento */
		[Route("api/insert")]
		public void Post ([FromBody]Model p) {
			service.Create(p);
		}

		/** update/substituir documento */
		[Route("api/update/{id:length(24)}")]
		public void Put (string id, [FromBody]Model p) {
			var recId = new ObjectId(id);
			var model = service.GetModel(recId);
			service.Update(recId, p);
		}

		/** remover documento */
		[Route("api/remove/{id:length(24)}")]
		public void Delete (string id) {
			var model = service.GetModel(new ObjectId(id));
			service.Remove(model.Id);
		}
	}
}
