/* Manufacturer */
function getManufacturers() {
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
}

function getSelectedManufacturer() {
    var e = document.getElementById("ShowManufacturers");
    var value = e.options[e.selectedIndex].value;
    var text = e.options[e.selectedIndex].text;
    //console.log("MANUFACTURER == ID: " + value + " == Name: " + text);
    return value;
}

function getManufacturersForModel(manufacturerID) {
    $(document).ready(function () {
        // Send an AJAX request
        clearDataModels();
        $("#ShowModels").append($("<option></option>").val(0).html("--Select Model--"));
        $.getJSON('https://localhost:7096/api/GetCarModelManufacturerYearByManufacturerID/' + manufacturerID)
        //$.getJSON('http://alefhome.ddns.net:8082/api/GetCarModelManufacturerYearByManufacturerID/' + manufacturerID)
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $("#ShowModels").append($("<option></option>").val(item.id).html(item.modelName));
                });
            });
    });
}

function getSelectedModel() {
    var e = document.getElementById("ShowModels");
    var value = e.options[e.selectedIndex].value;
    var text = e.options[e.selectedIndex].text;
    //console.log("MODEL == ID: " + value + " == Name: " + text);
    return value;
}

function getYearsForModel(modelID) {
    $(document).ready(function () {
        // Send an AJAX request
        clearDataYears();
        $("#ShowYears").append($("<option></option>").val(0).html("--Select Year--"));
        $.getJSON('https://localhost:7096/api/GetCarModelManufacturerYearByModelID/' + modelID)
        //$.getJSON('http://alefhome.ddns.net:8082/api/GetCarModelManufacturerYearByModelID/' + modelID)
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $("#ShowYears").append($("<option></option>").val(item.id).html(item.description));
                });
            });
    });
}

function clearDataModels() {
    const container = document.getElementById('ShowModels');
    container.replaceChildren();
}

function clearDataYears() {
    const container = document.getElementById('ShowYears');
    container.replaceChildren();
}

function getEngineers() {
    $(document).ready(function () {
        // Send an AJAX request
        $("#ShowEngineers").append($("<option></option>").val(0).html("--Select Engineer--"));
        $.getJSON('https://localhost:7096/api/GetEngineers')
        //$.getJSON('http://alefhome.ddns.net:8082/api/GetEngineers')
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $("#ShowEngineers").append($("<option></option>").val(item.id).html(item.surname +' '+ item.name));
                });
            });
    });
}

function getEngineerSpeciality() {
    $(document).ready(function () {
        // Send an AJAX request
        $.getJSON('https://localhost:7096/api/GetEngineerSpecialities')
        //$.getJSON('http://alefhome.ddns.net:8082/GetEngineerSpecialities')
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $("#EngineerSpeciality").append($("<option></option>").val(item.id).html(item.speciality));
                });
            });
    });
}

function getManufacturerByID(id) {
    $(document).ready(function () {
        $("#getManufacturerByID").click(function () {
            //clearData();
            $.getJSON('https://localhost:44374/api/GetManufacturerByID/'+id)
            .done (function (responseData) {
                $.each(responseData, function (key, val) {
                    $('<li>', { text: formatManufacturer(val) }).appendTo($('#ShowData'));
                });
                $("#getManufacturerByID").unbind("click");
                $("#getManufacturerIDText").unbind("click");
            });
        });
    });
}

function getManufacturerByDescription(description) {
    $(document).ready(function () {
        $("#getManufacturerByDescription").click(function () {
            //clearData();
            $.getJSON('https://localhost:44374/api/GetManufacturerByDescription/' + description)
                .done(function (responseData) {
                    $.each(responseData, function (key, val) {
                        $('<li>', { text: formatManufacturer(val) }).appendTo($('#ShowData'));
                    });
                    $("#getManufacturerByDescription").unbind("click");
                    $("#getManufacturerDescriptionText").unbind("click");
                });
        });
    });
}

