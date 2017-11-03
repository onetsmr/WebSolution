using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebSolution.Data;
using WebSolution.Models;
using WebSolution.Models.Mappers;
using WebSolution.Web.Controllers.API.Base;

namespace WebSolution.Web.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/roles")]
    public class RoleApiController : BaseApiController
    {
        [Route(""), HttpGet]
        public IEnumerable<RoleListViewModel> GetRoles()
        {
            return DataBase.Roles.Select(e => e.MapFrom());
        }

        [Route("{Id}"), HttpGet]
        public RoleAddEditModel GetRole(int id)
        {
            return DataBase.GetRole(id).MapTo();
        }

        [Route("{Id}"), HttpPost]
        public RoleAddEditModel SaveRole(RoleAddEditModel model)
        {
            var entity = DataBase.GetOrCreateRole(model.Id);

            entity.MapFrom(model);

            return GetRole(entity.Id);
        }

        [Route("{Id}"), HttpDelete]
        public RoleAddEditModel DeleteRole(int id)
        {
            DataBase.DeleteRole(id);

            return new RoleAddEditModel
            {
                Id = id
            };
        }
    }
}
