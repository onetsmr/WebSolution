'use strict';

app.controller('UserListViewController', ['$scope', '$http', function ($scope, $http) {
    $http.get('api/users').success(function (data) {
        $scope.Users = data;
    });

    $scope.LogOut = function (data) {
        $http.get('api/users/logout/' + data).success(function (data) {

        });
    }
}]);