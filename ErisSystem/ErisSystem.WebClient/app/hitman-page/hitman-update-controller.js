'use strict';
app.controller('hitmanUpdateController', ['$scope', '$routeParams', 'authData', 'hitmanUpdateData',
    function ($scope,  $routeParams, authData, hitmanUpdateData) {
        $scope.userName = $routeParams.name;

        hitmanUpdateData.getByUserName($scope.userName)
        .then(function (response){
            $scope.hitman = response;
        });

        $scope.authentication = authData.authentication;
        $scope.rating = 2;
        $scope.rateFunction = function (rating) {

        };

        $('body').on('click', $('#save'), function(e){
            var data = {
                "UserName": $scope.userName,
                "AboutMe": $("#aboutMeText").val(),
                "Gender" : getGender(),
                "DateOfBirth" : $('#bday').val(),
                "IsWorking": getIsWorking()
            }

            hitmanUpdateData.updateInfo(data);
        });
    }]);

function getGender() {
    if($('#genderMale').is(':checked')) { 
        return true;
    } 
    else {
        return false;
    }
}

function getIsWorking() {
    if($("#isWorking").prop('checked') == true){
        return true;
    }
    else{
        return false;
    }
}