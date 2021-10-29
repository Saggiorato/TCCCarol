function mensagem(mensagem) {
    $.notify(mensagem, "success");
}

function mensagemErro(mensagem) {
    $.notify(mensagem, "error");
}

function mostrarMoeda(valor) {
    if (!valor) return "0,00";

    if (!isNaN(valor)) {
        var x = valor.toFixed(2).toString().replace(".", ",");
        return x;
    } else {
        return valor;
    }
}





function converterDecimalParaReal(valor) {

    if (!valor) return "0,00";

    if (typeof valor !== "number") {
        valor += "";
        //valor = valor.replace(",", "-");
        //valor = valor.split(".").join(",");
        //valor = valor.replace("-", ".");
    }

    valor = parseFloat(valor).toFixed(2);
    valor = valor.replace(/(\d)(?=(\d{3})+\.)/g, "$1/");
    valor = valor.toString();
    valor = valor.replace(".", ",");
    valor = valor.split("/").join(".");

    //se não tiver casas decimais
    if ((valor.indexOf(",") === -1)) {
        valor = valor + ",00";
    }

    //se tiver casas decimais
    if ((valor.indexOf(",") > -1)) {

        valor = valor + "00";

        valor = valor.split(",");

        valor = [valor[0], valor[1].substring(0, 2)].join(",");
    }

    return valor;
}

function converterDecimalParaRealTempoReal(valor) {

    valor += "";
    valor = valor.replace(/\D/g, ""); // RegExp  \D = obtem todos os caracteres n digitos
    valor = valor.replace(/\./g, ""); // \. = obtem todos os pontos
    valor = replaceAll(valor, ",", "");

    var tmp = valor + "";

    if (tmp.length === 1) {

        tmp = "," + tmp;
    }

    tmp = tmp.replace(/([0-9]{2})$/g, ",$1");
    if (tmp.length > 6)
        tmp = tmp.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");
    if (tmp.length > 10)
        tmp = tmp.replace(/([0-9]{3}).([0-9]{3}),([0-9]{2})$/g, ".$1.$2,$3");
    if (tmp.length > 14)
        tmp = tmp.replace(/([0-9]{3}).([0-9]{3}).([0-9]{3}),([0-9]{2}$)/g, ".$1.$2.$3,$4");

    return tmp;
}

////$(document).ajaxStart(function () {
////    $("#carregando-menu").show();
////});

////$(document).ajaxComplete(function () {
////    $("#carregando-menu").hide();
////});

function escapeRegExp(str) {
    return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
}

function replaceAll(str, find, replace) {
    return str.toString().replace(new RegExp(escapeRegExp(find), 'g'), replace);
}

//function RemoverPontos(dado) {

//    return dado.split(".").join("");
//}

//function ConverteBrToDecimal(valor) {

//    return valor.split(".").join("").split(",").join(".");
//}

//function converterDecimalParaRealTempoReal(valor) {

//    valor += "";
//    valor = valor.replace(/\D/g, ""); // RegExp  \D = obtem todos os caracteres n digitos
//    valor = valor.replace(/\./g, ""); // \. = obtem todos os pontos
//    valor = replaceAll(valor, ",", "");

//    var tmp = valor + "";

//    if (tmp.length === 1) {

//        tmp = "," + tmp;
//    }

//    tmp = tmp.replace(/([0-9]{2})$/g, ",$1");
//    if (tmp.length > 6)
//        tmp = tmp.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");
//    if (tmp.length > 10)
//        tmp = tmp.replace(/([0-9]{3}).([0-9]{3}),([0-9]{2})$/g, ".$1.$2,$3");
//    if (tmp.length > 14)
//        tmp = tmp.replace(/([0-9]{3}).([0-9]{3}).([0-9]{3}),([0-9]{2}$)/g, ".$1.$2.$3,$4");

//    return tmp;
//}

////converte decimal para real
//function converterDecimalParaReal(valor) {

//    if (!valor) return "0,00";

//    if (typeof valor !== "number") {
//        valor += "";
//        //valor = valor.replace(",", "-");
//        //valor = valor.split(".").join(",");
//        //valor = valor.replace("-", ".");
//    }

//    valor = parseFloat(valor).toFixed(2);
//    valor = valor.replace(/(\d)(?=(\d{3})+\.)/g, "$1/");
//    valor = valor.toString();
//    valor = valor.replace(".", ",");
//    valor = valor.split("/").join(".");

//    //se não tiver casas decimais
//    if ((valor.indexOf(",") === -1)) {
//        valor = valor + ",00";
//    }

//    //se tiver casas decimais
//    if ((valor.indexOf(",") > -1)) {

//        valor = valor + "00";

//        valor = valor.split(",");

//        valor = [valor[0], valor[1].substring(0, 2)].join(",");
//    }

