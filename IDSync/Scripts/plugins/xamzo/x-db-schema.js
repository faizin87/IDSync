
function checkSchemaAppToAD() {
    var columName2 = [];
    var dataType2 = [];
    var columName3 = [];
    var dataType3 = [];

    $('#sortable3 li').each(function (i, val) {
        var phrase = '';
        var current = $(this);
        phrase = current.text().split(' ');
        columName3.push(phrase[0]);
        dataType3.push(phrase[1]);
    });

    $('#sortable2 ul').each(function (i, val) {
        var phrase = '';
        var current = $(this);
        phrase = current.text().split(' ');
        columName2.push(phrase[0]);
        dataType2.push(phrase[1]);
    });

    var successMessage = "<p class='alert alert-info'>Congratulations, your schema define is accepted!</p>";
    var errorMessage = "";
    var strLength = "";
    jQuery.each(columName2, function (i, val) {
        if (columName2[i] != "") {
            if (columName3[i] != "EmployeeID") {
                if (dataType2[i] != dataType3[i]) {
                    errorMessage += "<p class='alert alert-warning'> Data type does'n macth, between <b>" + columName2[i] + "</b> and <b>" + columName3[i] + "</b></p>";
                }
            } 
        }
        strLength += columName2[i];
    });

    if (errorMessage != "") {
        o_str_ = '<div class="modal-header">' +
                '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Error</h4>' +
                '</div>' +
                '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + errorMessage + c_str_, 'true', '300px');
    } else if (strLength == "") {
        o_str_ = '<div class="modal-header">' +
                '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Error</h4>' +
                '</div>' +
                '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + "<p class='alert alert-warning'> Please fill the schema!</p>" + c_str_, 'true', '300px');
    }
    else if ($('ul#employeId_').text() == "") {
        o_str_ = '<div class="modal-header">' +
               '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
               '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Error</h4>' +
               '</div>' +
               '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + "<p class='alert alert-warning'> Employee field must be fill!</p>" + c_str_, 'true', '300px');
    } 
    else if ($('ul#firstName_').text() == "") {
        o_str_ = '<div class="modal-header">' +
               '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
               '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Error</h4>' +
               '</div>' +
               '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + "<p class='alert alert-warning'> Firstname field must be fill!</p>" + c_str_, 'true', '300px');
    } else {
        o_str_ = '<div class="modal-header">' +
                '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Success</h4>' +
                '</div>' +
                '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + successMessage + c_str_, 'true', '300px');
    }

}

function testSchemaAppToAD() {
    var columName2 = [];
    var dataType2 = [];
    var columName3 = [];
    var dataType3 = [];

    $('#sortable3 li').each(function (i, val) {
        var phrase = '';
        var current = $(this);
        phrase = current.text().split(' ');
        columName3.push(phrase[0]);
        dataType3.push(phrase[1]);
    });

    $('#sortable2 ul').each(function (i, val) {
        var phrase = '';
        var current = $(this);
        phrase = current.text().split(' ');
        columName2.push(phrase[0]);
        dataType2.push(phrase[1]);
    });

    var errorMessage = "";
    var strLength = "";
    jQuery.each(columName2, function (i, val) {
        if (columName2[i] != "") {
            if (columName3[i] != "EmployeeID") {
                if (dataType2[i] != dataType3[i]) {
                    errorMessage += "-";
                }
            }
        }
        strLength += columName2[i];
    });

    if (errorMessage != "") {
        return false;
    } else if (strLength == "") {
        return false;
    }
    else if ($('ul#employeId_').text() == "") {
        return false;
    }
    else if ($('ul#firstName_').text() == "") {
        return false;
    }
    else {
        return true;
    }

}

