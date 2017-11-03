using WebSolution.Data;

namespace WebSolution.Models.Mappers
{
    public static class RoleListViewModelMapper
    {
        public static RoleListViewModel MapFrom(this Role entity)
        {
            return new RoleListViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                RoleType = entity.RoleType.ToString()
            };
        }
    }
}
