Vue.component("select2", {
    data: function () {
        return {
            Idaux: "",
            PrimeiraVez: true,
            Vezes: 0,
            IdAuxD: ""
        };
    },
    props: {
        options: Array,
        value: String,
        id: String,
        selectedText: String,
    },
    template: "\
            <select :id=\"id\" style=\"width: 99%\">\
                <option value=\"\">-- Selecione --</option>\
            </select>"
    ,
    mounted: function () {
        var vm = this;
        $(this.$el)
            .val(this.value)
            // init select2
            .select2({
                data: this.options,
                theme: "bootstrap"
            })
            // emit event on change.
            .on("change", function () {
                vm.$emit("input", this.value);
                //console.log($(this).select2('data').text);
                //if (vm.id) {
                //    var textS = $("#" + vm.id + " option:selected").text();
                //    vm.selectedText = textS;
                //    //console.log(textS);
                //}

            });

        atualizarVisual(this.id);

    },
    watch: {
        value: function (value) {
            // update value          
            var select = $(this.$el).select2();
            select.val(value).trigger("change");

            if (value !== "") {
                this.Idaux = value;
            }
        },
        options: function (options) {

            $(this.$el).find('option')
                .remove()
                .end()
                .append('<option value="">--Selecione--</option>')
                .val("");

            // update options
            $(this.$el).select2({ data: options });

            //pra garantir que a lista carregue antes de selecionar o id ao editar
            if (this.value === "") {
                this.$emit("input", this.Idaux);
            }

            //console.log(this.options);
            for (var i in this.options) {

                if (this.options[i].id === this.value) {

                    var descricao = this.options[i].text;
                    $(this.$el).select2("val", descricao);

                };
            }
        }
    },
    destroyed: function () {
        $(this.$el).off().select2("destroy");
    }
});

function atualizarVisual(id) {

    setTimeout(function () {
        $("#" + id).select2({
            theme: "bootstrap"
        });
    }, 1000);
}
