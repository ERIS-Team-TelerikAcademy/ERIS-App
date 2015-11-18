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
                var contractItem = $('<li />');

                var deadline = $('<p/>');
                deadline.html('Deadline: ' + currentContract.Deadline);
                var name = $('<p/>');
                var userName = contractData
                    .getUserNickname(currentContract.ClientId)
                    .then(function(userData){
                    name.html(userData.UserName);
                        contractItem.append(name);
                });

                var aprovalBtn = $('<input type="button" class="btn btn-success userSelectionButton" />');
                var rejectionBtn = $('<input type="button" class="btn btn-danger userSelectionButton" />');
                rejectionBtn.text('X');
                contractItem.append(deadline);
                contractItem.append(aprovalBtn);

                contractItem.append(rejectionBtn);

                if (currentContract.Status == 1) {
                    activeContractsContainer.append(contractItem);
                } else {
                    pendingContractsContainer.append(contractItem);
                }
            }
        }).then(function () {
            $('ul').on('Click', '.btn', function () {
                alert('asdasd'); // Dun work :(
                // Send put request to modify the contract(metadata in the html for contract recognition)
                // Update page
            })
        });
}]);
