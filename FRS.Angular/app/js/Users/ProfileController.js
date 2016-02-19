﻿//(function() {
//    'use strict';

//    angular.module('app.Profile',[]);


//})();

(function() {
    'use strict';

    //angular
    //    .module('app.Profile', [])
    //    .controller('ProfileController', ProfileController);
    var core = angular.module('app.core');
    // ReSharper disable FunctionsUsedBeforeDeclared
    core.lazy.controller('ProfileController', ProfileController);

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
        
        if ($stateParams.Name !== "") {
            ProfileService.loadProfile($stateParams.Name, function (response) {
                vm.user = response;
                var selectedRole = $(vm.Roles).filter(function (index, item) {
                    return item.Name === response.Role;
                });
                if (selectedRole.length > 0) {
                    vm.Roles.selected = selectedRole[0];
                }
            });
        }

        vm.saveProfile = function () {
            vm.user.RoleId = vm.Roles.selected.Id;
            ProfileService.saveProfile(vm.user,function(response) {
                if (response) {
                    toaster.success("Profile Saved.");
                    //$state.go('app.dashboard');
                }

            }, function(err) {
                toaster.pop("error","Alert",showErrors(err));
            });
        }
        
        

    }
})();