$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "reports/ReportsData",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            reportsData = data;
        },
        error: function () {
            console.log("Error loading data! Please try again.");
        }
    }).done(function () {
        console.log("successfully loaded the data");
        });

    var table = $('#example').DataTable({
        
        
        "scrollY": "55vh",
        "scrollX": true,
            "scrollCollapse": true,
    });




    $('a.toggle-vis').on('click', function (e) {
        e.preventDefault();

        // Get the column API object
        var column = table.column($(this).attr('data-column'));

        // Toggle the visibility
        column.visible(!column.visible());
    });
});