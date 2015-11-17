'use strict';
app.factory('imageData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Images/';
        var imageData = {};

        function getAll() {
            return data.get(baseUrl);
        }

        function getById(id) {
            return data.get(baseUrl + id);
        }

        function upload(image) {
            return data.post(baseUrl, image)
        }

        imageData.getAll = getAll;
        imageData.getById = getById;
        imageData.upload = upload;

        return imageData;
    }]);
