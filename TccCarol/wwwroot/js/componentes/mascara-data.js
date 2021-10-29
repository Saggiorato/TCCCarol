Vue.component("input-databr", {
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

            var dataInput = this.value;

            //formata data pt br ao contrario quando o tamanho for 10
            if (dataInput.length == 10) {
                dataInput = inverteDataDDMMYYYYParaYYYYMMDD(dataInput);
                vm.$emit("input", dataInput); // seta valor do value
            } else {
                vm.$emit("input", dataInput); // seta valor do value
            }
        });

        if (this.value) {
            vm.setData(this.value);
        }
    },
    watch: {//observador que é disparado cada vez que o valor muda
        value: function (value) {

            value += "";
            value = value.split("T")[0];
            value = replaceAll(value, "-", "/");

            //pega data invertida e transforma pra pt br
            if (value.length == 10 && value.split("/")[0].length == 4) {
                value = inverteDataYYYYMMDDParaDDMMYYYY(value);
                $(this.$el).val(fomataDataDigitada(value)); // seta valor que sera mostrado
            } else {
                $(this.$el).val(fomataDataDigitada(value)); // seta valor que sera mostrado
            }
        }
    },
    methods: {
        setData: function (data) {

            if (data.length == 10) {
                data = inverteDataDDMMYYYYParaYYYYMMDD(data);
                this.$emit("input", data);
            } else {
                this.$emit("input", data);
            }
        }
    }
});

Vue.component("datahorabr",  // lembrar nome sempre tudo minusculo !!
    {
        data: function () {
            return {
                datahorabr: ""
            }
        },
        props: {
            value: String
        },
        template: "<span> {{datahorabr}} </span>",
        mounted: function () {
            this.datahorabr = FormataDataTimeBR(this.value);
        },
        watch: {
            value: function (value) {
                this.datahorabr = FormataDataTimeBR(value);
            }
        }
    });

function inverteDataDDMMYYYYParaYYYYMMDD(data) {

    data += "";

    data = data.split("/");

    data = data[2] + "/" + data[1] + "/" + data[0];

    return data;
}

function inverteDataYYYYMMDDParaDDMMYYYY(data) {
    data += "";

    data = data.split("/");

    data = data[2] + "/" + data[1] + "/" + data[0];

    return data;
}

function fomataDataDigitada(data) {
    data += "";

    if (data.length === 2) {

        if (parseInt(data) > 31 || parseInt(data) < 1) {

            data = "01";
        }

        data = data + "/";

    }
    else if (data.length === 5) {

        var dataQuebrada = data.split("/");

        var dataFloat = dataQuebrada[1];

        dataFloat = parseFloat(dataFloat);

        if (dataFloat > 12 || dataFloat < 1) {

            data = dataQuebrada[0] + "/01";
        }

        data = data + "/";
        return data;
    }

    return data;
}

Vue.component("databr",
    {
        data: function () {
            return {
                databr: ""
            }
        },
        props: {
            value: String
        },
        template: "<span> {{databr}} </span>",
        mounted: function () {
            this.databr = FormatarData(this.value);
        },
        watch: {
            value: function (value) {
                this.databr = FormatarData(value);
            }
        }
    });

function FormatarData(data) {

    var d = new Date(data);

    d = d.toLocaleDateString()

    return d;
}


Vue.component("teste",
    {
        data: function () {
            return {
                hora: ""
            }
        },
        props: {
            value: Number
        },
        template: "<span> {{hora}} </span>",
        mounted: function () {
            this.hora = formatarInternoDecimalHora(this.value);
        },
        watch: {
            value: function (value) {
                this.hora = formatarInternoDecimalHora(value);
            }
        }
    });;


function formatarInternoDecimalHora(dados) {

    dados += "";

    var d = dados.replace(".", ":");

    valor = d.split(":");

    if (d.length > 2)
    {
        if (valor[1].length < 2) {
            d += "0";
        }
    }
    if (d.length <= 2) { d += ":00"; }

    return d;

}

