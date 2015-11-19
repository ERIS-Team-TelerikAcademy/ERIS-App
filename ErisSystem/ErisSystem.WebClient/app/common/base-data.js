'use strict';

app.factory('data', ['$http', '$q',
    function ($http, $q) {
        var serverPath = 'http://erissystem.azurewebsites.net/';
        var odataServerPath = '';
        var header = {headers: {'Content-Type': 'application/json'}};
        var data = {};

        function get(url, options) {
         //   var headers = options.headers || header;
            var deferred = $q.defer();

            var URL = serverPath + url;

            $http.get(URL, header)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        }

        function getOdata(url, options) {
            var deferred = $q.defer();
            var URL = odataServerPath + url;
          //  var headers = options.headers || header;

            $http.get(URL, header)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        }

        function post(url, data, options) {
            var deferred = $q.defer();

            var URL = serverPath + url;
          //  var headers = options.headers || header;

            $http.post(URL, data, header)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        }

        data.get = get;
        data.getOdata = getOdata;
        data.post = post;

        return data;
    }]);
