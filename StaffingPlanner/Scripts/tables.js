$(document).ready(function () {

    /* Get the data and turn it into a JSON */
    $.ajax({
        type: "GET",
        url: "ReportsData",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    }).done(function (data) {
            reportsData = JSON.stringify(data);
            console.log("successfully loaded the data");
        console.log(data);
        console.log(reportsData);
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
            { "data": "Account" },
            { "data": "Subbusiness" },
            { "data": "ProjectName" },
            { "data": "Sponsor" },
            { "data": "ProjectValue" },
            { "data": "Skillset" },
            { "data": "ProjectType" },
            { "data": "ProjectStatus" },
            { "data": "RateCardHr" },
            { "data": "Practice" },
            { "data": "MaxTargetGrade" },
            { "data": "TargetConsultant" },
            { "data": "WorkLocation" },
            { "data": "StartDate" },
            { "data": "Duration" },
            { "data": "Priority" },
            { "data": "NumberOfRoles" },
            { "data": "AccountExecutive" },
            { "data": "LastEdited" },

        ]
    });



    /* toggles visibility of columns */
    $('a.toggle-vis').on('click', function (e) {
        e.preventDefault();

        // Get the column API object
        var column = table.column($(this).attr('data-column'));

        // Toggle the visibility
        column.visible(!column.visible());
    });
});