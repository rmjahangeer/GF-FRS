﻿(function() {
    'use strict';

    angular.module('app.Profile',[]);


})();

(function() {
    'use strict';

    angular
        .module('app.Profile', [])
        .controller('ProfileController', ProfileController);

    ProfileController.$inject = ['$scope','$stateParams', '$state', 'ProfileService', 'toaster'];

    function ProfileController($scope,$stateParams, $state, ProfileService, toaster) {
        var vm = this;
        //ui-select
        vm.disabled = undefined;
        vm.Role = {};
        vm.Roles = [
          //{ Id: '1', Name: 'a'}
        ];
        ProfileService.getBaseData(function (response) {
            vm.Roles = response;
        },
        function (err) {
            toaster.error(showErrors(err));
        });
        
        vm.saveProfile = function () {
            vm.user.RoleId = vm.Roles.selected.Id;
            ProfileService.saveProfile(vm.user,function(response) {
                if (response) {
                    toaster.success("Profile Saved.");
                    $state.go('app.dashboard');
                }

            }, function(err) {
                toaster.error(showErrors(err));
            });
        }
        debugger;
        if ($stateParams.Id != null) {
            ProfileService.loadProfile($stateParams.Id, function(response) {
                vm.user = response;
            });
        }

    }
})();