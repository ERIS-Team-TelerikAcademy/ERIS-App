'use strict';
app.controller('hitmenController', ['$scope', '$rootScope', 'hitmenData',
    function ($scope, $rootScope, hitmenData) {

        hitmenData.getAll()
            .then(function(response){
                console.log(response);
                $scope.data = response
            });

        $scope.userId = function(id){
            $rootScope.UserId = id
        };

        $scope.rating = 2;
        $scope.isReadonly = true;
        $scope.rateFunction = function (rating) {

        }
    }]);
