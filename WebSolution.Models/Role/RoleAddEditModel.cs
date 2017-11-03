using WebSolution.Data;
using WebSolution.Models.Base;

namespace WebSolution.Models
{
    public class RoleAddEditModel : BaseAddEditModel
    {
        public string Name { get; set; }

        public RoleTypeOption RoleType { get; set; }
    }
}
