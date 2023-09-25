// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#btnAddCustomerCar').click(function () {
    $('#AddCustomerCar').modal('show');
    $(document).ready(function () {
        // Send an AJAX request
        $("#ShowManufacturers").append($("<option></option>").val(0).html("--Select Manufacturer--"));
        $.getJSON('https://localhost:7096/api/GetCarManufacturersToList')
            //$.getJSON('http://alefhome.ddns.net:8082/api/GetCarManufacturersToList')
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $("#ShowManufacturers").append($("<option></option>").val(item.id).html(item.manufacturerName));
                });
            });
    });
})

$('#btnAddEngineer').click(function () {
    $('#AddEngineer').modal('show');
    $(document).ready(function () {
        // Send an AJAX request
        $("#EngineerSpeciality").append($("<option></option>").val(0).html("--Select test--"));
        $.getJSON('https://localhost:7096/api/GetEngineerSpecialities')
           //$.getJSON('http://alefhome.ddns.net:8082/api/GetEngineerSpecialities')
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $("#EngineerSpeciality").append($("<option></option>").val(item.id).html(item.speciality));
                });
            });
    });
})