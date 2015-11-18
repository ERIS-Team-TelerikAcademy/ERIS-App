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
        }).then(function () {
            $scope.data = dataCollection;
        });
    $('body').on('click', '.userSelectionButton', function () {
        alert('asd'); // And make post requests someday 
    })

}]);
