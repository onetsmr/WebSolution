using WebSolution.Data;
using WebSolution.Models.Base;

namespace WebSolution.Models
{
    public class RoleListViewModel : BaseListViewModel
    {
        public string Name { get; set; }

        public static RoleListViewModel MapFrom(Role entity)
        {
            return new RoleListViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
