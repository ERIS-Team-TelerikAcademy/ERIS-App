'use strict';
app.directive('navBar',
    function () {
        return {
            restrict: 'A',
            templateUrl: 'directives/nav-bar.html',
            link: function($scope, $location, authService){
                $scope.logOut = function () {
                    authService.logOut();
                    $location.path('/home');
                };

                $scope.authentication = authService.authentication;
            }
        }
    });

