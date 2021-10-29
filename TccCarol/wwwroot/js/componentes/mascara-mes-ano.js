Vue.component("input-mes-ano", {
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
            vm.$emit("input", this.value);
        });
    },
    watch: {//observador que é disparado cada vez que o valor muda
        value: function (value) {
            $(this.$el).val(fomataMesAnoDigitado(value));
        }
    }
});

function fomataMesAnoDigitado(data) {
    data += "";

    if (data.length === 2) {

        if (parseInt(data) > 12 || parseInt(data) < 1) {

            data = "01";
        }

        data = data + "/";

    }

    return data;
}

