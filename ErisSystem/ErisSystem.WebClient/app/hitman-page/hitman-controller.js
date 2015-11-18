'use strict';
app.controller('hitmanController', ['$scope', '$routeParams', '$rootScope', 'hitmanData',
    function ($scope, $routeParams, $rootScope, hitmanData) {
        var userName = $routeParams.name;

        hitmanData.getByUserName(userName)
            .then(function (response) {
                $scope.hitman = response;
            })

    }]);