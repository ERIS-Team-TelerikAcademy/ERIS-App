'use strict';
app.controller('contractController', ['$scope', 'contractData', 'authData', function ($scope, contractData, authData) {

    var activeContractsContainer = $('#activeContracts');
    var pendingContractsContainer = $('#pendingContracts');
    var dataForHitman = [];
    var dataForClient = [];
    var userNames = [];
    var userId = authData.authentication.userId;
    contractData
        .getAllForHitman(userId)
        .then(function (data) {
            var i = 0;
            var j = 0;
            for (i = 0; i < data.length; i += 1) {
                var currentContract = data[i];
                contractData.getUserNickname(currentContract.ClientId)
                    .then(function (userData) {
                        userNames[j] = userData.UserName;
                        j++;
                        return data;

                    }).then(function (data) {
                        for (var i = 0; i < data.length; i += 1) {
                            var currentContract = data[i];
                            dataForHitman[i] = {
                                UserName: userNames[i],
                                DeadLine: currentContract.Deadline,
                                Status: currentContract.Status,
                                ContractId: currentContract.Id,
                                ClientId: currentContract.ClientId
                            }
                        }
                    })
            }

        });

    contractData
        .getAllForClient(userId)
        .then(function (data) {
            var i = 0;
            var j = 0;
            for (i = 0; i < data.length; i += 1) {
                var currentContract = data[i];
                contractData.getUserNickname(currentContract.ClientId)
                    .then(function (userData) {
                        userNames[j] = userData.UserName;
                        j++;
                        return data;

                    }).then(function (data) {
                        for (var i = 0; i < data.length; i += 1) {
                            var currentContract = data[i];
                            dataForClient[i] = {
                                UserName: userNames[i],
                                DeadLine: currentContract.Deadline,
                                Status: currentContract.Status
                            }
                        }
                    })
            }

        });

    $scope.dataForClient = dataForClient;
    $scope.dataForHitman = dataForHitman;


    $('body').on('click', '.userSelectionButton', function (e) {
        var a = $(e.target);
        var contract  = a.attr('data').split(' ');
        alert('ContractId: ' + contract[0] + ' ApprovalStatus:' + contract[1] + ' ClinetId: ' + contract[2]);
        //Put - get contract id from button data attribute
        //{
         //   "id": 1,
          //  "HitmanId": "66e9bbe8-8e74-41b9-b09d-361ffc8ce313",
           // "ClientId": "66e9bbe8-8e74-41b9-b09d-361ffc8ce313",
           // "Status": 1
       // }
    })

}]);
