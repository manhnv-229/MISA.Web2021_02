using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kimerce.Backend.Infrastructure.Data.EntityMapping
{
    public interface IEntityMappingConfiguration<T> where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }

}
