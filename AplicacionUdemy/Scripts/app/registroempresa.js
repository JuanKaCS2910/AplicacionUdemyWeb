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

//$("#rdsi").on("click",function(){});
$("#rdsi").click(function () {
    $("#divvendeimpuestos").show();
    document.getElementById("rdno").checked = false;
});

$("#rdno").click(function () {
    $("#divvendeimpuestos").hide();
    document.getElementById("rdsi").checked = false;
});

$("#btnsiguiente").click(function () {
    let razonsocial = $("#txtrazonsocial").val();
    let ruc = $("#txtruc").val();
    let email = $("#txtemail").val();

    if (razonsocial == "") {
        $("#msjrazonsocial").html("* El campo razón social no debe estar vacio").css("color", "red");
        $("#txtrazonsocial").css("border-color", "red");
        $("#txtrazonsocial").focus();
    } else if (ruc == "") {
        $("#msjruc").html("* El campo ruc no debe estar vacio").css("color", "red");
        $("#txtruc").css("border-color", "red");
        $("#txtruc").focus();
    } else if (email == "") {
        $("#msjemail").html("* El campo email no debe estar vacio").css("color", "red");
        $("#txtemail").css("border-color", "red");
        $("#txtemail").focus();
    } else if (!validaEmail(email)) {
        $("#msjemail").html("Debe ingresar un email válido").css("color", "red");
        $("#txtemail").css("border-color", "");
        $("#txtemail").focus();
    }

});

$("#txtrazonsocial").keyup(function () {
    let razonsocial = $("#txtrazonsocial").val();

    if (razonsocial == "") {
        $("#msjrazonsocial").html("* El campo razón social no debe estar vacio").css("color", "red");
        $("#txtrazonsocial").css("border-color", "red");
        $("#txtrazonsocial").focus();
    } else {
        $("#msjrazonsocial").html("").css("color", "red");
        $("#txtrazonsocial").css("border-color", "");
    }
});

$("#txtruc").keyup(function () {
    let ruc = $("#txtruc").val();

    if (ruc == "") {
        $("#msjruc").html("* El campo ruc no debe estar vacio").css("color", "red");
        $("#txtruc").css("border-color", "red");
        $("#txtruc").focus();
    } else {
        $("#msjruc").html("").css("color", "red");
        $("#txtruc").css("border-color", "");
    }
});

$("#txtemail").keyup(function () {
    let email = $("#txtemail").val();

    if (email == "") {
        $("#msjemail").html("* El campo email no debe estar vacio").css("color", "red");
        $("#txtemail").css("border-color", "red");
        $("#txtemail").focus();
    } else {
        if (!validaEmail(email)) {
            $("#msjemail").html("Debe ingresar un email válido").css("color", "red");
            $("#txtemail").css("border-color", "");
        }
        else {
            $("#msjemail").html("").css("color", "red");
            $("#txtemail").css("border-color", "");
        }
        
    }
});