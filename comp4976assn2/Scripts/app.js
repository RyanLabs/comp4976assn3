var app;

(function () {
    app = angular.module("GoodSamaratin", []);
})();

app.controller("ClientController", function($scope) {
    $scope.testVar = "test variable";
});

app.controller("ReportController", function($scope) {
    $scope.testVar = "test variable";

    $scope.months = months;
    $scope.years = years;
    $scope.month_field = 'January';
    $scope.year_field = '2015';

    $scope.currentDate = new Date();

    $scope.generate = function (month, year) {
        console.log("month: " + month + " year: " + year);
    };

});

var months = [
    { label: 'January', value: 1 },
    { label: 'February', value: 2 },
    { label: 'March', value: 3 },
    { label: 'April', value: 4 },
    { label: 'May', value: 5 },
    { label: 'June', value: 6 },
    { label: 'July', value: 7 },
    { label: 'August', value: 8 },
    { label: 'September', value: 9 },
    { label: 'October', value: 10 },
    { label: 'November', value: 11 },
    { label: 'Decemeber', value: 12 }
];

var years = [
    { label: '2000', value: 2000 },
    { label: '2001', value: 2001 },
    { label: '2002', value: 2002 },
    { label: '2003', value: 2003 },
    { label: '2004', value: 2004 },
    { label: '2005', value: 2005 },
    { label: '2006', value: 2006 },
    { label: '2007', value: 2007 },
    { label: '2008', value: 2008 },
    { label: '2009', value: 2009 },
    { label: '2000', value: 2000 },
    { label: '2011', value: 2011 },
    { label: '2012', value: 2012 },
    { label: '2013', value: 2013 },
    { label: '2014', value: 2014 },
    { label: '2015', value: 2015 },
]