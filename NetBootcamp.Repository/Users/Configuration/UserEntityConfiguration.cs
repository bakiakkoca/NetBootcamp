using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetBootcamp.Repository.Users.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Name).IsRequired().HasMaxLength(100);
            builder.Property(user => user.Surname).IsRequired().HasMaxLength(100);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(100);
            builder.Property(user => user.Created).IsRequired();
        }
    }
}
