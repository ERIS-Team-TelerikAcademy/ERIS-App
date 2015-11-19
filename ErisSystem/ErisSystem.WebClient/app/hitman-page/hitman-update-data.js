'use strict';
app.factory('hitmanUpdateData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Hitmen/';
        var hitmanUpdateData = {};

        function updateInfo(){
            return data.put(baseUrl + 'profile');
        }

        hitmanUpdateData.updateInfo = updateInfo;

        return hitmanUpdateData;
    }]);

