var ingrediente = new Vue({
    el: "#ingrediente",
    data: {
        Produtos: [],
        Id: "",
        Nome: "",
        PrecoAtual: "",
        QuantidadeFabrica: "",
        Estoque: "",
        Fornecedor: "",
        OutrasDespesas: "",
        TipoMedidaPreco: 0,
        //aux
        IndexAlteracao: "",
        IndexAlteracaoIngrediente: "",
        ProdutoIngredienteNome: "",
        //ingrediente
        Ingrediente: "",
        Quantidade: "",
        TipoMedidaPrecoIngrediente: "",
        Ingredientes: []
    },
    methods: {
        Obter: function () {
            var self = this;

            $.get("/api/ApiProduto/ObterProdutos?ingrediente=true").done(function (resposta) {

                if (resposta.Sucesso) {

                    for (var i = 0; i < resposta.Produtos.length; i++) {
                        resposta.Produtos[i].PrecoAtual = (resposta.Produtos[i].PrecoAtual.toFixed(2)).toString().replace(".", ",");
                        resposta.Produtos[i].OutrasDespesas = (resposta.Produtos[i].OutrasDespesas.toFixed(2)).toString().replace(".", ",");
                    }               

                    self.Produtos = resposta.Produtos;
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel buscar os ingredientes");
            });
        },
        Gravar: function () {
            var self = this;

            var produto = {
                Id: self.Id,
                Nome: self.Nome,
                PrecoAtual: self.PrecoAtual,
                Estoque: self.Estoque,
                FornecedorId: self.Fornecedor ? self.Fornecedor.Id : "",
                OutrasDespesas: self.OutrasDespesas,
                QuantidadeFabrica: self.QuantidadeFabrica,
                TipoMedidaPreco: self.TipoMedidaPreco,
                Ingrediente: true
            };

            $.post("/api/ApiProduto/GravarProduto", produto).done(function (resposta) {

                if (resposta.Sucesso) {

                    if (produto.Id) {
                        self.Produtos[self.IndexAlteracao].Nome = produto.Nome;
                        self.Produtos[self.IndexAlteracao].PrecoAtual = produto.PrecoAtual;
                        self.Produtos[self.IndexAlteracao].Estoque = produto.Estoque;
                        self.Produtos[self.IndexAlteracao].Fornecedor = produto.Fornecedor;
                        self.Produtos[self.IndexAlteracao].OutrasDespesas = produto.OutrasDespesas;
                        self.Produtos[self.IndexAlteracao].QuantidadeFabrica = produto.QuantidadeFabrica;
                        self.Produtos[self.IndexAlteracao].TipoMedidaPreco = produto.TipoMedidaPreco;

                    } else {
                        produto.Id = resposta.Id;
                        self.Produtos.push(produto);
                    }

                    $("#cadastro").modal("hide");
                    self.Limpar();
                    mensagem("Ingrediente gravado com sucesso!");
                } else {
                    mensagemErro("Não foi possivel gravar o ingrediente");
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel gravar o ingrediente");
            });
        },
        Editar: function (produto, index) {
            var self = this;

            self.IndexAlteracao = index;

            self.Id = produto.Id;
            self.Nome = produto.Nome;
            self.PrecoAtual = produto.PrecoAtual;
            self.Estoque = produto.Estoque;
            self.Fornecedor = produto.Fornecedor;
            self.OutrasDespesas = produto.OutrasDespesas;
            self.QuantidadeFabrica = produto.QuantidadeFabrica;
            self.TipoMedidaPreco = produto.TipoMedidaPreco;

            $("#cadastro").modal("show");
        },
        Excluir: function (id, index) {
            var self = this;

            $.post("/api/ApiProduto/ExcluirProduto", { Id: id }).done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Produtos.splice(index, 1);
                    mensagem("Ingrediente excluido com sucesso!");
                } else {
                    mensagemErro("Não foi possivel excluir o ingrediente");
                }

            }).fail(function (erro) {
                mensagemErro("Não foi possivel excluir o ingrediente");

            });
        },
        Limpar: function () {
            var self = this;

            self.Id = "";
            self.Nome = "";
            self.PrecoAtual = "";
            self.Estoque = "";
            self.Fornecedor = "";
            self.OutrasDespesas = "";
        },
        AbrirModal: function () {
            var self = this;

            self.Limpar();
            $("#cadastro").modal("show");
        },
        //ingrediente
        AbrirModalIngredientes: function (id, nome) {
            var self = this;

            self.ObterIngredientes();
            self.Id = id;
            self.ProdutoIngredienteNome = nome;
            $("#ingredientes").modal("show");         
        },
        AdicionarIngrediente: function () {
            var self = this;

            var ingrediente = {
                Id: self.Id,
                ProdutoId: self.Id,
                IngredienteId: self.Ingrediente.Id,
                Quantidade: self.Quantidade,
                TipoMedidaPreco: self.TipoMedidaPrecoIngrediente,
                Ingrediente: {
                    Nome: self.Ingrediente.Nome
                }
            };

            $.post("/api/ApiProduto/GravarIngrediente", ingrediente).done(function (resposta) {

                if (resposta.Sucesso) {

                    ingrediente.Id = resposta.Id;
                    self.Ingredientes.push(ingrediente);

                    self.LimparIngrediente();
                }

            }).fail(function (erro) {

            });
        },
        ExcluirIngrediente: function (id, index) {
            var self = this;

            $.post("/api/ApiProduto/ExcluirIngrediente", { Id: id }).done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Ingredientes.splice(index, 1);
                }

            }).fail(function (erro) {

            });
        },
        LimparIngrediente: function () {
            var self = this;

            self.Ingrediente = "";
            self.Quantidade = "";
            self.TipoMedidaPrecoIngrediente = "";
        },
        ObterIngredientes: function () {
            var self = this;

            $.get("/api/ApiProduto/ObterIngredientes").done(function (resposta) {

                if (resposta.Sucesso) {
                    self.Ingredientes = resposta.Ingredientes;
                }

            }).fail(function (erro) {
            });
        },
    },
    created: function () {
        var self = this;

        self.Obter();
    }
});