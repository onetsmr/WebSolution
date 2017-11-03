using WebSolution.Data;

namespace WebSolution.Models.Mappers
{
    public static class RoleAddEditModelMapper
    {
        public static RoleAddEditModel MapTo(this Role entity)
        {
            return new RoleAddEditModel
            {
                Id = entity.Id,
                Name = entity.Name,
                RoleType = entity.RoleType
            };
        }

        public static Role MapFrom(this Role entity, RoleAddEditModel model)
        {
            entity.Name = model.Name;
            entity.RoleType = model.RoleType;

            return entity;
        }
    }
}
