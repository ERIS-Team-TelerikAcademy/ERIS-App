'use strict';
app.controller('contractController', ['$scope', 'contractData', function ($scope, contractData) {

    var activeContractsContainer = $('#activeContracts');
    var pendingContractsContainer = $('#pendingContracts');
    var dataCollection = [];
    var userNames = [];
    var contracts = contractData
        .getAll().then(function (data) {
            var i = 0;
            var j = 0;
            for (i = 0; i < data.length; i += 1){
                var currentContract = data[i];
                contractData.getUserNickname(currentContract.ClientId)
                    .then(function(userData){
                    userNames[j] = userData.UserName;
                        j++;
                    return data;

                }).then(function (data) {
                    console.log(data);
                    for (var i = 0; i < data.length; i += 1) {
                        var currentContract = data[i];
                        dataCollection[i] = {
                            UserName: userNames[i],
                            DeadLine: currentContract.Deadline,
                            Status: currentContract.Status
                        }
                    }
                })
            }

        });
            $scope.data = dataCollection;


    $('body').on('click', '.userSelectionButton', function () {
        alert('asd'); // And make post requests someday
    })

}]);
