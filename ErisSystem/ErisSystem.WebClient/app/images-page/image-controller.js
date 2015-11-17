'use strict';
app.controller('imageController', ['$scope', 'imageData', 'authData',
    function ($scope, imageData, authData) {
        var userId = authData.authentication.userId;
        $scope.file = {};

        $scope.uploadFiles = function () {

            var file = angular.copy($scope.file);

            var uploadFile = {
                data: file.base64,
                extension: file.filetype,
                fileName: file.filename,
                userId:userId
            };

            imageData.upload(uploadFile)
                .then(function (res) {
                    console.log(res);
                });
        };

     $scope.getMyImages =  function (){
           imageData.getById(userId).
               then(function(response) {
                   $scope.data = response.data
               });
       };

         $scope.getImages = function(){
            imageData.getAll().
                then(function(response) {
                    $scope.data = response.data
                });
        }
    }]);
