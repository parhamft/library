using HW_13.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(20); 
            builder.HasOne(x=> x.User).WithMany(y=> y.Books).HasForeignKey(x=>x.UserId);
            builder.Property(x => x.Price).HasColumnType("money");
        }
    }
}
