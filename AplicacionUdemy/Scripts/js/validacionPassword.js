/* creación de variables*/
let password = document.getElementById("txtcontrasena");
let configpassword = document.getElementById("txtconfirmarcontrasena");

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