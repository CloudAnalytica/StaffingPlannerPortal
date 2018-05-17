$(document).ready(function () {
	var chartData;

	google.charts.load('current', { 'packages': ['corechart'] });
	google.charts.setOnLoadCallback(drawLostOpps);

	function drawLostOpps() {
		var data = new google.visualization.DataTable();
		data.addColumn('string', 'Reason');
		data.addColumn('number', 'Count');
		data.addRows([
			['High Bill Rate', 3],
			['Deadline Miss', 1],
			['Recruitment Delays', 4],
			['No Candidate', 1],
			['No Help From Practice', 2]
		]);

		var options = {
			'title': 'Lost Opportunities',
			'position': 'top',
			'width': 400,
			'height': 300
		};

		var chart = new google.visualization.ColumnChart(document.getElementById('lostOpp_div'));
		chart.draw(data, options);
	}

	$.ajax({
		type: "GET",
		url: "Statistics/LostOpportunityChartData",
		contentType: "application/json;charset=utf-8",
		dataType: "json",
		success: function (data) {
			chartData = data;
		},
		error: function () {
			alert("Error loading data! Please try again.");
		}
	}).done(function () {
		google.charts.setOnLoadCallback(drawChart);
	});

	function drawChart() {
		var lostOppData = new google.visualization.DataTable();
		lostOppData.addColumn("string", chartData[0][0]);
		lostOppData.addColumn("number", chartData[0][1]);
		lostOppData.addRow([chartData[1][0], chartData[1][1]]);
		lostOppData.addRow([chartData[2][0], chartData[2][1]]);

		var options = {
			'title': 'Lost Opportunities',
			'width': 400,
			'height': 300
		};
		var pieChart = new google.visualization.PieChart(document.getElementById('second_div'));
		pieChart.draw(lostOppData, options);
	}
});