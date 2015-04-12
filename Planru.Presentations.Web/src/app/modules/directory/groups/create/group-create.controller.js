directoryPlugin.controller('GroupCreateController', ['$rootScope', '$scope', '$modalInstance', 'toastr', 'groupService', 'groupEvent',
function ($rootScope, $scope, $modalInstance, toastr, groupService, groupEvent) {
    var vm = this;
    vm.new = {};

    vm.close = function () {
        $modalInstance.dismiss('cancel');
    }

    vm.create = function () {
        groupService.addGroup(vm.new).then(
            function (response) {
                groupEvent.emitGroupCreatedEvent({ sender: vm, group: response });
                toastr.success('You have created group successfully!', 'Success');
                $modalInstance.close();
            },
            function (error) {
                toastr.error(error.data.ExceptionMessage, error.statusText);
            });
    }
}]);