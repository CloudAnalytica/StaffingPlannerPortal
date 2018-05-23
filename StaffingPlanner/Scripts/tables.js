$(document).ready(function () {

    /* Get the data and turn it into a JSON */
    $.ajax({
        type: "GET",
        url: "ReportsData",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        $.each(data, function (k, v) {
            $.each(v, function (k2, v2) {
                $.each(v2, function (k3, v3) {
                    if (k3 == 'ProjectValue' && v3) {
                        v3 = v3.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");

                    }

                });
            });
        });
        console.log("successfully loaded the data");
    }).fail(function () {
        console.log('Failed to load data.');
    }).always(function () {
        console.log('ajax call complete');
    });



    /* Load the data table */
    var table = $('#example').DataTable({
        "scrollY": "55vh",
        "scrollX": true,
        "scrollCollapse": true,
        "ajax": "reportsData",
        "columns": [
            {
                data: "Account"
            },
            { data: "Subbusiness" },
            { data: "ProjectName" },
            { data: "Sponsor" },
            {
                data: "ProjectValue",
                render: function (data) {
                    if (data !== null) { /* adds a dollar sign and converts to million or thousand */
                        if (data >= 1000000) {
                            var temp = data / 1000000;
                            return '$' + temp.toString() + 'm';
                        }
                        else {
                            var temp = data / 1000;
                            return '$' + temp.toString() + 'k';
                        }

                    }
                    else {
                        return 'null';
                    }
                }
            },
            { data: "Skillset" },
            { data: "ProjectType" },
            { data: "ProjectStatus" },
            { data: "RateCardHr" },
            { data: "Practice" },
            { data: "MaxTargetGrade" },
            { data: "TargetConsultant" },
            { data: "WorkLocation" },
            {
                data: "StartDate",
                render: function (data) { /* truncates the time */
                    if (data !== null) {
                        var index = data.toString().indexOf(" ");
                        return data.toString().substring(0, index);
                    }
                }
            },
            { data: "Duration" },
            { data: "Priority" },
            { data: "NumberOfRoles" },
            { data: "AccountExecutive" },
            {
                data: "LastEdited",
                render: function (data) { /* truncates the time */
                    if (data !== null) {
                        var index = data.toString().indexOf(" ");
                        return data.toString().substring(0, index);
                    }
                }
            },


        ],
        "createdRow": function (row, data, dataIndex) {
            console.log(data.Account);
            if (data.Account == "GE") {
                console.log('account name');
                $(data).addClass('popover');
                $(data).popover('show');
            }
            $(row).addClass('table-warning');
        },
    });

 
   

    /* toggles visibility of columns */
    $('a.toggle-vis').on('click', function (e) {
        e.preventDefault();

        // Get the column API object
        var column = table.column($(this).attr('data-column'));

        // Toggle the visibility
        column.visible(!column.visible());
    });

    function myCallbackFunction(updatedCell, updatedRow, oldValue) {
        console.log("The old value for the cell is:\t" + oldValue);
        console.log("The new value for the cell is:\t" + updatedCell.data());
        
    }

    table.MakeCellsEditable({
        "onUpdate": myCallbackFunction,
        "inputCss": 'my-input-class',
        "allowNulls": {
            "columns": [],
            "errorClass": 'error'
        },
        "inputTypes": [
            {
                "column": 0,
                "type": "list",
                "options": [
                    { "value": "1", "display": "GE" },
                    { "value": "2", "display": "P&G" },
                    { "value": "3", "display": "Kroger" }
                ]
            },
            {
                "column": 1,
                "type": "list",
                "options": [
                    { "value": "1", "display": "Power" },
                    { "value": "2", "display": "Oil&Gas" },
                    { "value": "3", "display": "Warehouse" }
                ]
            }
            , {
                "column": 18,
                "type": "datepicker",
                
            }
        ],
        "confirmationButton": {
            "confirmCss": 'my-confirm-class',
            "cancelCss": 'my-cancel-class'
        }
    });

});