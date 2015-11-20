'use strict';
app.controller('newContractController', ['$scope', '$location', 'contractData', 'authData',
    function ($scope, $location, contractData, authData) {


        var userId = authData.authentication.userId;
        // 50 username // 250 loc
        $("#send").click(function () {
            var data = {
                "HitmanId": authData.authentication.clientId,
                "ClientId": userId,
                "TargetName": $("#name").val(),
                "Location": $("#location").val(),
                "Deadline": $("#deadline").val()
            };
            if (data.TargetName.length > 50) {

            } else if (data.Location.length > 250) {

            } else {
                contractData.createContract(data);

                $location.path('/contract');
            }
        });
    }]);
