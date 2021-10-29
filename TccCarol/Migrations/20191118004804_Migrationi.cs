using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TccCarol.Migrations
{
    public partial class Migrationi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientesFornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Fornecedor = table.Column<bool>(nullable: false),
                    Numero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesFornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDespesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ValorFixo = table.Column<decimal>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDespesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    PrecoAtual = table.Column<decimal>(nullable: false),
                    TipoMedidaPreco = table.Column<int>(nullable: false),
                    Estoque = table.Column<int>(nullable: false),
                    FornecedorId = table.Column<Guid>(nullable: true),
                    OutrasDespesas = table.Column<decimal>(nullable: false),
                    TipoMedida = table.Column<int>(nullable: false),
                    QuantidadeFabrica = table.Column<int>(nullable: false),
                    Ingrediente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_ClientesFornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "ClientesFornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosDespesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoDespesaId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    Porcentagem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosDespesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricosDespesa_TiposDespesas_TipoDespesaId",
                        column: x => x.TipoDespesaId,
                        principalTable: "TiposDespesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosCompraVenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ClienteFornecedorId = table.Column<Guid>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    Venda = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosCompraVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricosCompraVenda_ClientesFornecedores_ClienteFornecedorId",
                        column: x => x.ClienteFornecedorId,
                        principalTable: "ClientesFornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricosCompraVenda_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    IngredienteId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false),
                    TipoMedida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredienteProduto_Produtos_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredienteProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesFornecedores_Id",
                table: "ClientesFornecedores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosCompraVenda_ClienteFornecedorId",
                table: "HistoricosCompraVenda",
                column: "ClienteFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosCompraVenda_Id",
                table: "HistoricosCompraVenda",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosCompraVenda_ProdutoId",
                table: "HistoricosCompraVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosDespesa_Id",
                table: "HistoricosDespesa",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosDespesa_TipoDespesaId",
                table: "HistoricosDespesa",
                column: "TipoDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteProduto_Id",
                table: "IngredienteProduto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteProduto_IngredienteId",
                table: "IngredienteProduto",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteProduto_ProdutoId",
                table: "IngredienteProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Id",
                table: "Produtos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDespesas_Id",
                table: "TiposDespesas",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricosCompraVenda");

            migrationBuilder.DropTable(
                name: "HistoricosDespesa");

            migrationBuilder.DropTable(
                name: "IngredienteProduto");

            migrationBuilder.DropTable(
                name: "TiposDespesas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "ClientesFornecedores");
        }
    }
}
