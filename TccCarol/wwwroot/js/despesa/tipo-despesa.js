var tipoDespesa = new Vue({
    el: "#tipo-despesa",
    data: {
        TiposDespesas: [],
        Id: "",
        Descricao: "",
        ValorFixo: "",
        Observacao: "",
        //aux
        IndexAlteracao: "",
    },
    methods: {
        Obter: function () {
            var self = this;

            $.get("/api/ApiDespesa/ObterTiposDespesas").done(function (resposta) {

                if (resposta.Sucesso) {
                    self.TiposDespesas = resposta.TiposDespesas;
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel buscar os tipos de despesa");
            });
        },
        Gravar: function () {
            var self = this;

            var despesa = {
                Id: self.Id,
                Descricao: self.Descricao,
                ValorFixo: self.ValorFixo,
                Observacao: self.Observacao
            };

            $.post("/api/ApiDespesa/GravarTiposDespesas", despesa).done(function (resposta) {

                if (resposta.Sucesso) {

                    if (despesa.Id) {
                        self.TiposDespesas[self.IndexAlteracao].Descricao = despesa.Descricao;
                        self.TiposDespesas[self.IndexAlteracao].ValorFixo = despesa.ValorFixo;
                        self.TiposDespesas[self.IndexAlteracao].Observacao = despesa.Observacao;
                    } else {
                        despesa.Id = resposta.Id;
                        self.TiposDespesas.push(despesa);
                    }

                    $("#cadastro").modal("hide");
                    self.Limpar();
                    mensagem("Tipo de despesa gravado com sucesso!");

                } else {
                    mensagemErro("Não foi possivel gravar o tipo de despesa");
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel gravar o tipo de despesa");
            });
        },
        Editar: function (despesa, index) {
            var self = this;

            self.IndexAlteracao = index;

            self.Id = despesa.Id;
            self.Descricao = despesa.Descricao;
            self.ValorFixo = despesa.ValorFixo;
            self.Observacao = despesa.Observacao;

            $("#cadastro").modal("show");
        },
        Excluir: function (id, index) {
            var self = this;

            $.post("/api/ApiDespesa/ExcluirTipoDespesa", { Id: id }).done(function (resposta) {

                if (resposta.Sucesso) {
                    self.TiposDespesas.splice(index, 1);
                    mensagem("Tipo de despesa excluído com sucesso!");

                } else {
                    mensagemErro("Não foi possivel excluir o tipo de despesa");
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel excluir o tipo de despesa");
            });
        },
        Limpar: function () {
            var self = this;

            self.Id = "";
            self.Descricao = "";
            self.ValorFixo = "";
            self.Observacao = "";
        },
        AbrirModal: function () {
            var self = this;

            self.Limpar();
            $("#cadastro").modal("show");
        }
    },
    created: function () {
        var self = this;

        self.Obter();
    }
});