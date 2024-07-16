using Microsoft.EntityFrameworkCore;

namespace TechnixAPI.Helper
{
    public class TechnixHelper
    {
        public static List<string> GetEntityNames(DbContext context)
        {
            var entityTypes = context.Model.GetEntityTypes();
            var entityNames = new List<string>();
            foreach (var entityType in entityTypes)
            {
                entityNames.Add(entityType.ClrType.Name);
            }
            return entityNames;
        }

    }
}
