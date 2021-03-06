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
            return data.post(baseUrl + 'new-contract', postData);
        }

        function updateAprovalStatus(postData){
            return data.put(baseUrl + 'approve-contract', postData);
        }

        function getUserNickname(postData){
            return data.get('api/hitmen/byId/' + postData);
        }

        function getAllClients(postData){
            return data.get(baseUrl + 'all-for-client/' + postData);
        }

        function getAllHitmen(postData){
            return data.get(baseUrl + 'all-for-hitman/' + postData);
        }


        contractData.getAll = getAll;
        contractData.getById = getById;
        contractData.createContract = createContract;
        contractData.getUserNickname = getUserNickname;
        contractData.getAllForClient = getAllClients;
        contractData.getAllForHitman = getAllHitmen;
        contractData.put = updateAprovalStatus;

        return contractData;
    }]);
