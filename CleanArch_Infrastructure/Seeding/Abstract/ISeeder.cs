using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Seeding.Abstract
{
    public interface ISeeder<T> where T : class
    {
        void Seed(EntityTypeBuilder<T> builder);
    }
}