Vue.component("input-cep", {
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

            vm.$emit("input", (this.value)); //executa a formatação do valor

        });
    },
    watch: {//observador que é disparado cada vez que o valor muda
        value: function (value) {

            $(this.$el).val(formataCep(value));
        }
    }
});

function formataCep(cep) {

    cep += "";

    cep = cep.replace(/\D/g, "");

    if (cep.length > 4) {

        cep = cep.slice(0, 5) + "-" + cep.slice(5)
    }

    return cep;
}
