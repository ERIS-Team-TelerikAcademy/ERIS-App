'use strict';
app.factory('ratingData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Ratings/';
        var ratingData = {};

        function postRating(postData) {
            return data.post(baseUrl + 'rate', postData);
        }

        ratingData.post = postRating;

        return ratingData ;
    }]);
