Vue.component("input-cnpj", {
    //variavel que vai receber o valor digitado
    props: {
        value: String
    },
    //html que ele vai gerar na pagina
    template: "<input maxlength='18'/>",
    //função que vai conter no template, nesse caso o input
    mounted: function () {
        var vm = this;
        $(this.$el).val(this.value).on("keyup", function () { // cada vez que tirar o dedo da tecla vai disparar essa função

            vm.$emit("input", (this.value)); //executa a formatação do valor

        });
    },
    watch: {//observador que é disparado cada vez que o valor muda
        value: function (value) {

            $(this.$el).val(formataCnpj(value));
        }
    }
});

//12.345.678/1234-56
function formataCnpj(cnpj) {

    cnpj += "";

    cnpj = cnpj.replace(/\D/g, "");

    if (cnpj.length == 2) {

        cnpj = cnpj + ".";

        return cnpj

        // cnpj = cnpj.slice(0, 5) + "-" + cnpj.slice(5)
    }
    else if (cnpj.length > 2 && cnpj.length < 5) {
        cnpj = cnpj.slice(0, 2) + "." + cnpj.slice(2);

        return cnpj;
    }
    else if (cnpj.length == 5) {

        cnpj = cnpj.slice(0, 2) + "." + cnpj.slice(2, 5) + ".";

        return cnpj
    }
    else if (cnpj.length > 5 && cnpj.length < 8) {
        cnpj = cnpj.slice(0, 2) + "." + cnpj.slice(2, 5) + "." + cnpj.slice(5);

        return cnpj;
    }
    else if (cnpj.length == 8) {
        cnpj = cnpj.slice(0, 2) + "." + cnpj.slice(2, 5) + "." + cnpj.slice(5) + "/";

        return cnpj;
    }
    else if (cnpj.length > 8 && cnpj.length < 12) {
        cnpj = cnpj.slice(0, 2) + "." + cnpj.slice(2, 5) + "." + cnpj.slice(5, 8) + "/" + cnpj.slice(8);

        return cnpj;
    }
    else if (cnpj.length == 12) {
        cnpj = cnpj.slice(0, 2) + "." + cnpj.slice(2, 5) + "." + cnpj.slice(5, 8) + "/" + cnpj.slice(8) + "-";

        return cnpj;
    }
    else if (cnpj.length > 12) {
        cnpj = cnpj.slice(0, 2) + "." + cnpj.slice(2, 5) + "." + cnpj.slice(5, 8) + "/" + cnpj.slice(8, 12) + "-" + cnpj.slice(12);

        return cnpj;
    }

    return cnpj;
}
