'use strict';
app.controller('contractController', ['$scope', 'contractData', function ($scope, contractData) {

    var activeContractsContainer = $('#activeContracts');
    var pendingContractsContainer = $('#pendingContracts');

    var contracts = contractData
        .getAll()
        .then(function (data) {
            console.log(data);
            for (var i = 0; i < data.length; i += 1) {
                var currentContract = data[i];

                var deadline = $('<p/>');
                deadline.html('Deadline: ' + currentContract.Deadline);

                var name = $('<p/>');
                name.html('Some name');

                var aprovalBtn = $('<button/>');
                aprovalBtn.html('Approve');
                aprovalBtn.On('Click', function () {

                });

                var contractItem = $('<li />');
                contractItem.append(name);
                contractItem.append(deadline);
                contractItem.append(aprovalBtn);

                if (currentContract.Status == 1) {
                    activeContractsContainer.append(contractItem);
                } else {
                    pendingContractsContainer.append(contractItem);
                }
            }
        });
}]);
