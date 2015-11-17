'use strict';
app.controller('imageController', ['$scope', 'imageData', 'authData',
    function ($scope, imageData, authData) {
        $scope.file = {};

        $scope.uploadFiles = function () {

            var file = angular.copy($scope.file);

            var uploadFile = {
                data: file.base64,
                extension: file.filetype,
                fileName: file.filename,
                userId: authData.authentication.userId
            };

            imageData.upload(uploadFile)
                .then(function (res) {
                    console.log(res);
                });
        };
    }]);
