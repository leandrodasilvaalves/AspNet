angular.module('app').factory('errorInterceptor', function errorInterceptor($q, $location) {

    return {
        responseError: function (rejection) {
            if (rejection.status === 404) {
                $location.path("/error/notfound");
            }
            if (rejection.status === 401) {
                $location.path("/login");
            }
            else {
                $location.path("/error/errorsystem");
            }
            return $q.reject(rejection);
        }
    };
});