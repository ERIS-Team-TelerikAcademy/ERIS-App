'use strict';
app.controller('hitmanController', ['$scope', '$routeParams', 'authData', 'hitmanData',
    function ($scope, $routeParams, authData, hitmanData) {
        $scope.userName = $routeParams.name;

        hitmanData.getByUserName($scope.userName)
            .then(function (response) {
                $scope.hitman = response;
                authData.authentication.clientId = response.Id;
            });

        $scope.authentication = authData.authentication;
        $scope.rating = 2;
        $scope.rateFunction = function (rating) {
            return 1;
        };

    }]);