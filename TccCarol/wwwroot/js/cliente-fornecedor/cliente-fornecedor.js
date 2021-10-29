var pessoa = new Vue({
    el: "#pessoa",
    data: {
        Pessoas: [],
        Id: "",
        Nome: "",
        Fornecedor: "",
        Numero: "",
        //aux
        IndexAlteracao: ""
    },
    methods: {
        Obter: function () {
            var self = this;

            $.get("/api/ApiClienteFornecedor/ObterPessoas").done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Pessoas = resposta.Pessoas;
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel buscar os clientes/fornecedor");
            });
        },
        Gravar: function () {
            var self = this;

            var pessoa = {
                Id: self.Id,
                Nome: self.Nome,
                Fornecedor: self.Fornecedor,
                Numero: self.Numero
            };

            $.post("/api/ApiClienteFornecedor/GravarPessoa", pessoa).done(function (resposta) {

                if (resposta.Sucesso) {

                    if (pessoa.Id) {
                        self.Pessoas[self.IndexAlteracao].Nome = pessoa.Nome;
                        self.Pessoas[self.IndexAlteracao].Fornecedor = pessoa.Fornecedor;
                        self.Pessoas[self.IndexAlteracao].Numero = pessoa.Numero;
                    } else {
                        pessoa.Id = resposta.Id;
                        self.Pessoas.push(pessoa);
                    }

                    $("#cadastro").modal("hide");
                    self.Limpar();

                    mensagem("Cliente/fornecedor gravado com sucesso!");
                } else {
                    mensagemErro("Não foi possivel gravar o cliente/fornecedor");
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel gravar o cliente/fornecedor");
            });
        },
        Editar: function (pessoa, index) {
            var self = this;

            self.IndexAlteracao = index;

            self.Id = pessoa.Id;
            self.Nome = pessoa.Nome;
            self.Fornecedor = pessoa.Fornecedor;
            self.Numero = pessoa.Numero;

            $("#cadastro").modal("show");
        },
        Excluir: function (id, index) {
            var self = this;

            $.post("/api/ApiClienteFornecedor/ExcluirPessoa", { Id: id }).done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Pessoas.splice(index, 1);
                    mensagem("Cliente/fornecedor excluído com sucesso!");
                } else {
                    mensagemErro("Não foi possivel excluir o cliente/fornecedor");
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel excluir o cliente/fornecedor");
            });
        },
        Limpar: function () {
            var self = this;

            self.Id = "";
            self.Nome = "";
            self.Fornecedor = "";
            self.Numero = "";
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