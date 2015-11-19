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
                                ContractId: currentContract.Id
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
        var contractId  = a.attr('data').split(' ');
        alert('ContractId: ' + contractId[0] + 'ApprovalStatus:' + contractId[1]);
        //Put - get contract id from button data attribute
    })

}]);
