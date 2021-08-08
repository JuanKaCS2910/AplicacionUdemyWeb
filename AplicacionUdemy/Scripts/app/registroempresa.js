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
    } else {
        var paramss = new Object();
        paramss.razonSocial = razonsocial;
        paramss.ruc = ruc;
        paramss.email = email;
        Post("RegistroEmpresa/validarRegistro", paramss).done(function (datos) {
            if (datos.dt.response == "Ok") {
                $(".divregistroempresa").hide();
                $(".divregistrousersuperadmin").show();
                document.getElementById("btnregistrar").disabled = true;
            }
            else {
                //Visualización para mensaje de Error.
                swal({
                    position: "top-end",
                    type: "error",
                    title: datos.dt.response,
                    text: 'Por favor valida el campo solicitado',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }
        });
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

$("#btnregistrar").on("click", function () {

    let razonsocial = $("#txtrazonsocial").val();
    let ruc = $("#txtruc").val();
    let email = $("#txtemail").val();
    let idpais = $("#slpais").val();
    let idmoneda = $("#slmoneda").val();
    let direccion = $("#txtdireccion").val();
    
    let idimpuesto = 0;
    let idporcentaje = 0;
    let vendeimpuesto = 0;

    let username = $("#txtuseradmin").val();
    let usuario = $("#txtusuario").val();
    let contrasena = $("#txtcontrasena").val();
    let confircontrasena = $("#txtconfirmarcontrasena").val();

    if ($("#rdsi").is(":checked")==true) {
        idimpuesto = $("#sltipoimpuesto").val();
        idporcentaje = $("#slporcentaje").val();
        vendeimpuesto = 1;
    }

    if (username == "") {
        $("#msjusername").html("El campo nombre administrador no debe estar vacio").css("color", "red");
        $("#txtuseradmin").css("border-color", "red");
        $("#txtuseradmin").focus();
    } else if (usuario == "") {
        $("#msjusuario").html("El campo usuario no debe estar vacio").css("color", "red");
        $("#txtusuario").css("border-color", "red");
        $("#txtusuario").focus();
    } else if (contrasena == "") {
        $("#msjcontrasena").html("El campo contraseña no debe estar vacio").css("color", "red");
        $("#txtcontrasena").css("border-color", "red");
        $("#txtcontrasena").focus();
    } else if (confircontrasena == "") {
        $("#txtconfirmarcontrasena").html("El campo confirmar contraseña no debe estar vacio").css("color", "red");
        $("#msjcontrasenaconf").css("border-color", "red");
        $("#msjcontrasenaconf").focus();
    } else {
        let oData = new FormData();
        //Para enviar imagenes necesito poner en Forms el razor. (XMLHttpRequest)
        let slfile = ($("#imagen"))[0].files[0];
        oData.append("file", slfile);
        oData.append("razonSocial", razonsocial);
        oData.append("ruc", ruc);
        oData.append("email", email);
        oData.append("idPais", idpais);
        oData.append("idMoneda", idmoneda);
        oData.append("direccion", direccion);
        
        oData.append("idImpuesto", idimpuesto);
        oData.append("idPorcentaje", idporcentaje);
        oData.append("vendeImpuesto", vendeimpuesto);
        
        oData.append("username", username);
        oData.append("usuario", usuario);
        oData.append("contrasena", contrasena);

        PostImg("RegistroEmpresa/insertarEmpresa", oData).done(function (datos) {
            if (datos.dt.response == "Ok") {
                swal({
                    position: 'top-end',
                    type: 'success',
                    title: 'Empresa guardada correctamente',
                    text: 'Se envio un correo con sus accesos',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                }).then((result) => {
                    if (result.value) {
                        //window.location = fnBaseURLWeb("Home/Index");
                    } else {
                        //window.location = fnBaseURLWeb("Home/Index");
                    }
                })
            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: 'No se guardo la empresa',
                    text: 'Contáctese con el administrado del sistema',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }
        });
    }

    
});