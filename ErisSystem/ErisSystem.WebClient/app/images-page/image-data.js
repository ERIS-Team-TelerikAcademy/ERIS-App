'use strict';

app.factory('imageData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Images/';
        var imageData = {};

        function getAll() {
            return data.get(baseUrl + 'all');
        }

        function getById(id) {
            return data.get(baseUrl + id);
        }

        //TODO: find a way to post image
        //function upload(stream) {
        //    return data.post(baseUrl, stream)
        //}

        imageData.getAll = getAll;
        imageData.getById = getById;

        return imageData;
    }]);
