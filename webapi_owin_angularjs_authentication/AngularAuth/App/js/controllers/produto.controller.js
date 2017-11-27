angular.module('app').controller('produtoController', function produtoController($scope, $route, $location, produtoServices) {

    //Variaveis
    $scope.todosProdutos = [];
    $scope.produto = {};


    //Metodos privados
    function _listarTodos() {
        var response = produtoServices.listarTodos();
        response.then(function (lista) {
            $scope.todosProdutos = lista.data;
        }, function (err) {
           
        });
    }

    function _incluir(produto) {
        var response = produtoServices.incluir(produto);
        response.then(function (data) {
            $location.path("/produto");
        }, function (err) {
           
        });

    }

    function _editar(produto) {
        var response = produtoServices.editar(produto);
        response.then(function (data) {
            $location.path("/produto");
        }, function (err) {
            
        });

    }

    function _obterProdutoPorId() {
        var id = $route.current.params.id;
        var response = produtoServices.obterPorId(id);
        response.then(function (resp) {
            $scope.produto = resp.data;
        }, function (err) {            
        });
    }

    function _confirmaApagar(produto) {        

        swal({
            title: "Deseja realmente excluir produto: (" + produto.Nome + ") ?",
            text: "ATENÇÃO! Esta operação é irreversível",
            icon: "error",
            buttons: {
                cancel: "Cancelar",
                confirm: "Excluir"
            },
            dangerMode: true,
        })
            .then(function(willDelete){
                if (willDelete) {
                    _apagar(produto.Id);
                }
            });
    }

    function _apagar(id) {
        console.log(id);
        var response = produtoServices.excluir(id);
        response.then(function (resp) {
            console.log(resp);
            _listarTodos();
            swal("Produto excluído com sucesso!", {
                icon: "success",
            });

        }, function (err) {
            
        });       
    }


    //Metodos publicos (escopo)
    $scope.listarTodos = _listarTodos;
    $scope.incluir = _incluir;
    $scope.editar = _editar;
    $scope.obterProdutoPorId = _obterProdutoPorId;
    $scope.confirmaApagar = _confirmaApagar;
});