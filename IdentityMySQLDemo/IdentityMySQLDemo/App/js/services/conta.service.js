angular.module('app').service('contaServices', function contaServices($http) {

    urlLocal = urlBase + 'account/';

    this.logar = function (conta) {

        var _data = "grant_type=password&username=" +
            conta.username + "&password=" + conta.password;

        return $http.post(
                window.location.origin + '/token',
                _data, {headers:{ 'Content-Type': 'application/x-www-form-urlencoded' }
            });        
    };

    this.registrar = function (conta) {

        return $http({
            method: 'POST',
            url: urlLocal + 'register',
            data: conta
        });
    };
});