#pragma checksum "C:\Projetos\TccCarol\TccCarol\TccCarol\Views\Custo\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46394aaededae5a1dcea41b97c9bc56dfd275903"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Custo_Index), @"mvc.1.0.view", @"/Views/Custo/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Custo/Index.cshtml", typeof(AspNetCore.Views_Custo_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Projetos\TccCarol\TccCarol\TccCarol\Views\_ViewImports.cshtml"
using TccCarol;

#line default
#line hidden
#line 2 "C:\Projetos\TccCarol\TccCarol\TccCarol\Views\_ViewImports.cshtml"
using TccCarol.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46394aaededae5a1dcea41b97c9bc56dfd275903", @"/Views/Custo/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3255dbe36f2adf05889a88d0b6e2c7b02d22b981", @"/Views/_ViewImports.cshtml")]
    public class Views_Custo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/custo/custo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 10371, true);
            WriteLiteral(@"<div id=""custo"">
    <!--CORPO-->
    <div class=""content"">
        <div class=""animated fadeIn"">
            <div class=""row"">
                <!--LISTA-->
                <div class=""col-md-12"">
                    <div class=""card"">
                        <div class=""card-header-custom"">
                            <h4 class=""box-title"">
                                CÁLCULO DE CUSTOS
                            </h4>
                        </div>

                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-2"">
                                    <div class=""form-group"">
                                        <label class=""control-label mb-1"">Data Inicial</label>
                                        <input-databr type=""text"" class=""form-control"" v-model=""DataInicial""></input-databr>
                                    </div>
                                </div>
                                <");
            WriteLiteral(@"div class=""col-2"">
                                    <div class=""form-group"">
                                        <label class=""control-label mb-1"">Data Inicial</label>
                                        <input-databr type=""text"" class=""form-control"" v-model=""DataFinal""></input-databr>
                                    </div>
                                </div>
                                <div class=""col-3"">
                                    <div class=""form-group"">
                                        <label class=""control-label mb-1"">&nbsp;</label>
                                        <div class=""clearfix""></div>
                                        <button type=""submit"" class=""btn btn-primary"" v-on:click=""ObterDados""><i class=""fa fa-search"" aria-hidden=""true""></i>&nbsp;Filtrar</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div");
            WriteLiteral(@" class=""card-body--"">
                            <div class=""table-stats order-table ov-h"">
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th scope=""col"" width=""10%"">Produto</th>
                                            <th scope=""col"">Custo Compra</th>
                                            <th scope=""col"">Outras Despesas</th>
                                            <th scope=""col"">Desp. com Vendas</th>
                                            <th scope=""col"">Custo Por Produto</th>
                                            <th scope=""col"">Preco de Venda</th>
                                            <th scope=""col"">Margem do Produto R$</th>
                                            <th scope=""col"">Margem do Produto %</th>
                                            <th scope=""col"">Qtde de Vendas</th>
                                  ");
            WriteLiteral(@"          <th scope=""col"">Total Despesa Variáveis</th>
                                            <th scope=""col"">Faturamento R$</th>
                                            <th scope=""col"">% Sobre Faturamento</th>
                                            <th scope=""col"">Markup Fator</th>
                                            <th scope=""col"">Markup %</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for=""(item, index) in Lista"">
                                            <td>{{item.NomeProduto}}</td>
                                            <td>R$ <moedabr :value=""item.CustoCompra""></moedabr></td>
                                            <td>R$ <moedabr :value=""item.OutrasDespesas""></moedabr></td>
                                            <td><moedabr :value=""item.DespesasComVendas""></moedabr>%</td>
                                         ");
            WriteLiteral(@"   <td>R$ <moedabr :value=""item.CustoPorProduto""></moedabr></td>
                                            <td>R$ <moedabr :value=""item.PrecoVenda""></moedabr></td>
                                            <td>R$ <moedabr :value=""item.MargemProdutoValor""></moedabr></td>
                                            <td><moedabr :value=""item.MargemProdutoPorcentagem""></moedabr>%</td>
                                            <td>{{item.QuantidadeVendas}}</td>
                                            <td>R$ <moedabr :value=""item.TotalDespesasVariavel""></moedabr></td>
                                            <td>R$ <moedabr :value=""item.Faturamento""></moedabr></td>
                                            <td><moedabr :value=""item.PorcentagemFaturamento""></moedabr>%</td>
                                            <td><moedabr :value=""item.MarkupFator""></moedabr></td>
                                            <td>{{item.MarkupPorcentagem}}%</td>
                                        </");
            WriteLiteral(@"tr>
                                    </tbody>
                                    <tfoot class="""">
                                        <tr>
                                            <th>Totais</th>
                                            <th>R$ <moedabr :value=""Totais.CustoCompra""></moedabr></th>
                                            <th>R$ <moedabr :value=""Totais.OutrasDespesas""></moedabr></th>
                                            <th>-</th>
                                            <th>R$ <moedabr :value=""Totais.CustoPorProduto""></moedabr></th>
                                            <th>R$ <moedabr :value=""Totais.PrecoVenda""></moedabr></th>
                                            <th>R$ <moedabr :value=""Totais.MargemProdutoValor""></moedabr></th>
                                            <th><moedabr :value=""Totais.MargemProdutoPorcentagem""></moedabr>%</th>
                                            <th>{{Totais.QuantidadeVendas}}</th>
                    ");
            WriteLiteral(@"                        <th>R$ <moedabr :value=""Totais.TotalDespesasVariavel""></moedabr></th>
                                            <th>R$ <moedabr :value=""Totais.Faturamento""></moedabr></th>
                                            <th>100%</th>
                                            <th>-</th>
                                            <th>-</th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div> <!-- /.table-stats -->
                        </div>

                        <hr />


                        <div class=""card-body--"">
                            <div class=""table-stats ov-h"">
                                <div class=""row"">
                                    <div class=""col-5"">
                                        <table class=""table"">
                                            <tbody>
                                                <tr>
");
            WriteLiteral(@"                                                    <td>Despesas Fixas</td>
                                                    <td>R$ <moedabr :value=""Totais.DespesasFixas""></moedabr></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Despesas Variáveis
                                                    </td>
                                                    <td>R$ <moedabr :value=""Totais.DespesasVariaveis""></moedabr></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Despesas com Vendas
                                                    </td>
                                                    <td><moedabr :value=""Totais.DespesasComVendas""></moedabr");
            WriteLiteral(@">%</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class=""col-2""></div>
                                    <div class=""col-5"">
                                        <table class=""table"">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        Faturamento Total
                                                    </td>
                                                    <td>R$ <moedabr :value=""Totais.FaturamentoTotal""></moedabr></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                             ");
            WriteLiteral(@"           Margem de Lucro

                                                    </td>
                                                    <td>R$ <moedabr :value=""Totais.MargemLucro""></moedabr><moedabr style=""margin-left: 50px"" :value=""Totais.MargemLucro / Totais.FaturamentoTotal * 100""></moedabr>%</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Ponto de Equilíbrio

                                                    </td>
                                                    <td>R$ <moedabr :value=""Totais.PontoEquilibrio""></moedabr></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
               ");
            WriteLiteral("         </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(10388, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(10390, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "46394aaededae5a1dcea41b97c9bc56dfd27590314568", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(10433, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591