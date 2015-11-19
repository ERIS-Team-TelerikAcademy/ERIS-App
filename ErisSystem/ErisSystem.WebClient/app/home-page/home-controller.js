'use strict';
app.controller('homeController', ['$scope','authData', function ($scope, $authData) {
    $scope.data = $authData.authentication.userId;

}]);
