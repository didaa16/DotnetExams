using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Infrastructure.Configurations
{
    internal class TacheConfig : IEntityTypeConfiguration<Tache>
    {
        public void Configure(EntityTypeBuilder<Tache> builder)
        {
            builder.HasOne(t => t.membre)
                .WithMany(t => t.taches)
                .HasForeignKey(t => t.MembreKey);

            builder.HasOne(t => t.sprint)
                .WithMany(t => t.taches)
                .HasForeignKey(t => t.SprintKey);

            builder.HasKey(t => new { t.SprintKey, t.MembreKey, t.Titre });

        }
    }
}
