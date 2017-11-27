angular.module('app').config(function ($routeProvider) {

    $routeProvider
        .when('/login', {
            templateUrl: 'app/views/conta/login.html',
            controller: 'contaController'
        });
});