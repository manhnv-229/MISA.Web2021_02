using Microsoft.EntityFrameworkCore;
using System;

namespace Kimerce.Backend.Infrastructure.Data.EntityMapping
{
    public static class EntityMappingExtensions
    {
        public static ModelBuilder RegisterEntityMapping<TEntity, TMapping>(this ModelBuilder builder)
            where TMapping : IEntityMappingConfiguration<TEntity>
            where TEntity : class
        {
            var mapper = (IEntityMappingConfiguration<TEntity>)Activator.CreateInstance(typeof(TMapping));
            mapper.Map(builder.Entity<TEntity>());
            return builder;
        }
    }
}