function saveSchemaAppToAD(t) {
    if (testSchemaAppToAD() == true) {
        var columName2 = [];
        var dataType2 = [];
        var columName3 = [];
        var dataType3 = [];

        $('#sortable3 li').each(function (i, val) {
            var phrase = '';
            var current = $(this);
            phrase = current.text().split(' ');
            columName3.push(phrase[0]);
            dataType3.push(phrase[1]);
        });

        $('#sortable2 ul').each(function (i, val) {
            var phrase = '';
            var current = $(this);
            phrase = current.text().split(' ');
            columName2.push(phrase[0]);
            dataType2.push(phrase[1]);
        });
        var from = "#query-form";
        var target = $(t);
        var schema_id = $(from).find('input[name="schema_id"]').val();
        var id = $(from).find('input[name="id"]').val();
        var query_in = editor.getValue();
        var schema_in = "";
        var data_type = "";

        jQuery.each(columName2, function (i, val) {
            if (i == 0) {
                schema_in += columName2[i] + "," + columName3[i];
                data_type += dataType2[i] + "," + dataType3[i];
            } else {
                schema_in += "#" + columName2[i] + "," + columName3[i];
                data_type += "#" + dataType2[i] + "," + dataType3[i];
            }
        });
        var data_;
        if (id == "") {
            data_ = "schema_id=" + schema_id + "&schema_in=" + schema_in + "&data_type=" + data_type + "&query_in=" + query_in;
        } else { 
            data_ = "id=" + id + "&schema_id=" + schema_id + "&schema_in=" + schema_in + "&data_type=" + data_type + "&query_in=" + query_in;
        }
            $.ajax({
                beforeSend: function () {
                    $(target).html('executing ...'); 
                },
                type: "POST",
                data: data_,
                url: "/Apps/SaveSchemaIn/",
                success: function (rs) { 
                    $(target).html('Save Schema');
                    var successMessage = "<p class='alert alert-info'>Your schema define is saved!</p>";
                    o_str_ = '<div class="modal-header">' +
                            '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                            '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Success</h4>' +
                            '</div>' +
                            '<div class="modal-body"> ';
                    c_str_ = ' </div>';
                    return_modalbox(o_str_ + successMessage + c_str_, 'true', '300px');
                }
            }); 

    } else {
        checkSchemaAppToAD();
    }
}

function checkSchemaADToApp() {
    var columName5 = [];
    var dataType5 = [];
    var columName6 = [];
    var dataType6 = [];

    $('#sortable6 li').each(function (i, val) {
        var phrase = '';
        var current = $(this);
        phrase = current.text().split(' ');
        columName6.push(phrase[0]);
        dataType6.push(phrase[1]);
    });

    $('#sortable5 ul').each(function (i, val) {
        var phrase = '';
        var current = $(this);
        phrase = current.text().split(' ');
        columName5.push(phrase[0]);
        dataType5.push(phrase[1]);
    });

    var successMessage = "<p class='alert alert-info'>Congratulations, your schema define is accepted!</p>";
    var errorMessage = "";
    var strLength = "";
    jQuery.each(columName5, function (i, val) {
        if (columName5[i] != "") {
            if (columName5[i] != "EmployeeID") {
                if (dataType5[i] != dataType6[i]) {
                    errorMessage += "<p class='alert alert-warning'> Data type does'n macth, between <b>" + columName5[i] + "</b> and <b>" + columName6[i] + "</b></p>";
                }
            }
        }
        strLength += columName5[i];
    });

    if (errorMessage != "") {
        o_str_ = '<div class="modal-header">' +
                '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Error</h4>' +
                '</div>' +
                '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + errorMessage + c_str_, 'true', '300px');
    } else if (strLength == "") {
        o_str_ = '<div class="modal-header">' +
                '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Error</h4>' +
                '</div>' +
                '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + "<p class='alert alert-warning'> Please fill the schema!</p>" + c_str_, 'true', '300px');
    }
    else if ($('ul#_employeId').text() == "") {
        o_str_ = '<div class="modal-header">' +
               '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
               '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Error</h4>' +
               '</div>' +
               '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + "<p class='alert alert-warning'> Employee field must be fill!</p>" + c_str_, 'true', '300px');
    } else {
        o_str_ = '<div class="modal-header">' +
                '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Success</h4>' +
                '</div>' +
                '<div class="modal-body"> ';
        c_str_ = ' </div>';
        return_modalbox(o_str_ + successMessage + c_str_, 'true', '300px');
    }

}

