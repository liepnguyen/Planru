directoryPlugin.controller('UserListController', ['$scope', '$state', 'ngTableParams', 'toastr', 'userService', 'userEvent', function ($scope, $state, ngTableParams, toastr, userService, userEvent) {
    var vm = this;

    // definations
    vm.loadUsers = loadUsers;
    vm.deleteUser = deleteUser;

    // initialize
    vm.loadUsers();

    // implementations
    function loadUsers() {
        $scope.tableParams = new ngTableParams({
            page: 1,
            count: 10
        }, {
            total: 0,
            getData: function ($defer, params) {
                userService.getActiveUsers(params.page() - 1, params.count()).then(function (response) {
                    params.total(response.TotalItems);
                    $defer.resolve(response.Items);
                });
            }
        });
    };
    function deleteUser(id) {
        userService.removeUser(id).then(function (response) {
            userEvent.emitUserDeletedEvent(response);
            toastr.success('You have deleted user successfully!', 'Success');
        });
    };

    // event handlers
    userEvent.onUserCreated(function (event, args) {
        $scope.tableParams.reload();
    });
    userEvent.onUserDeleted(function (event, args) {
        $scope.tableParams.reload();
    });
}]);