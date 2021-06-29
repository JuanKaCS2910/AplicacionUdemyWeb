$(document).ready(function () {

    document.getElementById("rdsi").checked = true;
    $("#divvendeimpuestos").show();
});


/*Visualizar imagen*/
$("#imagen").change(function () {
    let imagen = this.files[0];
    if (imagen["type"] != "image/jpeg" && imagen["type"] != "image/png") {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("Debe subir una imagen en formato jpeg o png");
    } else if (imagen["size"] > 200000) {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("La imagen debe tener como máximo 2MB");
    }
    else {
        var datosImagen = new FileReader;
        datosImagen.readAsDataURL(imagen);

        $(datosImagen).on("load", function (event) {
            var rutaImagen = event.target.result;
            $(".previsualizar").attr("src", rutaImagen);
        })

    }
});

$("#rdsi").click(function () {
    $("#divvendeimpuestos").show();
    document.getElementById("rdno").checked = false;
});

$("#rdno").click(function () {
    $("#divvendeimpuestos").hide();
    document.getElementById("rdsi").checked = false;
});