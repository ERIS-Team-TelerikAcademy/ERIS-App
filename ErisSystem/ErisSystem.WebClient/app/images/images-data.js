'use strict';

app.factory('imageData', ['$http', '$q', 'data',
function($http, $q, data){
var baseUrl = 'api/Contracts/'
        var imageData = {};

    function getAll(){
        return data.get(baseUrl + 'all');
    }

    function getById(id) {
        return data.get(baseUrl + id);
    }
}]);
