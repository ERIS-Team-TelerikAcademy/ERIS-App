'use strict';
app.factory('hitmanData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Hitmen/';
        var hitmanData = {};

        function getByUserName(userName){
            return data.get(baseUrl + userName)
        }

        hitmanData.getByUserName = getByUserName;

        return hitmanData;
    }]);

