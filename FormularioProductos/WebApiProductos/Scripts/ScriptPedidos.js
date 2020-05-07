$(function () {
    $('#btnPedido').click(function () { guardarPedido(); });
    var dataCli = clienteGET();
    construirComboCli(dataCli);
    var dataPro = productoGET();
    construirComboPro(dataPro);
    actualizarGrilla();
});

function actualizarGrilla() {
    var data = pedidoGET();
    construyeGrilla(data);
}

function clienteGET() {
    var result;

    $.ajax({
        url: 'https://localhost:44370/api/cliente/',
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

function productoGET() {
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

function construirComboCli(data) {
    var cmb = $('#cmbClientes');
    cmb.html("");
    var select = $('<select name="selectClientes"> </select>');
    var titulo = $('<option hidden selected>Seleccione un Cliente</option>');
    select.append(titulo);
    for (d in data) {
        select.append($('<option>' +  data[d].Nombre + '</option>'));
    }
    cmb.append(select);
}

function construirComboPro(data) {
    var cmb = $('#cmbProductos');
    cmb.html("");
    var select = $('<select name="selectClientes"> </select>');
    var titulo = $('<option hidden selected>Seleccione un Producto</option>');
    select.append(titulo);
    for (d in data) {
        select.append($('<option>' + data[d].Nombre + '</option>'));
    }
    cmb.append(select);
}

function guardarPedido() {
    pedidoPOST();
    actualizarGrilla();
    restablecer();
}

function pedidoPOST() {
    var result;
    var obj = obtenerPedido();

    $.ajax({
        url: 'https://localhost:44370/api/pedido/',
        type: 'POST',
        async: false,
        data: { "ID": obj.Id, "Cliente": obj.Cliente, "Producto": obj.Producto, "Cantidad": obj.Cantidad}
    }).done(function (data) {
        result = data;
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function obtenerPedido(){
    var pedido = {};
    pedido.Cliente = $('#cmbClientes option:selected').text();
    pedido.Producto = $('#cmbProductos option:selected').text();
    pedido.Cantidad = $('#txtCantidad').val();

    return pedido;
}

function pedidoGET() {
    var result;

    $.ajax({
        url: 'https://localhost:44370/api/pedido/',
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

function construyeGrilla(data) {
    var grd = $('#grdPedidos');
    grd.html("");
    var tbl = $('<table class="table table-hover mt-2"></table>');


    var header = $(' <thead class="table-primary"><tr></tr></thead>');
    header.append('<th scope="col">ID</th>');
    header.append('<th scope="col">Cliente</th>');
    header.append('<th scope="col">Producto</th>');
    header.append('<th scope="col">Cantidad</th>');
    header.append('<th scope="col">Total</th>');

    tbl.append(header);


    for (d in data) {
        var row = $('<tr></tr>');
        row.append('<td>' + data[d].ID + '</td>');
        row.append('<td>' + data[d].Cliente + '</td>');
        row.append('<td>' + data[d].Producto + '</td>');
        row.append('<td>' + data[d].Cantidad + '</td>');
        row.append('<td>0</td>');

        tbl.append(row);
    }

    grd.append(tbl);
}

function restablecer() {
    $('txtCantidad').val = 0;
}