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
                                Status: currentContract.Status
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

    $scope.data = dataForClient;


    $('body').on('click', '.userSelectionButton', function () {
        alert('asd'); // And make post requests someday
    })

}]);
