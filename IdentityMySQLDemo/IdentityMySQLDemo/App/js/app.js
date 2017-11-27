var urlBase = window.location.origin + '/api/';

angular.module('app', ['ngRoute']);

angular.module('app').run(function ($rootScope, $route, $location) {

    //para proteger as rotas da aplicação
    $rootScope.$on('$routeChangeSuccess', function (evt, next, current) {
        var estaAutorizado = localStorage.getItem('AuthorizationData');
        if (($route.current.$$route.requireLogin || false) && !estaAutorizado) {
            $location.path('/login');
        }
    });
});