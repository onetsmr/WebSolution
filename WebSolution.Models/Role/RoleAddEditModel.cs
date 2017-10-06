using WebSolution.Data;

namespace WebSolution.Models
{
    public class RoleAddEditModel
    {
        public int Id { get; set; }

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
