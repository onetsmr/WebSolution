'use strict';

app.controller('ApplicationController', ['$scope', '$http', function ($scope, $http) {
    $http.get('api/application/modules').success(function (data) {
        $scope.Modules = data;
    });
}]);