var app = angular.module('ErisSystemApp',
    ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "views/home.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "views/signup.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "views/login.html"
    });

    $routeProvider.when("/contract", {
        controller: "contractController",
        templateUrl: "contract/contract-view.html"
    });

    $routeProvider.when("/image", {
        controller: "imageController",
        templateUrl: "images/image-view.html"
    });

    $routeProvider.otherwise({redirectTo: "/home"});
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
