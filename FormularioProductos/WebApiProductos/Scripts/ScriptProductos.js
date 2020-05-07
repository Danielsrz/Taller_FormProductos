$(function () {
    actualizarGrilla();
    $('#btnGuardar').click(function () { guardarProducto(); });
    $('#btnEliminar').click(function () { borrarProducto(); });
    $('#btnCancelar').click(function () { limpiarFormulario(); });
    $('#btnGuardar').val('Agregar');
});


function actualizarGrilla() {
    var data = ajaxGET();
    construyeGrilla(data);
    sessionStorage.setItem("IDProducto", 0);
};

function ajaxGET() {
    var result;

    $.ajax({
        url: 'https://localhost:44370/api/producto/',
        type: 'GET',
        async: false
    }).done(function (data) {
        result = data;
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function ajaxPOST() {
    var result;
    var obj = obtenerProducto();

    $.ajax({
        url: 'https://localhost:44370/api/producto/',
        type: 'POST',
        async: false,
        data: { "Id": obj.Id, "Nombre": obj.Nombre, "Descripcion": obj.Descripcion, "Precio": obj.Precio, "Stock": obj.Stock }
    }).done(function (data) {
        result = data;
        //("#modalAgregar").modal("show");
        //alert('Elemento insertado')
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function ajaxPUT() {
    var result;
    var obj = obtenerProducto();

    $.ajax({
        url: 'https://localhost:44370/api/producto/',
        type: 'PUT',
        async: false,
        data: obj
    }).done(function (data) {
        result = data;
        //$("#modalModificar").modal("show");
        //alert('Elemento actualizado')
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });
    return result;
}

function ajaxDELETE(id) {
    var result;

    $.ajax({
        url: 'https://localhost:44370/api/producto/' + id,
        type: 'DELETE',
        async: false
    }).done(function (data) {
        result = data;
        //$("#modalEliminar").modal("show");
        //alert('Elemento borrado')
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function construyeGrilla(data) {
    var grd = $('#grdProductos');
    grd.html("");
    var tbl = $('<table class="table table-hover mt-2"></table>');


    var header = $(' <thead class="table-primary"><tr></tr></thead>');
    header.append('<th scope="col">Id</th>');
    header.append('<th scope="col">Nombre</th>');
    header.append('<th scope="col">Descripción</th>');
    header.append('<th scope="col">Precio</th>');
    header.append('<th scope="col">Stock</th>');

    tbl.append(header);


    for (d in data) {
        var row = $('<tr class="jqClickeable"></tr>');
        row.append('<td>' + data[d].Id + '</td>');
        row.append('<td>' + data[d].Nombre + '</td>');
        row.append('<td>' + data[d].Descripcion + '</td>');
        row.append('<td>' + data[d].Precio + '</td>');
        row.append('<td>' + data[d].Stock + '</td>');

        tbl.append(row);
    }

    grd.append(tbl);
    $('.jqClickeable').click(function () { mostrarElemento($(this)); });

}

function mostrarElemento(elem) {
    $('#btnGuardar').val('Modificar');
    sessionStorage.setItem("IDProducto", elem.children().eq(0).text());
    $('#txtNombre').val(elem.children().eq(1).text());
    $('#txtDesc').val(elem.children().eq(2).text());
    $('#txtPrecio').val(elem.children().eq(3).text());
    $('#txtStock').val(elem.children().eq(4).text());
}

function borrarProducto()
{
    var id = sessionStorage.getItem("IDProducto"); 
    ajaxDELETE(id);
    actualizarGrilla();
    limpiarFormulario();
}

function guardarProducto() {
    var id = sessionStorage.getItem("IDProducto");
    //var id = $('#txtID').val();
        if (id == 0) {
            ajaxPOST();
        }
        else {
            ajaxPUT();
        }
        actualizarGrilla();
        limpiarFormulario();
}

function obtenerProducto() {
    var producto = {};
    producto.Id = sessionStorage.getItem("IDProducto");
    producto.Nombre = $('#txtNombre').val();
    producto.Descripcion = $('#txtDesc').val();
    producto.Precio = $('#txtPrecio').val();
    producto.Stock = $('#txtStock').val();

    return producto;
}

//function validarFormulario() {
//    var todoCorrecto = true;
//    if (document.getElementById("txtNombre").value < 1)
//        todoCorrecto = false;
//    if (document.getElementById("txtDesc").value < 1)
//        todoCorrecto = false;
//    if (document.getElementById("txtPrecio").value < 1)
//        todoCorrecto = false;
//    if (document.getElementById("txtStock").value < 1)
//        todoCorrecto = false;
//    return todoCorrecto;
//}

function limpiarFormulario() {
    document.getElementById("productosHTML").reset();
    sessionStorage.setItem("IDProducto", 0);
    $('#btnGuardar').val('Agregar');
}