var app = angular.module('ErisSystemApp',
    ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "home-page/home.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "identity/signup.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "identity/login.html"
    });

    $routeProvider.when("/contract", {
        controller: "contractController",
        templateUrl: "contract-page/contract-view.html"
    });

    $routeProvider.when("/image", {
        controller: "imageController",
        templateUrl: "images-page/image-view.html"
    });

    $routeProvider.otherwise({redirectTo: "/home"});
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authData', function (authData) {
    authData.fillAuthData();
    console.log(authData);
}]);
