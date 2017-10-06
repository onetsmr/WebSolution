'use strict';

var app = angular
    .module('angularJsApp', ['ui.router', 'ui.bootstrap', 'dialogs.main'])
    .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('Dashboard', {
                url: '/',
                templateUrl: 'Client/Application/views/Dashboard.html',
                controller: 'DashboardController'
            })
            // TODO: disallow access if current user has not it
            .state('Roles', {
                url: "/Roles",
                templateUrl: 'Client/Application/views/RoleListView.html',
                controller: 'RoleListViewController'
            })
            .state('Users', {
                url: "/Users",
                templateUrl: 'Client/Application/views/UserListView.html',
                controller: 'UserListViewController'
            })

        $urlRouterProvider.otherwise('/');
    }]);