//var url = 'https://localhost:7096/api/'
var url = 'http://alefhome.ddns.net:8082/api/'

function checkDiscountType(x) {
    if(x === 0){
        if (document.getElementById('percentage').checked) {
            $("#discountPrice").hide();
            $("#discountPriceSymbol").hide();
            $("#discountPricePercentage").show();
            $("#discountPricePercentageSymbol").show();
            document.getElementById("discountPricePercentage").placeholder = "0,00";
            setFinalPrice();
            //console.log("checked");
        } else {
            $("#discountPrice").show();
            $("#discountPriceSymbol").show();
            document.getElementById("discountPrice").placeholder = "0,00";
            $("#discountPricePercentage").hide();
            $("#discountPricePercentageSymbol").hide();
            setFinalPrice();
            //console.log("Not checked.");
        }
    }else {
        $("#discountPrice").show();
        $("#discountPriceSymbol").show();
        document.getElementById("discountPrice").placeholder = "0,00";
        $("#discountPricePercentage").hide();
        $("#discountPricePercentageSymbol").hide();
    }
    
}

function setFinalPrice() {
    var finalPrice;
    if (document.getElementById('percentage').checked) {
        console.log("1st");
        finalPrice = (document.getElementById("StartPrice").value.replace(',', '.') - ((document.getElementById("StartPrice").value.replace(',', '.')) * (document.getElementById("discountPricePercentage").value.replace(',', '.') / 100))).toFixed(2);
    } else {
        console.log("2nd");
        finalPrice = (document.getElementById("StartPrice").value.replace(',', '.') - document.getElementById("discountPrice").value.replace(',', '.')).toFixed(2);
    }
    //document.getElementById("FinalPrice").value = finalPrice;
    //console.log("Log: " + document.getElementById("FinalPrice").value);
    document.getElementById("FinalPrice").value = finalPrice.replace('.', ',');
    document.getElementById("StartPrice").value = document.getElementById("StartPrice").value.replace('.', ',');
    console.log("Log: " + document.getElementById("FinalPrice").value);
    console.log("Log: " + document.getElementById("StartPrice").value);
};

function getServiceItems() {
    //console.log("getServiceItems()");
    $(document).ready(function () {
        $.getJSON(url + 'GetServiceItemsToList')
            //$.getJSON('http://alefhome.ddns.net:8082/api/GetCarManufacturersToList')
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    if (item.price > 0) {
                        $("#ServiceItems").append($("<option></option>").val(item.id).html(' '+item.id + ') ' + item.description + ' (' + item.price + ' €)'));
                    } else {
                        $("#ServiceItems").append($("<option></option>").val(item.id).html(' ' +item.id + ') ' + item.description + ' (--)'));
                    }
                });
            });
    });
}

function CalculatePrice() {
    const options = document.getElementById("ServiceItems").options;
    let sum = 0.00;
    for (let i = 0; i < options.length; i++) {
        if (options[i].selected) {
            const str = options[i].text;
            const before_ = str.substring(str.length, str.lastIndexOf('('));
            console.log(before_);
            let res = before_.replace('(', "");
            res = res.replace(')', "");
            res = res.replace('€', "");
            if (res === "--") {
                sum += 0;
            } else {
                sum += parseFloat(res, 10);
            }
        }
    }
    //console.log("Sum is: " + sum);
    document.getElementById("StartPrice").value = sum;
    setFinalPrice();
};

function getServiceEngineers() {
    console.log("getServiceItems()");
    $(document).ready(function () {
        $.getJSON(url + 'GetEngineers/1')
            //$.getJSON('http://alefhome.ddns.net:8082/api/GetCarManufacturersToList')
            .done(function (data) {
                // On success, 'data' contains a list of products.
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $("#ShowEngineers").append($("<option></option>").val(item.id).html(item.surname + ' ' + item.name));
                });
            });
    });
}

/* Manufacturer */
function getManufacturers() {
    $(document).ready(function () {
        // Send an AJAX request
        $("#ShowManufacturers").append($("<option></option>").val(0).html("--Select Manufacturer--"));
        $.getJSON(url+'GetCarManufacturersToList')
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

function getManufacturersForModel(manufacturerID,culture) {
    $(document).ready(function () {
        // Send an AJAX request
        clearDataModels();
        if (culture == 'el-GR') {
            $("#ShowModels").append($("<option></option>").val(0).html("--Επιλογή Μοντέλου--"));
        } else {
            $("#ShowModels").append($("<option></option>").val(0).html("--Select Model--"));
        }
        $.getJSON(url +'GetCarModelManufacturerYearByManufacturerID/' + manufacturerID)
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

function getYearsForModel(modelID,culture) {
    $(document).ready(function () {
        // Send an AJAX request
        clearDataYears();
        if (culture == 'el-GR') {
            $("#ShowYears").append($("<option></option>").val(0).html("--Επιλογή Έτους--"));
        } else {
            $("#ShowYears").append($("<option></option>").val(0).html("--Select Year--"));
        }
        $.getJSON(url +'GetCarModelManufacturerYearByModelID/' + modelID)
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
        $.getJSON(url+'GetEngineers')
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
        $.getJSON(url +'GetEngineerSpecialities')
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


// Grid Sorting
$(document).ready(function () {
    $('th[data-sort]').click(function () {
        var table = $(this).parents('table').eq(0);
        var index = $(this).index();
        var dataType = $(this).data('sort');
        var rows = table.find('tr:gt(0)').toArray().sort(comparer(index, dataType));

        this.asc = !this.asc;
        if (!this.asc) {
            rows = rows.reverse();
        }
        for (var i = 0; i < rows.length; i++) {
            table.append(rows[i]);
        }
    });

    function comparer(index, dataType) {
        return function (a, b) {
            var valA = getCellValue(a, index, dataType),
                valB = getCellValue(b, index, dataType);

            if (index === 0) {
                // Sorting for the "Name" column
                return dataType === 'numeric' ? $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : 0 : valA.localeCompare(valB);
            } else if (index === 7) {
                // Sorting for the "Category" column (assuming it's the fourth column)
                return valA.localeCompare(valB);
            } else {
                // Default sorting for other columns
                return dataType === 'numeric' ? $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : 0 : valA.localeCompare(valB);
            }
        };
    }

    function getCellValue(row, index, dataType) {
        var cellText = $(row).children('td').eq(index).text();
        return dataType === 'numeric' ? parseFloat(cellText) : cellText;
    }
});