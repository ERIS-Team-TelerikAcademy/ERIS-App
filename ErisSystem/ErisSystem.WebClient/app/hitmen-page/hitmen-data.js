'use strict';
app.factory('hitmenData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Hitmen';
        var hitmenData = {};

        function getAll(){
            return data.get(baseUrl + '/all')
        }

        hitmenData.getAll = getAll;

        return hitmenData;
    }]);
