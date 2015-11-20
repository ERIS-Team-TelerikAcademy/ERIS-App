'use strict';
app.controller('contractController', ['$scope', 'contractData', 'authData', function ($scope, contractData, authData) {

    var activeContractsContainer = $('#activeContracts');
    var pendingContractsContainer = $('#pendingContracts');
    var dataForHitman = [];
    var clientsNames = [];
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
                        clientsNames[j] = userData.UserName;
                        j++;
                        return data;

                    }).then(function (data) {
                        for (var i = 0; i < data.length; i += 1) {
                            var currentContract = data[i];
                            dataForHitman[i] = {
                                UserName: clientsNames[i],
                                DeadLine: currentContract.Deadline,
                                TargetName: currentContract.TargetName,
                                Location: currentContract.Location,
                                Status: currentContract.Status,
                                ContractId: currentContract.Id,
                                ClientId: currentContract.ClientId
                            }
                        }
                    })
            }
            console.log('hitman data came');
        }).then(function () {
            console.log('hitman data got set ');
            $scope.dataForHitman = dataForHitman;
        });
    var dataForClient = [];
    var hitmenNames = [];
    contractData
        .getAllForClient(userId)
        .then(function (data) {
            var i = 0;
            var j = 0;
            for (i = 0; i < data.length; i += 1) {
                var currentContract = data[i];
                contractData.getUserNickname(currentContract.HitmanId)
                    .then(function (userData) {
                        hitmenNames[j] = userData.UserName;
                        j++;
                        return data;

                    }).then(function (data) {
                        for (var i = 0; i < data.length; i += 1) {
                            var currentContract = data[i];
                            dataForClient[i] = {
                                UserName: hitmenNames[i],
                                TargetName: currentContract.TargetName,
                                Location: currentContract.Location,
                                DeadLine: currentContract.Deadline,
                                Status: currentContract.Status
                            }
                        }
                    })
            }
            console.log("client data came");

        }).then(function () {
            console.log('client data got set');
            $scope.dataForClient = dataForClient;
        });


    $('body').on('click', '.userSelectionButton', function (e) {
        var a = $(e.target);
        var contract = a.attr('data').split(' ');
        var data = {
            "id": contract[0],
            "HitmanId": userId,
            "ClientId": contract[2],
            "Status": contract[1]
        };
        var res = contractData.put(data);
        if (res) {
            var newThing = a.parent();
            $(".pendingContracts").remove(a.parent());
            newThing.children().remove('.userSelectionButton');
            if (contract[0] === '1') {
                $('.activeContracts').append(newThing);
            }
        }
    })

}]);
