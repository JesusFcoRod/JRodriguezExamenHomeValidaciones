
$('#txtInicio').change(calculardiferencia);
$('#txtFin').change(calculardiferencia);
calculardiferencia();


function calculardiferencia() {
    var hora_inicio = $('#txtInicio').val();
    var hora_final = $('#txtFin').val();

    // Expresión regular para comprobar formato
    var formatohora = /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/;

    // Si algún valor no tiene formato correcto sale
    if (!(hora_inicio.match(formatohora)
        && hora_final.match(formatohora))) {
        return;
    }

    // Calcula los minutos de cada hora
    var minutos_inicio = hora_inicio.split(':')
        .reduce((p, c) => parseInt(p) * 60 + parseInt(c));
    var minutos_final = hora_final.split(':')
        .reduce((p, c) => parseInt(p) * 60 + parseInt(c));

    // Diferencia de minutos
    var diferencia = minutos_final - minutos_inicio;

    // Cálculo de horas y minutos de la diferencia
    var horas = Math.floor(diferencia / 60);
    var minutos = diferencia % 60;

    $('#DurActivity').val(horas + ':'
        + (minutos < 10 ? '0' : '') + minutos);


    if (diferencia > 60) {
        window.alert("Las actividades deben tener una duracion maxima de 1 hora, verifique los tiempos de inicio y fin, por favor.");
        $('#txtInicio').val("");
        $('#txtFin').val("");
        $('#DurActicity').val("")
    }


}