function testSchemaADToApp() {
    var columName5 = [];
    var dataType5 = [];
    var columName6 = [];
    var dataType6 = [];

    $('#sortable6 li').each(function (i, val) {
        var phrase = '';
        var current = $(this);
        phrase = current.text().split(' ');
        columName6.push(phrase[0]);
        dataType6.push(phrase[1]);
    });

    $('#sortable5 ul').each(function (i, val) {
        var phrase = '';
        var current = $(this);
        phrase = current.text().split(' ');
        columName5.push(phrase[0]);
        dataType5.push(phrase[1]);
    });

    var errorMessage = "";
    var strLength = "";
    jQuery.each(columName5, function (i, val) {
        if (columName5[i] != "") {
            if (columName5[i] != "EmployeeID") {
                if (dataType5[i] != dataType6[i]) {
                    errorMessage += "-";
                }
            }
        }
        strLength += columName5[i];
    });

    if (errorMessage != "") {
        return false;
    } else if (strLength == "") {
        return false;
    }
    else if ($('ul#_employeId').text() == "") {
        return false;
    }
    else {
        return true;
    }

}


function saveSchemaADToApp(t) {
    if (testSchemaADToApp() == true) {
        var columName5 = [];
        var dataType5 = [];
        var columName6 = [];
        var dataType6 = [];

        $('#sortable6 li').each(function (i, val) {
            var phrase = '';
            var current = $(this);
            phrase = current.text().split(' ');
            columName6.push(phrase[0]);
            dataType6.push(phrase[1]);
        });

        $('#sortable5 ul').each(function (i, val) {
            var phrase = '';
            var current = $(this);
            phrase = current.text().split(' ');
            columName5.push(phrase[0]);
            dataType5.push(phrase[1]);
        });
        var from = "#query-form-reverse";
        var target = $(t);
        var schema_id = $(from).find('input[name="schema_id"]').val();
        var id = $(from).find('input[name="id"]').val();
        var table_target = $(from).find('select[name="Tables"]').val();
        var schema_out = "";
        var data_type = "";

        jQuery.each(columName5, function (i, val) {
            if (i == 0) {
                schema_out += columName5[i] + "," + columName6[i];
                data_type += dataType5[i] + "," + dataType6[i];
            } else {
                schema_out += "#" + columName5[i] + "," + columName6[i];
                data_type += "#" + dataType5[i] + "," + dataType6[i];
            }
        });
        var data_ = "";
        if (id == "") {
            data_ = "schema_id=" + schema_id + "&schema_out=" + schema_out + "&data_type=" + data_type + "&table_target=" + table_target;
        } else {
            data_ = "id=" + id + "&schema_id=" + schema_id + "&schema_out=" + schema_out + "&data_type=" + data_type + "&table_target=" + table_target;
        }
        $.ajax({
            beforeSend: function () {
                $(target).html('executing ...');
            },
            type: "POST",
            data: data_,
            url: "/Apps/SaveSchemaOut/",
            success: function (rs) {
                $(target).html('Save Schema');
                var successMessage = "<p class='alert alert-info'>Your schema define is saved!</p>";
                o_str_ = '<div class="modal-header">' +
                        '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                        '<h4 class="modal-title"><i class="fa fa-bullhorn"></i> Success</h4>' +
                        '</div>' +
                        '<div class="modal-body"> ';
                c_str_ = ' </div>';
                return_modalbox(o_str_ + successMessage + c_str_, 'true', '300px');
            }
        });

    } else {
        checkSchemaADToApp();
    }
}