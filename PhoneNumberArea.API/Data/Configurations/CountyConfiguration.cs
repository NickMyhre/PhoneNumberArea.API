using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneNumberArea.API.Data.Configurations
{
    public class CountyConfiguration : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.HasData(
                new County
                {
                    Id = 1,
                    Name = "Muskogee",
                    AreaCodeId = 1
                },
                new County
                {
                    Id = 2,
                    Name = "Blaine",
                    AreaCodeId = 2
                },
                new County
                {
                    Id = 3,
                    Name = "Alfalfa",
                    AreaCodeId = 3
                },
                new County
                {
                    Id = 4,
                    Name = "Harris",
                    AreaCodeId = 4
                },
                new County
                {
                    Id = 5,
                    Name = "Pasadena",
                    AreaCodeId = 5
                },
                new County
                {
                    Id = 6,
                    Name = "Galveston",
                    AreaCodeId = 6
                },
                new County
                {
                    Id = 7,
                    Name = "Brazoria",
                    AreaCodeId = 7
                },
                new County
                {
                    Id = 8,
                    Name = "Big Sky",
                    AreaCodeId = 8
                },
                new County
                {
                    Id = 9,
                    Name = "Glacier",
                    AreaCodeId = 8
                }
                );
        }
    }
}
