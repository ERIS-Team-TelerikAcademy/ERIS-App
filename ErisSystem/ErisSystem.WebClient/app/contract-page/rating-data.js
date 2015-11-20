'use strict';
app.factory('ratingData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Ratings/';
        var ratingData = {};

        function createContract(postData) {
            return data.post(baseUrl + 'new-contract', postData);
        }


        ratingData.getById = getById;
        ratingData.createContract = createContract;


        return ratingData;
    }]);