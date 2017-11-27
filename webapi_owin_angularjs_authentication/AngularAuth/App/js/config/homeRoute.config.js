angular.module('app').config(function ($routeProvider) {
    $routeProvider
        .when('/home', {
            templateUrl: 'app/views/home/home.html',
            controller: 'homeController'
        })
        .otherwise({
            redirectTo: '/home'
        });

});