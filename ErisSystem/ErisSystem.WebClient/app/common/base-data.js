'use strict';
app.factory('data', ['$http', '$q', 'appSettings',
    function ($http, $q, appSettings) {

        var header = {headers: {'Content-Type': 'application/json'}};
        var data = {};

        function request(method, url, data) {
            var deferred = $q.defer();

            var URL = appSettings.serverPath + url;

            $http({
                method: method,
                url: URL,
                data: data,
                headers: header
            })
                .then(function (response) {
                    deferred.resolve(response.data);
                },
                function (err) {
                    deferred.reject(err)
                });

            return deferred.promise;
        }

        function get(url) {
            return request('GET', url);
        }

        function post(url, data) {
            return request('POST', url, data);
        }

        function put(url, data) {
            return request('PUT', url, data);
        }

        function deleteReq(url, data) {
            return request('DELETE', url, data);
        }

        data.get = get;
        data.post = post;
        data.put = put;
        data.delete = deleteReq;

        return data;
    }]);
