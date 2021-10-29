using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccCarol.Dados.Configuracao;

namespace TccCarol.Dados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<ClienteFornecedor> ClienteFornecedor { get; set; }
        public DbSet<HistoricoCompraVenda> HistoricoCompraVenda { get; set; }
        public DbSet<HistoricoDespesa> HistoricoDespesa { get; set; }
        public DbSet<IngredienteProduto> IngredienteProduto { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<TipoDespesa> TipoDespesa { get; set; }
        public DbSet<Agenda> Agenda { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Configuracao.ClienteFornecedor.Setup(builder);
            Configuracao.HistoricoCompraVenda.Setup(builder);
            Configuracao.HistoricoDespesa.Setup(builder);
            Configuracao.IngredienteProduto.Setup(builder);
            Configuracao.Produto.Setup(builder);
            Configuracao.TipoDespesa.Setup(builder);
            Configuracao.Agenda.Setup(builder);
        }

        public virtual void AtualizarTudo<T>(T model) where T : class
        {
            Entry(model).State = EntityState.Modified;
        }

        public virtual void AtualizarCampos<T>(T model, List<string> campos) where T : class
        {
            foreach (var campo in campos)
            {
                Entry(model).Property(campo).IsModified = true;
            }
        }

        public virtual void AtualizarUmCampo<T>(T model, string campo) where T : class
        {
            Entry(model).Property(campo).IsModified = true;
        }
    }
}
