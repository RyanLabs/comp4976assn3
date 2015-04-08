var app;

(function () {
    app = angular.module("GoodSamaratin", []);
})();

app.controller("ClientController", function($scope) {
    $scope.testVar = "test variable";
});

app.controller("ReportController", function($scope) {
    $scope.testVar = "test variable";
});

