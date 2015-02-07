directoryPlugin.controller('UserCreateController', ['$rootScope', '$scope', '$modalInstance', 'toastr', 'userCtrl', 'userService', 'userEvent',
function ($rootScope, $scope, $modalInstance, toastr, userCtrl, userService, userEvent) {
        var vm = this;
        vm.new = {};
        vm.passwordOptions = { manually: 1, automatically: 2 };
        vm.new.passwordOption = vm.passwordOptions.automatically;

        vm.close = function () {
            $modalInstance.dismiss('cancel');
        }

        vm.create = function () {
            userService.addUser(vm.new).then(function (response) {
                toastr.success('You have created user successfully!', 'Success');
                userEvent.emitUserCreatedEvent({ sender: vm, user: response });
                $modalInstance.close();
            });
        }
    }]);