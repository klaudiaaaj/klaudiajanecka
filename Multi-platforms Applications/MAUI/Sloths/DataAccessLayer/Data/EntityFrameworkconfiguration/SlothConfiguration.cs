using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sloths.Models.Sloth;

namespace Sloths.Data.EntityFrameworkconfiguration;

class SlothConfiguration : IEntityTypeConfiguration<Sloth>
{
	public void Configure(EntityTypeBuilder<Sloth> builder)
	{
		builder.ToTable("Sloth", Constants.Schema);

		builder.HasKey(s => s.Id);

		builder.Property(s => s.Name)
			.IsRequired()
			.HasMaxLength(256);

		builder.Property(s => s.Population)
			.IsRequired();

		builder.Property(s => s.MinSize)
		builder.Property(s => s.MaxSize)
		builder.Property(s => s.MinWeight)
		builder.Property(s => s.MaxWeight)
		builder.Property(s => s.Localization)
            .HasMaxLength(535);

        builder.Property(s => s.Description)
            .HasMaxLength(535);

        builder.Property(s => s.Image)
            .HasMaxLength(535);

        builder.Property(s => s.Latitude)

        builder.Property(s => s.Longitude)
	}
}

