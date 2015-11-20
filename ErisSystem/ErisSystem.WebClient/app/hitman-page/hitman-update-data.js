'use strict';
app.factory('hitmanUpdateData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Hitmen/';
        var hitmanUpdateData = {};

        function getByUserName(userName){
            return data.get(baseUrl + userName)
        }

        function updateInfo(postData){
            return data.put(baseUrl + 'profile', postData);
        }

        hitmanUpdateData.getByUserName = getByUserName;
        hitmanUpdateData.updateInfo = updateInfo;

        return hitmanUpdateData;
    }]);

