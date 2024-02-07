using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RbPharma.Domain.V1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbPharma.Infrastructure.Users.V1.Mappers
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id);

            builder.Property(h => h.UserName)
                .HasColumnName("Usuario")
                .IsUnicode(false)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
