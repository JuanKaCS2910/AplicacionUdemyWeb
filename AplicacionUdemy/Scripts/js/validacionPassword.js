/* creación de variables*/
let password = document.getElementById("txtcontrasena");
let configpassword = document.getElementById("txtconfirmarcontrasena");
document.getElementById("btnregistrar").disabled = true;

if (password.value == "") {
    document.getElementById("btnregistrar").disabled = true;
}

if (configpassword.value == "") {
    document.getElementById("btnregistrar").disabled = true;
}

$("#faeye").click(function () {
    if (password.type === 'password') {
        password.setAttribute("type", "text");
        $("#faeye").hide();
        $("#faeyeslash").show();
    }
});

$("#faeyeslash").click(function () {
    password.setAttribute("type", "password");
    $("#faeyeslash").hide();
    $("#faeye").show();
});

$("#txtcontrasena").keyup(function () {
    let contrasena = $("#txtcontrasena").val();
    let confirmarcontrasena = $("#txtconfirmarcontrasena").val();
    if (contrasena == "") {
        password.setAttribute('type', 'password');
        $("#faeyeslash").hide();
        $("#faeye").show();
        $("#msjcontrasena").html("").css("color", "red");
        document.getElementById("btnregistrar").disabled = true;
    }
    else {
        $("#faeye").show();

        if (!/[A-Z]/.test(contrasena)) {
            $("#msjcontrasena").html("Debe tener al menos una mayúscula").css("color", "red");
            $("#txtcontrasena").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (!/[a-z]/.test(contrasena)) {
            $("#msjcontrasena").html("Debe tener al menos una minúscula").css("color", "red");
            $("#txtcontrasena").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (!/[#@!$%=]/.test(contrasena)) {
            $("#msjcontrasena").html("Debe tener al menos un caracter especial").css("color", "red");
            $("#txtcontrasena").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (contrasena.length < 8) {
            $("#msjcontrasena").html("Debe tener como mínimo 8 caracteres").css("color", "red");
            $("#txtcontrasena").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (confirmarcontrasena != ""){
            if (contrasena != confirmarcontrasena) {
                $("#msjcontrasena").html("Las contraseñas no coinciden").css("color", "red");
                $("#txtcontrasena").css("border-color", "red");
                document.getElementById("btnregistrar").disabled = true;
            }else {
                $("#msjcontrasena").html("").css("color", "red");
                $("#txtcontrasena").css("border-color", "");
                $("#msjcontrasenaconf").html("").css("color", "red");
                $("#txtconfirmarcontrasena").css("border-color", "");
                document.getElementById("btnregistrar").disabled = false;
            }
        }
        else {
            $("#msjcontrasena").html("").css("color", "red");
            $("#txtcontrasena").css("border-color", "");
            document.getElementById("btnregistrar").disabled = true;
        }

    }
});

/***********************************************/

$("#faeyeconfir").click(function () {
    if (configpassword.type === 'password') {
        configpassword.setAttribute("type", "text");
        $("#faeyeconfir").hide();
        $("#faeyeslashconfir").show();
    }
});

$("#faeyeslashconfir").click(function () {
    configpassword.setAttribute("type", "password");
    $("#faeyeslashconfir").hide();
    $("#faeyeconfir").show();
});

$("#txtconfirmarcontrasena").keyup(function () {
    let contrasena = $("#txtcontrasena").val();
    let confirmarcontrasena = $("#txtconfirmarcontrasena").val();
    if (confirmarcontrasena == "") {
        configpassword.setAttribute('type', 'password');
        $("#faeyeconfir").hide();
        $("#faeyeslashconfir").show();
        $("#msjcontrasenaconf").html("").css("color", "red");
        document.getElementById("btnregistrar").disabled = true;
    }
    else {
        $("#faeye").show();

        if (!/[A-Z]/.test(confirmarcontrasena)) {
            $("#msjcontrasenaconf").html("Debe tener al menos una mayúscula").css("color", "red");
            $("#txtconfirmarcontrasena").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (!/[a-z]/.test(confirmarcontrasena)) {
            $("#msjcontrasenaconf").html("Debe tener al menos una minúscula").css("color", "red");
            $("#txtconfirmarcontrasena").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (!/[#@!$%=]/.test(confirmarcontrasena)) {
            $("#msjcontrasenaconf").html("Debe tener al menos un caracter especial").css("color", "red");
            $("#txtconfirmarcontrasena").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (confirmarcontrasena.length < 8) {
            $("#msjcontrasenaconf").html("Debe tener como mínimo 8 caracteres").css("color", "red");
            $("#txtconfirmarcontrasena").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (contrasena != "") {
            if (contrasena != confirmarcontrasena) {
                $("#msjcontrasenaconf").html("Las contraseñas no coinciden").css("color", "red");
                $("#txtconfirmarcontrasena").css("border-color", "red");
                document.getElementById("btnregistrar").disabled = true;
            } else {
                $("#msjcontrasenaconf").html("").css("color", "red");
                $("#txtconfirmarcontrasena").css("border-color", "");
                $("#msjcontrasena").html("").css("color", "red");
                $("#txtcontrasena").css("border-color", "");
                document.getElementById("btnregistrar").disabled = false;
            }
        }
        else {
            $("#msjcontrasenaconf").html("").css("color", "red");
            $("#txtconfirmarcontrasena").css("border-color", "");
            document.getElementById("btnregistrar").disabled = true;
        }

    }
});