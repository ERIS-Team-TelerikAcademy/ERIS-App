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

  $routeProvider.otherwise({ redirectTo: "/home" });
});

