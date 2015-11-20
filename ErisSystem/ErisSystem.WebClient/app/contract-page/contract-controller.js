'use strict';
app.controller('contractController', ['$scope', 'contractData', 'authData', 'ratingData',
    function ($scope, contractData, authData, ratingData) {

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
                                TargetName: currentContract.TargetName,
                                Location: currentContract.Location,
                                Status: currentContract.Status,
                                ContractId: currentContract.Id,
                                ClientId: currentContract.ClientId
                            }
                        }
                    })
            }

        }).then(function(){
            console.log('123123123');
            $scope.dataForHitman = dataForHitman;
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
                                TargetName: currentContract.TargetName,
                                Location: currentContract.Location,
                                DeadLine: currentContract.Deadline,
                                Status: currentContract.Status
                            }
                        }
                    })
            }

        }).then(function(){
            console.log('123123123');
            $scope.dataForClient = dataForClient;
        });



    $('body').on('click', '.userSelectionButton', function (e) {
        var a = $(e.target);
        var contract  = a.attr('data').split(' ');
        var data = {
            "id": contract[0],
            "HitmanId": userId,
            "ClientId": contract[2],
            "Status": contract[1]
        };
        var res = contractData.put(data);
        if(res){
            var newThing = a.parent();
            $('#pendingContracts').children().remove(newThing);
            newThing.children().remove('.userSelectionButton');
            if(contract[0] === '1'){
                $('#activeContracts').append(newThing);
            }
        }
    });

    $('body').on('click', '.ratingButton', function (e) {
        var a = $(e.target);
        var clientId  = a.attr('data');
        var data = {
            "HitmanId": userId,
            "ClientId": clientId,
            "Rating": 2
        };
        var res = ratingData.post(data);
    })

}]);
