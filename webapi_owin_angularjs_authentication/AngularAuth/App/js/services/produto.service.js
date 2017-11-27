angular.module('app').service('produtoServices', function produtoServices($http) {

    urlLocal = urlBase + 'produto';

    this.listarTodos = function () {
        return $http({
            method: 'GET',
            url: urlLocal
        });
    };

    this.incluir = function (produto) {
        return $http({
            method: 'POST',
            url: urlLocal,
            data: produto
        });
    };

    this.editar = function (produto) {
        return $http({
            method: 'PUT',
            url: urlLocal + '?id=' + produto.Id,
            data: produto
        });
    };

    this.obterPorId = function (id) {
        return $http({
            method: 'GET',
            url: urlLocal + '?id=' + id
        });
    };

    this.excluir = function (id) {
        return $http({
            method: 'DELETE',
            url: urlLocal + '?id=' + id
        });
    };


});