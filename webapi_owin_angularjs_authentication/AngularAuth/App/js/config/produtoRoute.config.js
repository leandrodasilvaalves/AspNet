angular.module('app').config(function ($routeProvider) {
    $routeProvider
        .when('/produto', {
            templateUrl: 'app/views/produto/produto-lista.html',
            controller: 'produtoController',
            requireLogin: true
        })
        .when('/produto/novo', {
            templateUrl: 'app/views/produto/produto-novo.html',
            controller: 'produtoController',
            requireLogin: true
        })
        .when('/produto/editar/:id', {
            templateUrl: 'app/views/produto/produto-editar.html',
            controller: 'produtoController',
            requireLogin: true
        });
});

