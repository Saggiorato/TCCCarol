using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Configuracao
{
    public class ClienteFornecedor : Entidades.ClienteFornecedor
    {
        public virtual List<Produto> Produtos { get; set; }
        public virtual List<HistoricoCompraVenda> HistoricosCompraVenda { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<ClienteFornecedor>().ToTable("ClientesFornecedores");
            builder.Entity<ClienteFornecedor>().HasKey(x => x.Id);
            builder.Entity<ClienteFornecedor>().HasIndex(x => x.Id);
            builder.Entity<ClienteFornecedor>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
