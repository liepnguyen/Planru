directoryPlugin.controller('GroupController', ['$scope', 'ngTableParams', '$modal', '$state', '$modal', '$rootScope',
    function ($scope, ngTableParams, $modal, $state, $modal, $rootScope) {
        $rootScope.title = 'Groups';
        $rootScope.icon = 'fa-group';
        var vm = this;

        $scope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
            if (toState.name == 'groups.create') {
                var modalInstance = $modal.open({
                    templateUrl: 'app/modules/directory/groups/create/group-create.view.html',
                    controller: 'GroupCreateController',
                    controllerAs: 'vm',
                    backdrop: true,
                    backdropClass: 'overlay',
                    resolve: { userCtrl: function () { return vm; } }
                }).result.finally(function () {
                    $state.go('groups');
                });
            }
        });
    }]);
