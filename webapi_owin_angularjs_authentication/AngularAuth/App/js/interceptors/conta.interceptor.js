angular.module('app').factory('contaInterceptor', function contaInterceptor() {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            var auth = JSON.parse(localStorage.getItem('AuthorizationData'));
            if (auth) {
                config.headers.Authorization = 'Bearer ' + auth.token;
            }
            return config;

        }
    };
});