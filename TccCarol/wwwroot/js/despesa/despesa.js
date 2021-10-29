var despesa = new Vue({
    el: "#despesa",
    data: {
        Despesas: [],
        Id: "",
        Data: "",
        TipoDespesa: "",
        Valor: "",
        Observacao: "",
        Porcentagem: false,
        //aux
        IndexAlteracao: "",
        TiposDespesas: []
    },
    methods: {
        Obter: function () {
            var self = this;

            $.get("/api/ApiDespesa/ObterDespesas").done(function (resposta) {

                if (resposta.Sucesso) {

                    for (var i = 0; i < resposta.Despesas.length; i++) {
                        resposta.Despesas[i].Valor = (resposta.Despesas[i].Valor).toString().replace(".", ",");
                    }

                    self.Despesas = resposta.Despesas;
                }

            }).fail(function (erro) {
            });
        },
        Gravar: function () {
            var self = this;

            var despesa = {
                Id: self.Id,
                Data: self.Data,
                TipoDespesaId: self.TipoDespesa.Id,
                Valor: self.Valor,
                Porcentagem: self.Porcentagem,
                Observacao: self.Observacao,
                TipoDespesa: self.TipoDespesa
            };

            $.post("/api/ApiDespesa/GravarDespesa", despesa).done(function (resposta) {

                if (resposta.Sucesso) {

                    if (despesa.Id) {
                        self.Despesas[self.IndexAlteracao].Descricao = despesa.Descricao;
                        self.Despesas[self.IndexAlteracao].Valor = despesa.Valor;
                        self.Despesas[self.IndexAlteracao].Observacao = despesa.Observacao;
                        self.Despesas[self.IndexAlteracao].Porcentagem = despesa.Porcentagem;                       
                        self.Despesas[self.IndexAlteracao].TipoDespesa = {
                            Descricao: self.TipoDespesa.Descricao,
                            Id: self.TipoDespesa.Id
                        };
                    } else {
                        despesa.Id = resposta.Id;
                        self.Despesas.push(despesa);
                    }

                    self.Limpar();
                }

            }).fail(function (erro) {

            });
        },
        Editar: function (despesa, index) {
            var self = this;

            self.IndexAlteracao = index;

            self.Id = despesa.Id;
            self.Data = despesa.Data.split("T")[0];
            self.TipoDespesa = { Id: despesa.TipoDespesa.Id, Descricao: despesa.TipoDespesa.Descricao };
            self.Valor = despesa.Valor;
            self.Observacao = despesa.Observacao;
            self.Porcentagem = despesa.Porcentagem;
        },
        Excluir: function (id, index) {
            var self = this;

            $.post("/api/ApiDespesa/ExcluirDespesa", { Id: id }).done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Despesas.splice(index, 1);
                }

            }).fail(function (erro) {

            });
        },
        Limpar: function () {
            var self = this;

            self.Id = "";
            self.Data = "";
            self.TipoDepesa = 0;
            self.Valor = "";
            self.Observacao = "";
            self.Porcentagem = false;
        },
        ObterTiposDespesa: function () {
            var self = this;

            $.get("/api/ApiDespesa/ObterTiposDespesas").done(function (resposta) {

                if (resposta.Sucesso) {
                    self.TiposDespesas = resposta.TiposDespesas;
                }

            }).fail(function (erro) {
            });
        }
    },
    created: function () {
        var self = this;

        self.Obter();
        self.ObterTiposDespesa();
    }
});