function postManufacturer() {
    $(document).ready(function () {
        // Send an AJAX request
        $("#postManufacturer").click(function () {
            $("#postManufacturer").unbind("click");
            clearData();
            var tempManufacturer = new Object();
            tempManufacturer.ManufacturerName = document.getElementById('postManufacturerDescription').value;
            //var dataJSON = { ManufacturerName: document.getElementById('postManufacturerDescription').value };
            $.ajax({
                type: 'POST',
                url: 'https://localhost:44374/api/PostManufacturer',
                data: JSON.stringify(tempManufacturer),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) { console.log(data) }
            })
        });
    });
}

function formatManufacturer(item) {
    return 'ID: ' + item.ID + ' - Manufacturer: ' + item.ManufacturerName;
}


/* Model */
function getModels() {
        // Send an AJAX request
    $.getJSON('https://localhost:44374/api/GetModels')
        .done(function (data) {
            $("#ShowModels").append($("<option></option>").val(0).html("--Select Model--"));
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                /*$('<li>', { text: formatModel(item) }).appendTo($('#ShowData'));*/
                $("#ShowModels").append($("<option></option>").val(item.ID).html(item.ModelName));
            });
        });
};

function getModelsByButton() {
    $(document).ready(function () {
        // Send an AJAX request
        $("#getModels").click(function () {
            //clearData();
            $.getJSON('https://localhost:44374/api/GetModels')
                .done(function (data) {
                    $("#ShowModelsByButton").append($("<option></option>").val(0).html("--Select Model--"));
                    // On success, 'data' contains a list of products.
                    $.each(data, function (key, item) {
                        // Add a list item for the product.
                        /*$('<li>', { text: formatModel(item) }).appendTo($('#ShowData'));*/
                        $("#ShowModelsByButton").append($("<option></option>").val(item.ID).html(item.ModelName));
                    });
                    $("#getModels").unbind("click");
                });
        });
    });
}

function getModelsByManufacturer(id) {
    // Send an AJAX request
    $.getJSON('https://localhost:44374/api/GetModelByID/' + id)
        .done(function (data) {
            $("#ShowModels").append($("<option></option>").val(0).html("--Select Model--"));
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                /*$('<li>', { text: formatModel(item) }).appendTo($('#ShowData'));*/
                $("#ShowModels").append($("<option></option>").val(item.ID).html(item.ModelName));
            });
            $("#getModels").unbind("click");
        });
}

function getModelByID(id) {
    $(document).ready(function () {
        $("#getModelByID").click(function () {
            //clearData();
            $.getJSON('https://localhost:44374/api/GetModelByID/' + id)
                .done(function (responseData) {
                    $.each(responseData, function (key, val) {
                        $('<li>', { text: formatModel(val) }).appendTo($('#ShowModelByID'));
                    });
                    $("#getModelByID").unbind("click");
                    $("#getModelIDText").unbind("click");
                    //id = 0;
                });
        });
    });
}

function getModelByDescription(description) {
    $(document).ready(function () {
        $("#getModelByDescription").click(function () {
            //clearData();
            $.getJSON('https://localhost:44374/api/GetModelByDescription/' + description)
                .done(function (responseData) {
                    $.each(responseData, function (key, val) {
                        $('<li>', { text: formatModel(val) }).appendTo($('#ShowModelByID'));
                    });
                    $("#getModelByDescription").unbind("click");
                    $("#getModelDescriptionText").unbind("click");
                });
        });
    });
}

function postModel() {
    $(document).ready(function () {
        // Send an AJAX request
        $("#postModel").click(function () {
            $("#postModel").unbind("click");
            clearData();
            var tempModel = new Object();
            tempModel.ModelName = document.getElementById('postModelDescription').value;
            //var dataJSON = { ModelName: document.getElementById('postModelDescription').value };
            $.ajax({
                type: 'POST',
                url: 'https://localhost:44374/api/PostModel',
                data: JSON.stringify(tempModel),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) { console.log(data) }
            })
        });
    });
}

