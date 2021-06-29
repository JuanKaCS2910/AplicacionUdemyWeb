/*Enviar funciones con Parámetros*/
//Creación de Un archivo Global

function Post(url, paramss) {
    return ajaxMethod(url, "POST", paramss);
}

function ajaxMethod(url, method, paramss) {
    return $.ajax({
        url: window.appURL + url,
        method: method,
        async: false,
        cache: false,
        data: paramss
    }).fail(function (jqXHR, textStatus, errorThrowm) {
        console.debug(jqXHR);
        console.debug(textStatus);
        console.debug(errorThrowm);
    })
}

function fnBaseURLWeb(url) {
    return window.appURL + url;
}