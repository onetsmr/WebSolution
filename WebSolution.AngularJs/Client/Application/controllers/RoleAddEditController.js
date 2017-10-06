'use strict';

app.controller('RoleAddEditController', ['$scope', '$http', '$uibModal', '$uibModalInstance', 'data', function ($scope, $http, $uibModal, $uibModalInstance, data) {
    $http.get('api/roles/' + data.EntityId).success(function (data) {
        $scope.Entity = data;
    });

    $scope.DoneDialog = function () {
        // TODO: send data to server and push result into $uibModalInstance.close
        $uibModalInstance.close($scope.Entity);
    }

    $scope.CloseDialog = function () {
        return $uibModalInstance.dismiss('dismiss');
    }
}]);