function formatModel(item) {
    return 'ID: ' + item.ID + ' - Model: ' + item.ModelName;
}


/* ModelYear */
function getYears() {
    // Send an AJAX request
    $.getJSON('https://localhost:44374/api/GetModelYears')
        .done(function (data) {
            $("#ShowYears").append($("<option></option>").val(0).html("--Select Year--"));
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $("#ShowYears").append($("<option></option>").val(item.ID).html(item.Description));
            });
    });
}

function getYearsByButton() {
    $(document).ready(function () {
        // Send an AJAX request
        $.getJSON('https://localhost:44374/api/GetModelYears')
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $("#ShowYearsByButton").append($("<option></option>").val(item.ID).html(item.Description));
                });
            });
    });
}

function getYearByID(id) {
    $(document).ready(function () {
        $("#getYearByID").click(function () {
            //clearData();
            $.getJSON('https://localhost:44374/api/GetModelYear/' + id)
                .done(function (responseData) {
                    $.each(responseData, function (key, val) {
                        $('<li>', { text: formatModelYear(val) }).appendTo($('#ShowData'));
                    });
                    $("#getYearByID").unbind("click");
                    $("#getYearIDText").unbind("click");
                });
        });
    });
}

function getYearByDescription(description) {
    $(document).ready(function () {
        $("#getYearByDescription").click(function () {
            //clearData();
            $.getJSON('https://localhost:44374/api/GetYearByDescription/' + description)
                .done(function (responseData) {
                    $.each(responseData, function (key, val) {
                        $('<li>', { text: formatModelYear(val) }).appendTo($('#ShowData'));
                    });
                    $("#getYearByDescription").unbind("click");
                    $("#getYearDescriptionText").unbind("click");
                });
        });
    });
}

function postYear() {
    $(document).ready(function () {
        // Send an AJAX request
        $("#postYear").click(function () {
            $("#postYear").unbind("click");
            const container = document.getElementById('postYear');
            container.replaceChildren();
            var tempYear = new Object();
            tempYear.Description = document.getElementById('postYearDescription').value;
            //var dataJSON = { Description: document.getElementById('postYearDescription').value };
            $.ajax({
                type: 'POST',
                url: 'https://localhost:44374/api/PostModelYear',
                data: JSON.stringify(tempYear),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) { console.log(data) }
            })
        });
    });
}

function formatModelYear(item) {
    return 'ID: ' + item.ID + ' - Year: ' + item.Description;
}


/* ModelManufacturer */
function getModelManufacturers() {
    $(document).ready(function () {
        // Send an AJAX request
        $("#getModelManufacturer").click(function () {
            clearData();
            $.getJSON('https://localhost:44374/api/GetModelManufacturer')
                .done(function (data) {
                    // On success, 'data' contains a list of products.
                    $.each(data, function (key, item) {
                        // Add a list item for the product.
                        $('<li>', { text: formatModelManufacturer(item) }).appendTo($('#ShowData'));
                    });
                    $("#getModelManufacturer").unbind("click");
                });
        });
    });
}

function getModelManufacturerByID() {
    const container = document.getElementById('ShowModels');
    //container.replaceChildren();
    //$("#ShowModels").append($("<option></option>").val(0).html("--Select Model--"));
    $("#ShowYears").append($("<option></option>").val(0).html("--Select Year--"));
    $.getJSON('https://localhost:44374/api/GetModelManufacturer/' + document.getElementById('ShowManufacturers').value)
        .done(function (responseData) {
            $("#ShowModels").append($("<option></option>").val(0).html("--Select Model--"));
            $.each(responseData, function (key, val) {
                $("#ShowModels").append($("<option></option>").val(val.ID).html(val.ModelName));
            });
        });
    container.replaceChildren();
}

