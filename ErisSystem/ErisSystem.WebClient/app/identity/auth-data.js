'use strict';

app.factory('authData', ['$http', '$q', 'localStorageService',
    function ($http, $q, localStorageService) {

        var serviceBase = 'http://erissystem.azurewebsites.net/';

        var authServiceFactory = {};

        var authentication = {
            isAuth: false,
            userName: "",
            userId: ""
        };

        var saveRegistration = function (registration) {

            logOut();

            return $http.post(serviceBase + 'api/account/register', registration,
                {headers: {'Content-Type': 'application/json'}})
                .then(function (response) {
                    return response;
                });
        };

        var login = function (loginData) {

            var data = "grant_type=password&username=" +
                loginData.userName + "&password=" + loginData.password;

            var deferred = $q.defer();

            $http.post(serviceBase + 'token', data,
                {headers: {'Content-Type': 'application/x-www-form-urlencoded'}})
                .success(function (response) {

                    $http.get(serviceBase + 'api/hitmen/' + loginData.userName)
                        .success(function (userResponse) {
                            localStorageService.set('authorizationData',
                                {token: response.access_token, userName: loginData.userName, userId: userResponse.Id});

                            authentication.isAuth = true;
                            authentication.userName = loginData.userName;
                            authentication.userId = userResponse.Id;

                            deferred.resolve(response);
                        })
                        .error(function (error, status) {
                            logOut();
                            deferred.reject(err);
                        });
                }).error(function (err, status) {
                    logOut();
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var logOut = function () {

            localStorageService.remove('authorizationData');

            authentication.isAuth = false;
            authentication.userName = '';
            authentication.userId = '';
        };

        var fillAuthData = function () {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                authentication.isAuth = true;
                authentication.userName = authData.userName;
                authentication.userId = authData.userId;
            }
        };

        authServiceFactory.saveRegistration = saveRegistration;
        authServiceFactory.login = login;
        authServiceFactory.logOut = logOut;
        authServiceFactory.fillAuthData = fillAuthData;
        authServiceFactory.authentication = authentication;

        return authServiceFactory;
    }]);
