directoryPlugin.controller('UserListController', ['$scope', '$state', '$modal', 'ngTableParams', 'toastr', 'userService', 'userEvent',
    function ($scope, $state, $modal, ngTableParams, toastr, userService, userEvent) {
    var vm = this;

    // definations
    vm.loadUsers = loadUsers;
    vm.deleteUser = deleteUser;
    vm.createUser = createUser;

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
    function createUser() {
        var modalInstance = $modal.open({
            templateUrl: 'app/modules/directory/users/active-users/create/user-create.view.html',
            controller: 'UserCreateController',
            controllerAs: 'vm',
            backdrop: true,
            backdropClass: 'overlay',
            resolve: { userCtrl: function () { return vm; } }
        }).result.finally(function () { });
    }

    // event handlers
    userEvent.onUserCreated(function (event, args) {
        $scope.tableParams.reload();
    });
    userEvent.onUserDeleted(function (event, args) {
        $scope.tableParams.reload();
    });
}]);