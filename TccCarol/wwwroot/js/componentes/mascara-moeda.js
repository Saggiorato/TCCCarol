Vue.component("input-moedabr", {
    //variavel que vai receber o valor digitado
    props: {
        value: String
    },
    //html que ele vai gerar na pagina
    template: "<input/>",
    //função que vai conter no template, nesse caso o input
    mounted: function () {
        var vm = this;
        $(this.$el).val(this.value).on("keyup", function () { // cada vez que tirar o dedo da tecla vai disparar essa função

            vm.$emit("input", converterDecimalParaRealTempoReal(this.value));

        });
    },
    watch: {//observador que é disparado cada vez que o valor muda
        value: function (value) {

            $(this.$el).val(converterDecimalParaRealTempoReal(value));
        }
    }
});

Vue.component("moedabr", {
    data: function () {
        return {
            valor: ""
        };
    },
    props: {
        value: Number
    },
    template: "<span> {{valor}} </span>",
    mounted: function () {
        this.valor = mostrarMoeda(this.value);
    },
    watch: {
        value: function (value) {
            this.valor = mostrarMoeda(this.value);
        }
    }
});