using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Configuracao
{
    public class Agenda : Dados.Entidades.Agenda
    {

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Agenda>().ToTable("Agenda");

            builder.Entity<Agenda>().HasKey(x => x.Id);

            builder.Entity<Agenda>().HasIndex(x => x.Id);

            builder.Entity<Agenda>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Agenda>().Property(x => x.Descricao).HasColumnType("Text");

        }
    }
}
