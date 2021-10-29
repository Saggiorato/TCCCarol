var custo = new Vue({
    el: "#custo",
    data: {
        DataInicial: "",
        DataFinal: "",
        Lista: "",
        Totais: "",
    },
    methods: {
        ObterDados: function () {
            var self = this;

            var filtro = {
                DataInicial: self.DataInicial,
                DataFinal: self.DataFinal,
            };

            $.post("/api/ApiCusto/ObterDados", filtro).done(function (resposta) {

                if (resposta.Sucesso) {

                    if (!resposta.Dados.Custos) {
                        mensagemErro("Não foram encontrados dados");
                    } else {
                        self.Lista = resposta.Dados.Custos;
                        self.Totais = resposta.Dados;
                        mensagem("Dados obtidos com sucesso!");
                    }

                } else {
                    mensagemErro("Não foi possivel obter os dados dos custos");
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel obter os dados dos custos");
            });            
        },
    },
    created: function () {
        var self = this;

        self.ObterDados();
    }
});