#pragma checksum "C:\Projetos\TccCarol\TccCarol\TccCarol\Views\Simulador\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b52d89f0d79b928a64dc4c4bfc67d201ed2aff2a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Simulador_Index), @"mvc.1.0.view", @"/Views/Simulador/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Simulador/Index.cshtml", typeof(AspNetCore.Views_Simulador_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b52d89f0d79b928a64dc4c4bfc67d201ed2aff2a", @"/Views/Simulador/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3255dbe36f2adf05889a88d0b6e2c7b02d22b981", @"/Views/_ViewImports.cshtml")]
    public class Views_Simulador_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/custo/simulador.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 3496, true);
            WriteLiteral(@"<div id=""simulador"">
    <!--CORPO-->
    <div class=""content"">
        <div class=""animated fadeIn"">
            <div class=""row"">
                <!--LISTA-->
                <div class=""col-md-12"">
                    <div class=""card"">
                        <div class=""card-header-custom"">
                            <h4 class=""box-title"">
                                SIMULADOR DO CÁLCULO DE CUSTOS
                            </h4>
                        </div>

                        <div class=""card-body--"">
                            <div class=""table-stats order-table ov-h"">
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th scope=""col"" width=""10%"">Produto</th>
                                            <th scope=""col"">Custo Compra</th>
                                            <th scope=""col"">Outras Despesas</th>
                 ");
            WriteLiteral(@"                           <th scope=""col"">Desp. com Vendas</th>
                                            <th scope=""col"">Custo Por Produto</th>
                                            <th scope=""col"">Preco de Venda</th>
                                            <th scope=""col"">Margem do Produto R$</th>
                                            <th scope=""col"">Margem do Produto %</th>
                                            <th scope=""col"">Qtde de Vendas</th>
                                            <th scope=""col"">Total Despesa Variáveis</th>
                                            <th scope=""col"">Faturamento R$</th>
                                            <th scope=""col"">% Sobre Faturamento</th>
                                            <th scope=""col"">Markup Fator</th>
                                            <th scope=""col"">Markup %</th>
                                        </tr>
                                    </thead>
                                   ");
            WriteLiteral(@" <tbody>
                                        <tr>
                                            <td><input type=""text"" class=""form-control padding-2"" v-model=""Produto"" /></td>
                                            <td><input type=""text"" class=""form-control padding-2"" v-model=""CustoCompra"" /></td>
                                            <td><input type=""text"" class=""form-control padding-2"" v-model=""OutrasDespesas"" /></td>
                                            <td><input type=""text"" class=""form-control padding-2"" v-model=""DespesasComVendas"" /></td>
                                            <td>{{CustoPorProduto}}</td>
                                            <td><input type=""text"" class=""form-control padding-2"" v-model=""PrecoVenda"" /></td>
                                            <td>{{MargemReal}}</td>
                                            <td>{{MargemPorcentagem}}</td>
                                            <td><input type=""text"" class=""form-control padding-2"" v-");
            WriteLiteral(@"model=""QuantidadeVendas"" /></td>
                                            <td>{{TotalDespesasVariaveis}}</td>
                                            <td>{{Faturamento}}</td>
                                            <td>{{MarkupFator}}</td>
                                            <td>{{MarkupPorcentagem}}</td>
                                        </tr>
                                    </tbody>
");
            EndContext();
            BeginContext(4937, 171, true);
            WriteLiteral("                                </table>\r\n                            </div> <!-- /.table-stats -->\r\n                        </div>\r\n\r\n                        <hr />\r\n\r\n\r\n");
            EndContext();
            BeginContext(8590, 114, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(8721, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(8727, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b52d89f0d79b928a64dc4c4bfc67d201ed2aff2a7920", async() => {
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
                BeginContext(8774, 2, true);
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