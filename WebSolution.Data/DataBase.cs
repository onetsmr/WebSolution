using System.Collections.Generic;
using System.Linq;

namespace WebSolution.Data
{
    public static class DataBase
    {
        static DataBase()
        {
            Roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    RoleType = RoleTypeOption.Admin,
                    Users = new List<User>()
                },
                new Role
                {
                    Id = 2,
                    Name = "User",
                    RoleType = RoleTypeOption.Standard,
                    Users = new List<User>()
                }
            };

            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "mr@mailinator.com",
                    UserName = "mr",
                    Password = "ALQ+I339UTak8heePhx9qihts6sq2lM53/A/alMMitOVZvSEhMN8vIgIeB3NyvT4AQ==", // 123
                    FirstName = "Maxim",
                    LastName = "Remizov",
                    RoleId = 1,
                    SecurityStamp = "E3C7D128-91F9-48B8-A766-7AA57A889D81"
                },
                new User
                {
                    Id = 2,
                    Email = "kr@mailinator.com",
                    UserName = "kr",
                    Password = "AKFIkLkiE9/JqFCtE9Y7sMMoDyWbaDtSddmCMwbF4P2Y8AbgCxITAS2B4yUf0meguA==", // 123
                    FirstName = "Kate",
                    LastName = "Remizova",
                    RoleId = 2,
                    SecurityStamp = "BB53215B-4C5F-4A73-92F9-3C9E7673EB09"
                }
            };

            Users[0].Role = Roles[0];
            Users[1].Role = Roles[1];

            Roles[0].Users.Add(Users[0]);
            Roles[1].Users.Add(Users[1]);
        }

        #region Roles

        public static List<Role> Roles { get; private set; }

        public static IEnumerable<Role> GetAllRoles()
        {
            return Roles;
        }

        public static Role GetRole(int id)
        {
            return Roles.SingleOrDefault(e => e.Id == id);
        }

        public static void AddRole(Role entity)
        {
            Roles.Add(entity);
        }

        public static void DeleteRole(int id)
        {
            Roles.Remove(GetRole(id));
        }

        public static Role GetOrCreateRole(int id)
        {
            var entity = GetRole(id);

            if (entity == null)
            {
                entity = CreateRole();
                Roles.Add(entity);
            }

            return entity;
        }

        private static Role CreateRole()
        {
            return new Role
            {
                Id = Roles.Max(e => e.Id) + 1
            };
        }

        #endregion

        #region Users

        public static List<User> Users { get; private set; }

        public static IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        #endregion
    }

    public enum RoleTypeOption
    {
        Admin = 1,
        Standard = 2
    }

    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoleTypeOption RoleType { get; set; }

        public IList<User> Users { get; set; }
    }

    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public string SecurityStamp { get; set; }
    }
}