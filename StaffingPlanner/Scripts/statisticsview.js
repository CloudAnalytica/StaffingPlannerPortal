$(document).ready(function () {
	var lostOppChartData;
	var oppStatusChartData;
	var portfolioChartData;
	var profitChartData;

	google.charts.load('current', { 'packages': ['corechart'] });

	$.ajax({
		type: "GET",
		url: "Statistics/OpportunityStatusChartData",
		contentType: "application/json;charset=utf-8",
		dataType: "json",
		success: function (data) {
			oppStatusChartData = data;
		},
		error: function () {
			alert("Error loading data! Please try again.");
		}
	}).done(function () {
		google.charts.setOnLoadCallback(drawOppStatusChart);
	});

	function drawOppStatusChart() {
		var oppStatusData = new google.visualization.DataTable();
		oppStatusData.addColumn("string", oppStatusChartData[0][0]);
		oppStatusData.addColumn("number", oppStatusChartData[0][1]);
		for (var i = 1; i < oppStatusChartData.length; i++) {
			oppStatusData.addRow([oppStatusChartData[i][0], oppStatusChartData[i][1]]);
		}
		var options = {
			'title': 'Opportunity Status',
			'width': 400,
			'height': 300
		};
		var pieChart = new google.visualization.ColumnChart(document.getElementById('oppStatus_div'));
		pieChart.draw(oppStatusData, options);
	}

	$.ajax({
		type: "GET",
		url: "Statistics/LostOpportunityChartData",
		contentType: "application/json;charset=utf-8",
		dataType: "json",
		success: function (data) {
			lostOppChartData = data;
		},
		error: function () {
			alert("Error loading data! Please try again.");
		}
	}).done(function () {
		google.charts.setOnLoadCallback(drawLostOppChart);
	});

	function drawLostOppChart() {
		var lostOppData = new google.visualization.DataTable();
		lostOppData.addColumn("string", lostOppChartData[0][0]);
		lostOppData.addColumn("number", lostOppChartData[0][1]);
		for (var i = 1; i < lostOppChartData.length; i++) {
			lostOppData.addRow([lostOppChartData[i][0], lostOppChartData[i][1]]);
		}
		var options = {
			'title': 'Lost Opportunities',
			'width': 400,
			'height': 300,
			'pieHole' : 0.4
		};
		var pieChart = new google.visualization.PieChart(document.getElementById('lostOpp_div'));
		pieChart.draw(lostOppData, options);
	}

	$.ajax({
		type: "GET",
		url: "Statistics/PortfolioChartData",
		contentType: "application/json;charset=utf-8",
		dataType: "json",
		success: function (data) {
			portfolioChartData = data;
		},
		error: function () {
			alert("Error loading data! Please try again.");
		}
	}).done(function () {
		google.charts.setOnLoadCallback(drawPortfolioChart);
	});

	function drawPortfolioChart() {
		var portfolioData = new google.visualization.DataTable();
		portfolioData.addColumn("string", portfolioChartData[0][0]);
		portfolioData.addColumn("number", portfolioChartData[0][1]);
		for (var i = 1; i < portfolioChartData.length; i++) {
			portfolioData.addRow([portfolioChartData[i][0], portfolioChartData[i][1]]);
		}
		var options = {
			'title': 'Portfolio',
			'width': 400,
			'height': 300,
			'pieHole': 0.4
		};
		var pieChart = new google.visualization.PieChart(document.getElementById('portfolio_div'));
		pieChart.draw(portfolioData, options);
	}

	$.ajax({
		type: "GET",
		url: "Statistics/ProfitChartData",
		contentType: "application/json;charset=utf-8",
		dataType: "json",
		success: function (data) {
			profitChartData = data;
		},
		error: function () {
			alert("Error loading data! Please try again.");
		}
	}).done(function () {
		google.charts.setOnLoadCallback(drawProfitChart);
	});

	function drawProfitChart() {
		var profitData = new google.visualization.DataTable();
		profitData.addColumn("string", profitChartData[0][0]);
		profitData.addColumn("number", profitChartData[0][1]);
		for (var i = 1; i < profitChartData.length; i++) {
			profitData.addRow([profitChartData[i][0], profitChartData[i][1]]);
		}
		var options = {
			'title': 'Earnings in Millions',
			'width': 400,
			'height': 300
		};
		var lineChart = new google.visualization.LineChart(document.getElementById('profits_div'));
		lineChart.draw(profitData, options);
	}
});