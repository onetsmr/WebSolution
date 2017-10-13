using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebSolution.Data;
using WebSolution.Models;
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
            return DataBase.Roles.Select(e => RoleListViewModel.MapFrom(e));
        }

        [Route("{Id}"), HttpGet]
        public RoleAddEditModel GetRole(int id)
        {
            return DataBase.Roles
                .Select(e => RoleAddEditModel.MapFrom(e))
                .SingleOrDefault(e => e.Id == id);
        }

        [Route("{Id}"), HttpPost]
        public RoleAddEditModel SaveRole(RoleAddEditModel model)
        {
            var entity = DataBase.Roles.SingleOrDefault(e => e.Id == model.Id);

            if (entity == null)
            {
                entity = new Role
                {
                    Id = DataBase.Roles.Max(e => e.Id) + 1,
                    Name = model.Name,
                    RoleType = RoleTypeOption.Standard
                };

                DataBase.Roles.Add(entity);
            }
            else
            {
                entity.Name = model.Name;
            }

            return GetRole(model.Id);
        }
    }
}
