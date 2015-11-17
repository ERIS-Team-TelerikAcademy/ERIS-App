'use strict';
app.controller('signupController', ['$scope', '$location',
    '$timeout', 'authData', function ($scope, $location, $timeout, authData) {

        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.registration = {
            email: "",
            password: "",
            confirmPassword: "",
            username: ""
        };

        $scope.signUp = function () {

            authData.saveRegistration($scope.registration)
                .then(function (response) {
                    $scope.savedSuccessfully = true;
                    $scope.message = 'User has been registered successfully,' +
                        'you will be redirected to login page in 2 seconds.';
                    startTimer();
                },
                function (response) {
                    var errors = [];
                    for (var key in response.data.modelState) {
                        for (var i = 0; i < response.data.modelState[key].length; i++) {
                            errors.push(response.data.modelState[key][i]);
                        }
                    }
                    $scope.message = "Failed to register user due to:" + errors.join(' ');
                });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/login');
            }, 2000);
        }

    }]);