function getModelManufacturerYearByModel() {
    const container = document.getElementById('ShowYears');
    container.replaceChildren();
    $("#ShowYears").append($("<option></option>").val(0).html("--Select Year--"));
    $.getJSON('https://localhost:44374/api/GetModelManufacturerYear/' + document.getElementById('ShowManufacturers').value +'/'+ document.getElementById('ShowModels').value)
        .done(function (responseData) {
            $.each(responseData, function (key, val) {
                $("#ShowYears").append($("<option></option>").val(val.ID).html(val.Description));
            });
        });
}

function getModelManufacturerByDescriptionID(manufacturerDescription,modelDescription) {
    $(document).ready(function () {
        $("#getModelManufacturerByDescriptionID").click(function () {
            clearData();
            $.getJSON('https://localhost:44374/api/GetModelManufacturerByDescription/' + manufacturerDescription + '/' + modelDescription)
                .done(function (responseData) {
                    $.each(responseData, function (key, val) {
                        $.getJSON('https://localhost:44374/api/GetManufacturerByDescription/Hyundai')
                            .done(function (responseData) {
                                $.each(responseData, function (key, manufacturer) {
                                    $.getJSON('https://localhost:44374/api/GetModelByID/' + modelDescription)
                                        .done(function (responseData) {
                                            $.each(responseData, function (key, model) {
                                                $.getJSON('https://localhost:44374/api/GetModelYear/' + val.ID)
                                                    .done(function (responseData) {
                                                        $.each(responseData, function (key, val) {
                                                            $('<li>', { text: formatModelManufacturer(manufacturer) + ' - ' + formatModel(model) + ' - ' + formatModelYear(val) }).appendTo($('#ShowData'));
                                                        });
                                                        
                                                    });
                                            });
                                            $("#getModelManufacturerByDescriptionID").unbind("click");
                                            $("#getModelManufacturerDescriptionManufacturerText").unbind("click");
                                            $("#getModelManufacturerDescriptionModelText").unbind("click");
                                        });
                                });
                            });
                    });

                });
        });
    });
}

function getModelManufacturerByDescription(manufacturerDescription, modelDescription) {
    $(document).ready(function () {
        $("#getModelManufacturerByDescription").click(function () {
            clearData();
            $.getJSON('https://localhost:44374/api/GetManufacturerByDescription/' + manufacturerDescription)
                .done(function (responseData) {
                    $.each(responseData, function (key, manufacturer) {
                        $.getJSON('https://localhost:44374/api/GetModelByDescription/' + modelDescription)
                            .done(function (responseData) {
                                $.each(responseData, function (key, model) {
                                    $('<li>', { text: formatModelManufacturer(manufacturer) + ' - ' + formatModel(model) }).appendTo($('#ShowData'));
                                });
                                $("#getModelManufacturerByDescription").unbind("click");
                                $("#getModelManufacturerDescriptionManufacturerText").unbind("click");
                                $("#getModelManufacturerDescriptionModelText").unbind("click");
                            });
                    });
                });
        });
    });
}

function formatModelManufacturer(item) {
    return 'ManufacturerID: ' + item.ID + ' - ManufacturerName: ' + item.ManufacturerName;
}


/* General Functions */
//function clearData() {
//    const container = document.getElementById('ShowData');
//    container.replaceChildren();
//}


function getLogin() {
    $(document).ready(function () {
        // Send an AJAX request
    
        $("#loginButton").click(function () {
        //$("#loginButton").unbind("click");
        $.getJSON('https://localhost:44374/api/GetLogin/' + document.getElementById('loginEmail').value + '/' + document.getElementById('loginPassword').value)
                .done(function (data) {
                    // On success, 'data' contains a list of products.
                    //$.each(data, function (key, item) {
                    //    // Add a list item for the product.
                    //    //$('<li>', { text: formatModelManufacturer(item) }).appendTo($('#ShowData'));
                    //    console.log(item.ID);
                    //});
                    console.log("Successsss!!!!!");
                    $("#loginButton").unbind("click");
                    location.replace("https://localhost:44387/Home/Models")
                });
        });
    });
}