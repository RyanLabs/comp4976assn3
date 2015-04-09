var app;

(function () {
    app = angular.module("GoodSamaratin", []);
})();

app.controller("ClientController", function($scope) {
});

app.controller("ReportController", function($scope, $http) {
    $scope.hide = true;
    var baseUrl = 'http://localhost:10084/api/ClientAPI/';

    $scope.months = months;
    $scope.years = years;
    $scope.month_field = 'January';
    $scope.year_field = '2015';

    var date = new Date();
    $scope.currentDate = monthNames[date.getMonth()] + " " + date.getDay() + ", " + date.getFullYear();

    $scope.generate = function(month, year) {

        // Send the request
        $http.get(baseUrl + year + '/' + month)
            .success(function(data) {
                console.log("success");
                $scope.populateReport(data);
            })
            .error(function(data) {
                console.log("error: " + data);
            });

        $scope.hide = false;
        console.log("month: " + month + " year: " + year);
    };

    $scope.populateReport = function(data) {
        var report = JSON.parse(data);
        $scope.open = report.Open;
        $scope.closed = report.Closed;
        $scope.reopened = report.Reopened;
        $scope.crisis = report.Crisis;
        $scope.court = report.Court;
        $scope.SMART = report.SMART;
        $scope.DVU = report.DVU;
        $scope.MCFD = report.MCFD;
        $scope.male = report.Male;
        $scope.female = report.Female;
        $scope.trans = report.Trans;
        $scope.adult = report.Adult;
        $scope.youth12 = report.Youth12;
        $scope.youth18 = report.Youth18;
        $scope.senior = report.Senior;
        $scope.child = report.Child;

    };
});

var months = [
    { label: 'January',     value: 1 },
    { label: 'February',    value: 2 },
    { label: 'March',       value: 3 },
    { label: 'April',       value: 4 },
    { label: 'May',         value: 5 },
    { label: 'June',        value: 6 },
    { label: 'July',        value: 7 },
    { label: 'August',      value: 8 },
    { label: 'September',   value: 9 },
    { label: 'October',     value: 10 },
    { label: 'November',    value: 11 },
    { label: 'Decemeber',   value: 12 }
];

var years = [
    { label: '10-11', value: 1 },
    { label: '11-12', value: 2 },
    { label: '12-13', value: 3 },
    { label: '13-14', value: 4 },
    { label: '14-15', value: 5 },
    { label: '15-16', value: 6 },
    { label: '16-17', value: 7 }
];

var monthNames = ["January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December"
];