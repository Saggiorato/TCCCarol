Vue.component("typeahead", {
    props: {
        options: [],
        value: String,
        id: String
    },
    template: "<input :id=\"id\" style=\"width: 100%\">"
        ,

    mounted: function () {

        var vm = this;

        var states = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.whitespace,
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            local: vm.options
        });

        $(this.$el).val(this.value).typeahead({
            hint: true,
            highlight: true,
            minLength: 0
        },
        {
            displayKey: "text",
            source: states,
            limit: 30
        }).on("typeahead:selected", function (evt, data) {
            this.value = data.id;
            vm.$emit("input", this.value);
        });

    },
    watch: {
        value: function (value) {
            //quando for setado um valor pelo vue ele não seleciona sem esse codigo
            var objeto = $.grep(this.options, function (e) { return e.id === value; });

            var descricao = "";

            if (objeto.length === 1) {
                descricao = objeto[0].text;
            }

            $(this.$el).typeahead("val", descricao);
            this.value = value;
        },

        options: function (options) {

            var lista = new Bloodhound({
                datumTokenizer: Bloodhound.tokenizers.obj.whitespace("text"), // qual propriedade do objeto que vai mostrar
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                local: options
            });

            // update options
            $(this.$el).typeahead({
                hint: true,
                highlight: true,
                minLength: 0
            },
            {
                displayKey: "text",
                source: lista,
                limit: 30
            });

            //pra garantir que a lista carregue antes de selecionar o id ao editar
            this.$emit("input", this.value);

            for (var i in this.options) {

                if (this.options[i].id === this.value) {

                    var descricao = this.options[i].text;
                    $(this.$el).typeahead("val", descricao);

                };
            }
        }
    }
});