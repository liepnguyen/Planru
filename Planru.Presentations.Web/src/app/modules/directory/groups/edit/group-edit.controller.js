directoryPlugin.controller('GroupEditController', ['$rootScope', '$scope', '$state', 'toastr', 'ngTableParams', 'groupService',
function ($rootScope, $scope, $state, toastr, ngTableParams, groupService) {
    // initialize
    var vm = this;
    vm.edit = {};

    // definations
    var groupId = $state.params.groupId;

    groupService.getGroup(groupId).then(function (response) {
        vm.edit = response;
    });

    function loadMembers() {
        $scope.membersTableParams = new ngTableParams({ page: 1, count: 10 }, {
            total: 0, getData: function ($defer, params) {
                params.total(2);
                $defer.resolve([
                    { FullName: "Liep Nguyen", Username: "liepnguyen", Email: "liepnguyen@kms-technology.com" },
                    { FullName: "Liep Nguyen", Username: "liepnguyen", Email: "liepnguyen@kms-technology.com" },
                ]);
            }
        });
    }

    loadMembers();
}]);