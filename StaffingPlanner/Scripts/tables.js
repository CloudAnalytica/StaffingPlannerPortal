$(document).ready(function () {
    var clientData = [];
    var subbusinessData = [];
    var id, name, subbusiness;
    var nameflag, subBusinessflag = 0;
    ///* Get the reports data and turn it into a JSON */
    //$.ajax({
    //    type: "GET",
    //    url: "ReportsData",
    //    contentType: "application/json;charset=utf-8",
    //    dataType: "json",
    //}).done(function (data) {
    //    $.each(data, function (k, v) {
    //        $.each(v, function (k2, v2) {
    //            $.each(v2, function (k3, v3) {
    //                if (k3 == 'ProjectValue' && v3) {
    //                    v3 = v3.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    //                }

    //            });
    //        });
    //    });
    //    console.log("successfully loaded the reports data");
    //}).fail(function () {
    //    console.log('Failed to load data.');
    //}).always(function () {
    //    console.log('ajax call complete');
    //});

    /* Get the data and turn it into a JSON */
    $.ajax({
        type: "GET",
        url: "ClientData",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        $.each(data, function (k, v) {
            $.each(v, function (k2, v2) { /* push data objects onto global arrays */
                if (k2 == 'Id') { id = v2 }
                else if (k2 == 'Name') { name = v2 }
                else if (k2 == 'SubBusiness') { subbusiness = v2 }
                else { console.log('Unexpected event in clientdata loop.') }
            })

            for (var i = 0; i < clientData.length; i++) { /* if unique client name, then push it */ 
                if (name == clientData[i][1] & nameflag == 0) { nameflag = 1; }
            }
            if (nameflag == 0) { clientData.push([id, name]); }
                    


            for (var i = 0; i < subbusinessData.length; i++) { /* if unique sub-business and not null value, push it */
                if (subbusiness == subbusinessData[i] & subbusinessflag == 0) { subBusinessflag = 1 }
            }
            if (subBusinessflag == 0 & subbusiness !== null) { subbusinessData.push(subbusiness); }
                
            /* reset the flags */
            nameflag = 0;
            subbusinessflag = 0;

            
            
        });
       
        console.log("successfully loaded the client data");
    }).fail(function () {
        console.log('Failed to load data.');
        }).always(function () {
            table.MakeCellsEditable({
                "onUpdate": myCallbackFunction,
                "inputCss": 'my-input-class',
                "allowNulls": {
                    "columns": [],
                    "errorClass": 'error'
                },
                "inputTypes": [ /* build JSON to put here */
                    {
                        "column": 0,
                        "type": "list",
                        "options": [
                            { "value": clientData[0][0], "display": clientData[0][1] },
                            { "value": clientData[1][0], "display": clientData[1][1] },
                            { "value": clientData[2][0], "display": clientData[2][1] },
                            { "value": clientData[3][0], "display": clientData[3][1] },
                            { "value": clientData[4][0], "display": clientData[4][1] },
                            { "value": clientData[5][0], "display": clientData[5][1] },
                            { "value": clientData[6][0], "display": clientData[6][1] },
                            { "value": clientData[7][0], "display": clientData[7][1] },
                            { "value": clientData[8][0], "display": clientData[8][1] },
                            { "value": clientData[9][0], "display": clientData[9][1] },
                        ]
                    },
                    {
                        "column": 1,
                        "type": "list",
                        "options": [
                            { "value": "0", "display": subbusinessData[0] },
                            { "value": "0", "display": subbusinessData[1] },
                            { "value": 0, "display": subbusinessData[2] },
                            { "value": 0, "display": subbusinessData[3] },
                            { "value": 0, "display": subbusinessData[4] },
                            { "value": 0, "display": subbusinessData[5] },
                            { "value": 0, "display": subbusinessData[6] },
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
            {
                data: "RateCardHr",
                render: function (data) {
                    return '$' + data.toString();
                },
            },
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


    
});