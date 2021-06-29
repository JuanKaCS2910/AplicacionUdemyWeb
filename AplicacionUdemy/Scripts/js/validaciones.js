function solonumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key<=57)
}

function validaEmail(email) {
    var regex = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var rpt = regex.test(email);
    return rpt;
}