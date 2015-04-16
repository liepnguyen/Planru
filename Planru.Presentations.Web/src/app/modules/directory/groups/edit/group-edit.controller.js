directoryPlugin.controller('GroupEditController', ['$rootScope', '$scope', '$state', 'toastr', 'groupService',
function ($rootScope, $scope, $state, toastr, groupService) {
    // initialize
    var vm = this;
    vm.edit = {};

    // definations
    var groupId = $state.params.groupId;

    groupService.getGroup(groupId).then(function (response) {
        vm.edit = response;
    });
}]);