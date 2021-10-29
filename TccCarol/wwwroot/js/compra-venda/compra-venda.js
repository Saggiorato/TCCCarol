var compraVenda = new Vue({
    el: "#compra-venda",
    data: {
        //Cadastro
        Id: "",
        Produto: "", //ProdutoId
        Preco: "",
        Data: "",
        ClienteFornecedor: "", //ClienteFornecedorId
        Quantidade: "",
        Observacao: "",
        Venda: "",
        //aux
        IndexAlteracao: "",
        //Listagem
        Lista: [],
        Produtos: [],
        Pessoas: []
    },
    methods: {
        Gravar: function () {
            var self = this;

            var historico = {
                Id: self.Id,
                ProdutoId: self.Produto.Id, //Id
                Preco: self.Preco,
                Data: self.Data,
                ClienteFornecedorId: self.ClienteFornecedor.Id, //ClienteFornecedorId
                Quantidade: self.Quantidade,
                Observacao: self.Observacao,
                Venda: self.Venda,
            };

            var total = (parseFloat(historico.Preco.replace(",", ".")) * parseInt(historico.Quantidade)).toFixed(2).toString().replace(".", ",");

            historico.Total = total;

            $.post("/api/ApiCompraVenda/GravarCompraVenda", historico).done(function (resposta) {

               

                if (resposta.Sucesso) {

                    if (historico.Id) {
                        self.Lista[self.IndexAlteracao].Preco = parseInt(historico.Preco.replace(",", "."));
                        self.Lista[self.IndexAlteracao].Data = historico.Data;
                        self.Lista[self.IndexAlteracao].Quantidade = historico.Quantidade;
                        self.Lista[self.IndexAlteracao].Observacao = historico.Observacao;
                        self.Lista[self.IndexAlteracao].Venda = historico.Venda;
                        self.Lista[self.IndexAlteracao].Total = total;
                        self.Lista[self.IndexAlteracao].Produto = {
                            Nome: self.Produto.Nome,
                            Id: self.Produto.Id
                        };
                        self.Lista[self.IndexAlteracao].ClienteFornecedor = {
                            Nome: self.ClienteFornecedor.Nome,
                            Id: self.ClienteFornecedor.Id
                        };
                    } else {
                        historico.Id = historico.Id;
                        self.Lista.push(historico);
                    }

                    self.Limpar();
                }

            }).fail(function (erro) {

            });
        },
        Editar: function (item, index) {
            var self = this;

            self.IndexAlteracao = index;

            self.Id = item.Id;
            var data = formatarData(item.Data);
            self.Data = data;
            self.Produto = { Id: item.Produto.Id, Nome: item.Produto.Nome };
            self.Preco = item.Preco.toString().replace(".", ",");
            self.Data = item.Data;
            self.ClienteFornecedor = { Id: item.ClienteFornecedor ? item.ClienteFornecedor.Id : "", Nome: item.ClienteFornecedor ? item.ClienteFornecedor.Nome : "" };
            self.Quantidade = item.Quantidade;
            self.Observacao = item.Observacao;
            self.Venda = item.Venda;

            $("#cadastro").modal("show");
        },
        Excluir: function (id, index) {
            var self = this;

            $.post("/api/ApiCompraVenda/ExcluirHistorico", { Id: id }).done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Lista.splice(index, 1);
                }

            }).fail(function (erro) {

            });
        },
        Obter: function () {
            var self = this;

            $.get("/api/ApiCompraVenda/ObterHistorico").done(function (resposta) {

                for (var i = 0; i < resposta.CompraVenda.length; i++) {
                    resposta.CompraVenda[i].Total = ((resposta.CompraVenda[i].Preco * resposta.CompraVenda[i].Quantidade).toFixed(2)).toString().replace(".", ",");
                    resposta.CompraVenda[i].Preco = (resposta.CompraVenda[i].Preco.toFixed(2)).toString().replace(".", ",");
                }

                if (resposta.Sucesso) {
                    self.Lista = resposta.CompraVenda;
                }

            }).fail(function (erro) {
            });
        },
        //aux
        AbrirModal: function () {
            var self = this;

            self.Limpar();
            $("#cadastro").modal("show");
        },
        Limpar: function () {
            var self = this;

            self.Id = "";
            self.Produto = "";
            self.Preco = "";
            //self.Data = "";
            self.ClienteFornecedor = "";
            self.Quantidade = "";
            self.Observacao = "";
            //self.Venda = "";
        },
        ObterProdutos: function () {
            var self = this;

            $.get("/api/ApiProduto/ObterProdutos").done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Produtos = resposta.Produtos;
                }

            }).fail(function (erro) {
            });
        },
        ObterPessoas: function () {
            var self = this;

            $.get("/api/ApiClienteFornecedor/ObterPessoas").done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Pessoas = resposta.Pessoas;
                }

            }).fail(function (erro) {
            });
        },

    },
    created: function () {
        var self = this;

        self.ObterProdutos();
        self.ObterPessoas();
        self.Obter();
    }
})