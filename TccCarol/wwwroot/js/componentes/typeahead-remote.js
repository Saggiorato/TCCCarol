Vue.component("typeaheadremote", {
    props: {
        value: String,
        id: String,
        caminho: String,
        caminhoeditar: String
    },
    template: "<input :id=\"id\" style=\"width: 100%\">",
    mounted: function () {

        var self = this;

        var fonte = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace("value"),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: self.caminho,
                wildcard: "%query"
            }
        });

        $(this.$el).val(this.value).typeahead({
            hint: true,
            highlight: true,
            minLength: 2
        },
        {
            displayKey: "text",
            source: fonte,
            limit: 30
        }).on("typeahead:selected", function (evt, data) {
            this.value = data.id;
            self.$emit("input", this.value);
        });
    },
    watch: {
        value: function (value) {

            //codigo necessario pra quando seta um valor pra variavel pelo view
            var self = this;

            if (value == "") {
                $(this.$el).typeahead("val", "");
                return
            }

            var descricao = $(this.$el).val();

            if (!descricao) {

                var input = $(this.$el);

                $.getJSON(self.caminhoeditar + value)
                    .done(function (response) {

                        if (response) {
                            input.typeahead("val", response.text);
                        }
                    });
            }
        }
    }
});