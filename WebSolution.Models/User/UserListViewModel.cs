using WebSolution.Data;

namespace WebSolution.Models
{
    public class UserListViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public bool EnableLogOutAction { get; set; }

        public static UserListViewModel MapFrom(User entity)
        {
            return new UserListViewModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Role = entity.Role.Name
            };
        }
    }
}
