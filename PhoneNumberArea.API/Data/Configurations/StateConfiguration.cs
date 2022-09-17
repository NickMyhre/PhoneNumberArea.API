using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneNumberArea.API.Data.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasData(
                new State
                {
                    Id = 1,
                    Name = "Oklahoma",
                    Abbreviation = "OK"
                },
                new State
                {
                    Id = 2,
                    Name = "Texas",
                    Abbreviation = "TX"
                },
                new State
                {
                    Id = 3,
                    Name = "Montana",
                    Abbreviation = "MT"
                }
                );
        }
    }
}
