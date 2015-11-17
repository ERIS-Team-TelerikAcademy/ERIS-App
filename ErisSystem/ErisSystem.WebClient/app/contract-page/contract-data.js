'use strict';

app.factory('contractData', ['$http', '$q', 'data',
    function ($http, $q, data) {
        var baseUrl = 'api/Contracts/';
        var contractData = {};

        function getAll() {
            return data.get(baseUrl + 'all');
        }

        function getById(id) {
            return data.get(baseUrl + id);
        }

        function createContract(postData) {
            return data.post(baseUrl + 'new-contract-page', postData);
        }

        //TODO: http put

        contractData.getAll = getAll;
        contractData.getById = getById;
        contractData.createContract = createContract;

        return contractData;
    }]);