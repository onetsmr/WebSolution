using WebSolution.Data;

namespace WebSolution.Web.Infrastructure.Security
{
    public interface ICurrentUser
    {
        string Id { get; }

        string UserName { get; }

        string DisplayName { get; }

        RoleTypeOption RoleType { get; }

        string RoleName { get; }
    }
}
