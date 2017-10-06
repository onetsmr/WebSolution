using WebSolution.Data;

namespace WebSolution.Models
{
    public class RoleListViewModel
    {
        public int Id { get; set; }

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
