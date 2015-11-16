'use strict';
app.directive('navBar',
    function () {
        return {
            restrict: 'A',
            templateUrl: 'common/nav-bar-directive.html',
            link: function($scope, $location, authData){
                $scope.logOut = function () {
                    authData.logOut();
                    $location.path('/home-page');
                };

                $scope.authentication = authData.authentication;
            }
        }
    });

