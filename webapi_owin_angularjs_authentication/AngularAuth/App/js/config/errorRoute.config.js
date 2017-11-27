angular.module('app').config(function ($routeProvider) {
    $routeProvider
        .when('/error/notfound', {
            templateUrl: 'app/views/error/notfound.html'
        })
        .when('/error/unauthorized', {
            templateUrl: 'app/views/conta/login.html',
            controller: 'contaController'
        })
        .when('/error/errorsystem', {
            templateUrl: 'app/views/error/errorsystem.html'
        });

});