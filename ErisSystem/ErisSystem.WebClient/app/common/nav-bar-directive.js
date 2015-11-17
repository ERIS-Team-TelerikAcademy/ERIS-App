'use strict';
app.directive('navBar',[ '$rootScope', '$location', 'authData',
    function ($scope, $location, authData) {
        return {
            restrict: 'A',
            templateUrl: 'common/nav-bar-directive.html',
            link: function(){
                $scope.logOut = function () {
                    authData.logOut();
                    $location.path('/home');
                };

                $scope.authentication = authData.authentication;
            }
        }
    }]);

