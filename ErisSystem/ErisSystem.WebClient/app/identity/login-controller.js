'use strict';
app.controller('loginController', ['$scope', '$location', 'authData',
    function ($scope, $location, authData) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {
            authData.login($scope.loginData).then(function (response) {
                    $location.path('/home-page');
                },
                function (err) {
                    console.log(err);
                    console.log(err.message);
                    $scope.message = err.message;
                });
        };

    }]);
