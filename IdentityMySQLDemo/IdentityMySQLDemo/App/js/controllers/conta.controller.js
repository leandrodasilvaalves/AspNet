angular.module('app').controller('contaController', function contaController($scope, $location, contaServices) {

    //Variaveis
    $scope.conta = {};
    $scope.conta.username = "leandro@gmail.com";
    $scope.conta.password = "Le.126986";
        
    //Metodos privados
    function _verificaAutenticao() {
        var conta = JSON.parse(localStorage.getItem('AuthorizationData'));
        if (conta) {
            $scope.autenticacao = { isAuth: true, username: conta.username };
        }       
    }

    function _entrar (conta) {
        var response = contaServices.logar(conta);
        response.then(function (resp) {
            var _token = resp.data.access_token;
            localStorage.setItem('AuthorizationData', JSON.stringify({ username: conta.username, token: _token })); 
            $location.path('/home');
            angular.element(document.getElementById('navUser')).scope().verificaAutenticao();
            //o 'contaController' foi utilizado em duas views (/conta/login.html e /shared/nav.html)
            //por isso possuem scopes distintos que podem ser verificado atraves de $id
            //por tal motivo utilizei esta chamada diretamente do angular
        });
    }

    function _registrar(conta) {       
        var response = contaServices.registrar(conta);
        response.then(function (resp) {
            _entrar({ username: conta.email, password: conta.password });
        });
    }

    function _sair() {
        localStorage.removeItem('AuthorizationData');
        $scope.autenticacao = {};
        $location.path('/home');
    }

    //Metodos publicos (escopo);
    $scope.verificaAutenticao = _verificaAutenticao;
    $scope.entrar = _entrar;
    $scope.registrar = _registrar;
    $scope.sair = _sair;

});