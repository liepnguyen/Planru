directoryPlugin.controller('UserController', ['$scope', 'ngTableParams', '$modal', '$state', '$modal', '$rootScope',
    function ($scope, ngTableParams, $modal, $state, $modal, $rootScope) {
        $rootScope.title = 'Users';
        var vm = this;

        $scope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
            if (toState.name == 'active-users.create') {
                var modalInstance = $modal.open({
                    templateUrl: 'app/modules/directory/users/active-users/create/user-create.view.html',
                    controller: 'UserCreateController',
                    controllerAs: 'vm',
                    backdrop: true,
                    backdropClass: 'overlay',
                    resolve: { userCtrl: function () { return vm; } }
                }).result.finally(function () {
                    $state.go('active-users');
                });
            }
        });
    }]);
