directoryPlugin.controller('GroupCreateController', ['$rootScope', '$scope', '$modalInstance', 'toastr', 'groupService',
function ($rootScope, $scope, $modalInstance, toastr, groupService) {
    var vm = this;
    vm.new = {};

    vm.close = function () {
        $modalInstance.dismiss('cancel');
    }

    vm.create = function () {
        groupService.addGroup(vm.new).then(
            function (response) {
                $modalInstance.close();
            },
            function (error) {
                toastr.error(error.data.ExceptionMessage, error.statusText);
            });
    }
}]);