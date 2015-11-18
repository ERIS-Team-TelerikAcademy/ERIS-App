'use strict';
app.controller('contractController', ['$scope', 'contractData', function ($scope, contractData) {

    var activeContractsContainer = $('#activeContracts');
    var pendingContractsContainer = $('#pendingContracts');
    var dataCollection = [];
    var contracts = contractData
        .getAll()
        .then(function (data) {
            console.log(data);
            for (var i = 0; i < data.length; i += 1) {
                var currentContract = data[i];
                dataCollection[i] = {
                    UserName: currentContract.ClientId,
                    DeadLine: currentContract.Deadline,
                    Status: currentContract.Status

                }
            }
        }).then(function(){
            $scope.data = dataCollection;
        });
}]);
/*var contractItem = $('<li />');

var deadline = $('<p/>');
deadline.html('Deadline: ' + currentContract.Deadline);
var name = $('<p/>');
var userName = contractData
    .getUserNickname(currentContract.ClientId)
    .then(function (userData) {
        name.html(userData.UserName);
        contractItem.append(name);
    });
contractItem.append(deadline);

var aprovalBtn = $('<button class="approvalButton userSelectionButton" />');
var rejectionBtn = $('<button class="rejectButton userSelectionButton" />');

contractItem.append(aprovalBtn);
contractItem.append(rejectionBtn);

if (currentContract.Status == 1) {
    activeContractsContainer.append(contractItem);
} else {
    pendingContractsContainer.append(contractItem);
}*/