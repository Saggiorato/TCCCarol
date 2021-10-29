
var graficos = new Vue({
    el: "#graficos",
    data: {
        DataInicial: "",
        DataFinal: "",
        Lista: "",
        ListaDespesas: "",
        DadosLucro: [],
        DadosFaturamento: [],
        DadosUnidade: [],
        Expandido: false
    },
    methods: {
        MargemLucroProduto: function () {
            var self = this;

            var ctx = document.getElementById("lucro-produto");
            ctx.height = 150;

            //Chart.pluginService.register({
            //    beforeRender: function (chart) {
            //        if (chart.config.options.showAllTooltips) {
            //            // create an array of tooltips
            //            // we can't use the chart tooltip because there is only one tooltip per chart
            //            chart.pluginTooltips = [];
            //            chart.config.data.datasets.forEach(function (dataset, i) {
            //                chart.getDatasetMeta(i).data.forEach(function (sector, j) {
            //                    chart.pluginTooltips.push(new Chart.Tooltip({
            //                        _chart: chart.chart,
            //                        _chartInstance: chart,
            //                        _data: chart.data,
            //                        _options: chart.options.tooltips,
            //                        _active: [sector]
            //                    }, chart));
            //                });
            //            });

            //            // turn off normal tooltips
            //            chart.options.tooltips.enabled = false;
            //        }
            //    },
            //    afterDraw: function (chart, easing) {
            //        if (chart.config.options.showAllTooltips) {
            //            // we don't want the permanent tooltips to animate, so don't do anything till the animation runs atleast once
            //            if (!chart.allTooltipsOnce) {
            //                if (easing !== 1)
            //                    return;
            //                chart.allTooltipsOnce = true;
            //            }

            //            // turn on tooltips
            //            chart.options.tooltips.enabled = true;
            //            Chart.helpers.each(chart.pluginTooltips, function (tooltip) {
            //                tooltip.initialize();
            //                tooltip.update();
            //                // we don't actually need this since we are not animating tooltips
            //                tooltip.pivot();
            //                tooltip.transition(easing).draw();
            //            });
            //            chart.options.tooltips.enabled = false;
            //        }
            //    }
            //})

            var myChart = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    datasets: [{
                        data: self.DadosLucro.valores,
                        backgroundColor: self.DadosLucro.cores,
                        hoverBackgroundColor: self.DadosLucro.cores
                    }],
                    labels: self.DadosLucro.nomes
                },
                options: {
                    //showAllTooltips: true,
                    responsive: true
                }
            });
        },
        PorcentagemFaturamento: function () {
            var self = this;

            var ctx = document.getElementById("faturamento-produto");
            ctx.height = 150;

            var myChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    datasets: [{
                        data: self.DadosFaturamento.valores,
                        backgroundColor: self.DadosFaturamento.cores,
                        hoverBackgroundColor: self.DadosFaturamento.cores
                    }],
                    labels: self.DadosFaturamento.nomes
                },
                options: {
                    responsive: true
                }
            });
        },
        FaturamentoUnidade: function () {
            var self = this;

            var ctx = document.getElementById("faturamento-unidade");
            ctx.height = 150;

            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: self.DadosUnidade.nomes,
                    datasets: [
                        {
                            label: "Produtos",
                            data: self.DadosUnidade.valores,
                            borderColor: "rgba(0, 194, 146, 0.9)",
                            borderWidth: "0",
                            backgroundColor: "rgba(0, 194, 146, 0.5)"
                        }
                    ]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        },
        Despesas: function () {
            var self = this;

            var ctx = document.getElementById("despesas");
            ctx.height = 150;

            var myChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    datasets: [{
                        data: self.ListaDespesas.Porcentagem,
                        backgroundColor: self.ListaDespesas.cores,
                        hoverBackgroundColor: self.ListaDespesas.cores
                    }],
                    labels: self.ListaDespesas.Nome
                },
                options: {
                    responsive: true
                }
            });
        },
        ObterDados: function () {
            var self = this;

            var filtro = {
                DataInicial: self.DataInicial,
                DataFinal: self.DataFinal,
            };

            $.post("/api/ApiCusto/ObterDados", filtro).done(function (resposta) {

                if (resposta.Sucesso) {

                    self.Lista = resposta.Dados.Custos;

                    //self.Totais = resposta.Dados;

                    $.post("/api/ApiDespesa/ObterDespesasGrafico", filtro).done(function (resposta) {

                        if (resposta.Sucesso) {
                            self.ListaDespesas = resposta.Despesas;

                            self.ListaDespesas.cores = [];

                            for (var i = 0; i < self.ListaDespesas.Nome.length; i++) {
                                self.ListaDespesas.cores.push(getRandomColor());
                            }

                            self.ProcessarDados();
                        }

                    }).fail(function (erro) {

                    });
                }

            }).fail(function (erro) {

            });
        },
        ProcessarDados: function () {
            var self = this;

            var NomeProduto = [];

            //margem de lucro
            var porcentagensLucro = [];
            //porcentagem faturamento
            var porcentagensFaturamento = [];
            //faturamentoUnidade
            var faturamentoUnidade = [];

            var cores = [];

            for (var i = 0; i < self.Lista.length; i++) {

                var item = self.Lista[i];

                NomeProduto.push(item.NomeProduto);
                porcentagensLucro.push(item.MargemProdutoPorcentagem);
                porcentagensFaturamento.push(item.PorcentagemFaturamento);
                faturamentoUnidade.push(item.QuantidadeVendas);
                cores.push(getRandomColor());
            }

            self.DadosLucro = {
                valores: porcentagensLucro,
                nomes: NomeProduto,
                cores: cores
            };

            self.DadosFaturamento = {
                valores: porcentagensFaturamento,
                nomes: NomeProduto,
                cores: cores
            };

            self.DadosUnidade = {
                valores: faturamentoUnidade,
                nomes: NomeProduto,
                cores: cores
            };

            self.MargemLucroProduto();
            self.PorcentagemFaturamento();
            self.FaturamentoUnidade();
            self.Despesas();
        },
        ExpandirRetrair: function () {
            var self = this;

            self.Expandido = !self.Expandido;
        }
    },
    mounted: function () {
        var self = this;

        self.ObterDados();
    }
});

function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}