//    return valor;
//}

//function formataDataTempoReal(data) {
//    data += "";

//    if (data.length === 2) {

//        if (parseInt(data) > 31 || parseInt(data) < 1) {

//            data = "01";
//        }

//        data = data + "/";

//    }
//    else if (data.length === 5) {

//        var dataQuebrada = data.split("/");

//        var dataFloat = dataQuebrada[1];

//        dataFloat = parseFloat(dataFloat);

//        if (dataFloat > 12 || dataFloat < 1) {

//            data = dataQuebrada[0] + "/01";
//        }

//        data = data + "/";
//        return data;
//    }

//    return data;
//}

function formatarData(data) {

    if (!data) return "";

    var d = new Date(data);

    d = d.toLocaleDateString();

    return d;
}

//function decimalParaPesoBr(valor) {

//    if (!valor) return 0;

//    if (typeof valor !== "number") {
//        valor += "";
//        valor = valor.replace(",", "-");
//        valor = valor.split(".").join("");
//        valor = valor.replace("-", ".");
//    }

//    valor = parseFloat(valor).toFixed(3);
//    valor = valor.replace(/(\d)(?=(\d{3})+\.)/g, "$1/");
//    valor = valor.toString();
//    valor = valor.replace(".", ",");
//    valor = valor.split("/").join(".");

//    //se não tiver casas decimais
//    if ((valor.indexOf(",") === -1)) {
//        valor = valor + ",000";
//    }

//    //se tiver casas decimais
//    if ((valor.indexOf(",") > -1)) {

//        valor = valor + "000";

//        valor = valor.split(",");

//        valor = [valor[0], valor[1].substring(0, 3)].join(",");
//    }

//    return valor;
//}

//function decimalParaPesoBrTempoReal(valor) {

//    valor += "";
//    valor = valor.replace(/\D/g, ""); // RegExp  \D = obtem todos os caracteres n digitos
//    valor = valor.replace(/\./g, ""); // \. = obtem todos os pontos
//    valor = replaceAll(valor, ",", "");

//    var tmp = valor + "";

//    if (tmp.length < 3 && tmp.length > 0) {

//        tmp = "," + tmp;
//    }

//    tmp = tmp.replace(/([0-9]{3})$/g, ",$1");

//    if (tmp.length > 7)
//        tmp = tmp.replace(/([0-9]{3}),([0-9]{3}$)/g, ".$1,$2");
//    if (tmp.length > 11)
//        tmp = tmp.replace(/([0-9]{3}).([0-9]{3}),([0-9]{3})$/g, ".$1.$2,$3");
//    if (tmp.length > 15)
//        tmp = tmp.replace(/([0-9]{3}).([0-9]{3}).([0-9]{3}),([0-9]{3}$)/g, ".$1.$2.$3,$4");

//    return tmp;
//}

//function PopupBoleto(data) {
//    var mywindow = window.open('', 'Impressão', 'height=600,width=1000, resizable=1,scrollbars=1, toolbar=1');
//    mywindow.document.write(data);
//    mywindow.document.close(); // necessary for IE >= 10
//    mywindow.focus(); // necessary for IE >= 10

//    mywindow.print();
//}

//function mesAbreviado(mes) {

//    mes += "00" + mes;

//    mes = mes.substring(mes.length - 2, mes.length);

//    switch (mes) {
//        case "01":
//            return "Jan";
//        case "02":
//            return "Fev";
//        case "03":
//            return "Mar";
//        case "04":
//            return "Abr";
//        case "05":
//            return "Mai";
//        case "06":
//            return "Jun";
//        case "07":
//            return "Jul";
//        case "08":
//            return "Ago";
//        case "09":
//            return "Set";
//        case "10":
//            return "Out";
//        case "11":
//            return "Nov";
//        case "12":
//            return "Dez";
//    }
//}

//function somenteNumeros(num) {
//    num.value = num.value.replace(/\D/g, '');
//}

//function somenteLetras(num) {
//    num.value = num.value.split(/^[0-9.,]+$/).join("");
//}

//// data de Hoje
//function dataAtualFormatada() {
//    var today = new Date();
//    var dia = today.getDate();
//    if (dia.toString().length == 1)
//        dia = "0" + dia;
//    var mes = today.getMonth() + 1;
//    if (mes.toString().length == 1)
//        mes = "0" + mes;
//    var ano = today.getFullYear();
//    return dia + "/" + mes + "/" + ano;
//}

//function ConverteMoedaBrParaDecimal(valor) {
//    if (!valor) return 0;

//    valor += "";
//    valor = valor.replace(",", "-");
//    valor = valor.split(".").join("");
//    valor = valor.replace("-", ".");

//    if (!valor) return 0;

//    valor = parseFloat(valor);

//    return valor;
//}