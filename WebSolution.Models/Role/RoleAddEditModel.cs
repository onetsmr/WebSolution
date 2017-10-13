using WebSolution.Data;
using WebSolution.Models.Base;

namespace WebSolution.Models
{
    public class RoleAddEditModel : BaseAddEditModel
    {
        public string Name { get; set; }

        public static RoleAddEditModel MapFrom(Role entity)
        {
            return new RoleAddEditModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
