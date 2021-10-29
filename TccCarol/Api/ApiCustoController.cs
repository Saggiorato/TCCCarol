using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TccCarol.Dados;
using TccCarol.Dados.Enum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TccCarol.Api
{
    [Route("api/[controller]")]
    public class ApiCustoController : Controller
    {
        private readonly Contexto _contexto;

        public ApiCustoController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost("ObterDados")]
        public async Task<JsonResult> ObterDados(Filtro filtro)
        {
            var i = 0;

            try
            {
                if (filtro.DataFinal == DateTime.MinValue) filtro.DataFinal = DateTime.Now;
                filtro.DataFinal.AddHours(23).AddMinutes(59).AddSeconds(59);

                var lista = new List<Custo>();


                var comprasVendas = await _contexto.HistoricoCompraVenda
                    .Where(x => x.Data >= filtro.DataInicial && x.Data <= filtro.DataFinal && x.Venda)
                    .Include(x => x.Produto).ThenInclude(x => x.Ingredientes).ThenInclude(x => x.Ingrediente).ToListAsync();

                var auxVendas = comprasVendas.Select(x => new { x.Produto, x.Preco });

                var vendas = auxVendas.Distinct();

                var despesasP = _contexto.HistoricoDespesa.Where(x => x.Porcentagem && x.Data >= filtro.DataInicial && x.Data <= filtro.DataFinal).Sum(x => x.Valor);
                var despesasPorcentagem = despesasP; // / vendas.Count();

                foreach (var venda in vendas)
                {
                    i++;
                    var quantidadeVendas = comprasVendas.Where(x => x.ProdutoId == venda.Produto.Id && x.Preco == venda.Preco).Sum(x => x.Quantidade);

                    var custo = new Custo();

                    custo.NomeProduto = venda.Produto.Nome;
                    custo.CustoCompra = Math.Round(venda.Produto.Ingredientes.Sum(x => CalcularCustoIngrediente(x.Ingrediente.PrecoAtual, x.Ingrediente.TipoMedidaPreco, x.Ingrediente.QuantidadeFabrica, x.Quantidade, x.TipoMedida)) / venda.Produto.QuantidadeFabrica, 2);
                    custo.OutrasDespesas = Math.Round(venda.Produto.OutrasDespesas / venda.Produto.QuantidadeFabrica, 2);
                    custo.DespesasComVendas = Math.Round(despesasPorcentagem, 2);
                    custo.PrecoVenda = Math.Round(venda.Preco, 2);
                    custo.QuantidadeVendas = quantidadeVendas;
                    custo.Faturamento = Math.Round(quantidadeVendas * venda.Preco, 2);


                    custo.CustoPorProduto = Math.Round(custo.CustoCompra + custo.OutrasDespesas + (venda.Preco * (despesasPorcentagem / 100)), 2);
                    custo.MargemProdutoValor = Math.Round(custo.PrecoVenda - custo.CustoPorProduto, 2);
                    custo.MargemProdutoPorcentagem = Math.Round((custo.MargemProdutoValor / custo.PrecoVenda) * 100, 2);
                    custo.TotalDespesasVariavel = Math.Round(quantidadeVendas * custo.CustoPorProduto, 2);
                    custo.MarkupFator = Math.Round(custo.PrecoVenda / custo.CustoCompra, 2);
                    custo.MarkupPorcentagem = Math.Round((custo.MarkupFator - 1) * 100, 2);

                    lista.Add(custo);
                }

                if(lista.Count() <= 0)
                {
                    return Json(new { Sucesso = true, Dados = new Dados()});
                }

                var dados = new Dados
                {
                    CustoCompra = Math.Round(lista.Sum(x => x.CustoCompra), 2),
                    OutrasDespesas = Math.Round(lista.Sum(x => x.OutrasDespesas), 2),
                    CustoPorProduto = Math.Round(lista.Sum(x => x.CustoPorProduto), 2),
                    PrecoVenda = Math.Round(lista.Sum(x => x.PrecoVenda), 2),
                    MargemProdutoValor = Math.Round(lista.Sum(x => x.MargemProdutoValor), 2),
                    MargemProdutoPorcentagem = Math.Round(lista.Sum(x => x.MargemProdutoPorcentagem) / lista.Count(), 2),
                    QuantidadeVendas = lista.Sum(x => x.QuantidadeVendas),
                    TotalDespesasVariavel = Math.Round(lista.Sum(x => x.TotalDespesasVariavel), 2),
                    Faturamento = Math.Round(lista.Sum(x => x.Faturamento), 2),

                    DespesasFixas = Math.Round(_contexto.HistoricoDespesa.Where(x => !x.Porcentagem && x.Data >= filtro.DataInicial && x.Data <= filtro.DataFinal).Sum(x => x.Valor), 2),
                    DespesasComVendas = Math.Round(despesasP, 2),
                };

                dados.DespesasVariaveis = dados.TotalDespesasVariavel;
                dados.FaturamentoTotal = dados.Faturamento;
                dados.MargemLucro = dados.FaturamentoTotal - dados.DespesasFixas - dados.DespesasVariaveis;
                dados.PontoEquilibrio = dados.DespesasFixas / (dados.TotalDespesasVariavel / dados.Faturamento);

                foreach (var item in lista)
                {
                    item.PorcentagemFaturamento = Math.Round((item.Faturamento * 100) / dados.Faturamento, 2);
                }

                dados.Custos = lista;

                return Json(new { Sucesso = true, Dados = dados });
            }
            catch (Exception ex)
            {
                var x = i;
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        private decimal CalcularCustoIngrediente(decimal custoIngrediente, TipoMedidaEnum medidaIngrediente, decimal quantidadePrecoIngrediente, decimal quantidadeNoProduto, TipoMedidaEnum medidaNoProduto)
        {
            decimal retorno = 0;

            //UN
            if (medidaIngrediente == TipoMedidaEnum.un)
            {
                var precoPorUn = custoIngrediente / quantidadePrecoIngrediente;

                retorno = precoPorUn * quantidadeNoProduto;
            }

            //KG
            if (medidaIngrediente == TipoMedidaEnum.kg)
            {
                if (medidaNoProduto == TipoMedidaEnum.kg)
                {
                    var precoPorKilo = custoIngrediente / quantidadePrecoIngrediente;

                    retorno = precoPorKilo * quantidadeNoProduto;
                }
                else if (medidaNoProduto == TipoMedidaEnum.g)
                {
                    var precoPorUn = custoIngrediente / quantidadePrecoIngrediente;

                    retorno = precoPorUn * ConverterGramaParaKiloMililitrosParaLitro(quantidadeNoProduto);
                }
            }

            //G
            if (medidaIngrediente == TipoMedidaEnum.g)
            {
                if (medidaNoProduto == TipoMedidaEnum.g)
                {
                    var precoPorgrama = custoIngrediente / quantidadePrecoIngrediente;

                    retorno = precoPorgrama * quantidadeNoProduto;
                }
                else if (medidaNoProduto == TipoMedidaEnum.kg)
                {
                    var precoPorUn = custoIngrediente / quantidadePrecoIngrediente;

                    retorno = precoPorUn * ConverterKiloparaGramaLitroParaMililitros(quantidadeNoProduto);
                }
            }

            //L
            if (medidaIngrediente == TipoMedidaEnum.l)
            {
                if (medidaNoProduto == TipoMedidaEnum.l)
                {
                    var precoPorLitro = custoIngrediente / quantidadePrecoIngrediente;

                    retorno = precoPorLitro * quantidadeNoProduto;
                }
                else if (medidaNoProduto == TipoMedidaEnum.ml)
                {
                    var precoPorLitro = custoIngrediente / quantidadePrecoIngrediente;

                    retorno = precoPorLitro * ConverterGramaParaKiloMililitrosParaLitro(quantidadeNoProduto);
                }
            }

            //ML
            if (medidaIngrediente == TipoMedidaEnum.ml)
            {
                if (medidaNoProduto == TipoMedidaEnum.ml)
                {
                    var precoPorml = custoIngrediente / quantidadePrecoIngrediente;

                    retorno = precoPorml * quantidadeNoProduto;
                }
                else if (medidaNoProduto == TipoMedidaEnum.l)
                {
                    var precoPorml = custoIngrediente / quantidadePrecoIngrediente;

                    retorno = precoPorml * ConverterKiloparaGramaLitroParaMililitros(quantidadeNoProduto);
                }
            }

            return retorno;
        }

        private decimal ConverterGramaParaKiloMililitrosParaLitro(decimal quantidade) //grama, ml
        {
            if (quantidade == 0) return 0;

            var q = quantidade / 1000;

            return q;
        }

        private decimal ConverterKiloparaGramaLitroParaMililitros(decimal quantidade) //grama, ml
        {
            if (quantidade == 0) return 0;

            var q = quantidade * 1000;

            return q;
        }
    }

    public class Filtro
    {
        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }
    }

    public class Custo
    {
        public string NomeProduto { get; set; }
        public decimal CustoCompra { get; set; }
        public decimal OutrasDespesas { get; set; }
        public decimal DespesasComVendas { get; set; }
        public decimal CustoPorProduto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal MargemProdutoValor { get; set; }
        public decimal MargemProdutoPorcentagem { get; set; }
        public int QuantidadeVendas { get; set; }
        public decimal TotalDespesasVariavel { get; set; }
        public decimal Faturamento { get; set; }
        public decimal PorcentagemFaturamento { get; set; }
        public decimal MarkupFator { get; set; }
        public decimal MarkupPorcentagem { get; set; }
    }

    public class Dados
    {
        public List<Custo> Custos { get; set; }
        public decimal CustoCompra { get; set; }
        public decimal OutrasDespesas { get; set; }
        public decimal CustoPorProduto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal MargemProdutoValor { get; set; }
        public decimal MargemProdutoPorcentagem { get; set; }
        public decimal QuantidadeVendas { get; set; }
        public decimal TotalDespesasVariavel { get; set; }
        public decimal Faturamento { get; set; }
        public decimal PorcentagemFaturamento { get; set; }

        //---
        public decimal DespesasFixas { get; set; }
        public decimal DespesasVariaveis { get; set; }
        public decimal DespesasComVendas { get; set; }
        public decimal FaturamentoTotal { get; set; }
        public decimal MargemLucro { get; set; }
        public decimal PontoEquilibrio { get; set; }
    }
}
