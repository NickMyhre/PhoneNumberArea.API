using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneNumberArea.API.Data.Configurations
{
    public class AreaCodeConfiguration : IEntityTypeConfiguration<AreaCode>
    {
        public void Configure(EntityTypeBuilder<AreaCode> builder)
        {
            builder.HasData(
                new AreaCode
                {
                    Id = 1,
                    Code = 918,
                    StateId = 1
                },
                new AreaCode
                {
                    Id = 2,
                    Code = 405,
                    StateId = 1
                },
                new AreaCode
                {
                    Id = 3,
                    Code = 580,
                    StateId = 1
                },
                new AreaCode
                {
                    Id = 4,
                    Code = 281,
                    StateId = 2
                },
                new AreaCode
                {
                    Id = 5,
                    Code = 346,
                    StateId = 2
                },
                new AreaCode
                {
                    Id = 6,
                    Code = 713,
                    StateId = 2
                },
                new AreaCode
                {
                    Id = 7,
                    Code = 832,
                    StateId = 2
                },
                new AreaCode
                {
                    Id = 8,
                    Code = 406,
                    StateId = 3
                }
                );
        }
    }
}
