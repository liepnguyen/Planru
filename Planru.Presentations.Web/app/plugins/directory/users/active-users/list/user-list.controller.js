directoryPlugin.controller('UserListController', ['$scope', 'ngTableParams', 'toastr', 'userService', 'userEvent', function ($scope, ngTableParams, toastr, userService, userEvent) {

    var vm = this;

    vm.removeUser = function (id) {
        userService.removeUser(id);
    };

    userEvent.onUserCreated(function (event, args) {
        
    });

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
}]);