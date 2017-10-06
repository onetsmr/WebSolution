'use strict';

app.controller('RoleListViewController', ['$scope', '$http', 'dialogs', function ($scope, $http, dialogs) {
    $http.get('api/roles').success(function (data) {
        $scope.Roles = data;
    });

    $scope.OpenDialog = function (id) {
        var dlg = dialogs.create(window.location.pathname + 'Client/Application/views/RoleAddEdit.html', 'RoleAddEditController',
            { EntityId: id }, { size: 'lg', backdrop: 'static' });

        dlg.result.then(
            function (data) {
                // After done
                $scope.OpenDialogCompleted(data);
            },
            function (data) {
                // After cancel
            });
    }

    $scope.OpenDialogCompleted = function (data) {
        alert('OpenDialogCompleted: ' + JSON.stringify(data));
    }
}]);