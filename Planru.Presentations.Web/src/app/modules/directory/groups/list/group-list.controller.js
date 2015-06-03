directoryPlugin.controller('GroupListController', ['$scope', 'ngTableParams', '$modal', '$state', '$modal', '$rootScope', 'groupService', 'groupEvent',
    function ($scope, ngTableParams, $modal, $state, $modal, $rootScope, groupService, groupEvent) {
        var vm = this;
        vm.checkboxes = { 'checked': false, items: {} };

        // definations
        vm.loadGroups = loadGroups;
        vm.deleteGroup = deleteGroup;
        vm.editGroup = editGroup;
        vm.createGroup = createGroup;

        // initialize
        vm.loadGroups();

        // implementations
        function loadGroups() {
            $scope.tableParams = new ngTableParams({ page: 1, count: 10 }, {
                total: 0, getData: function ($defer, params) {
                    groupService.getGroups(params.page() - 1, params.count()).then(function (response) {
                        params.total(response.TotalItems);
                        $defer.resolve(response.Items);
                    });
                }
            });
        }

        function deleteGroup(id) {
            groupService.removeGroup(id).then(function(response) {
                $scope.tableParams.reload();
            });
        }

        function editGroup(id) {
            $state.go('groups.edit', { groupId: id });
        }

        function createGroup() {
            var modalInstance = $modal.open({
                templateUrl: 'app/modules/directory/groups/create/group-create.view.html',
                controller: 'GroupCreateController',
                controllerAs: 'vm',
                backdrop: true
            }).result.finally(function () {

            });
        }

        // event handlers
        groupEvent.onGroupCreated(function (event, args) {
            $scope.tableParams.reload();
        });
        groupEvent.onGroupDeleted(function (event, args) {
            $scope.tableParams.reload();
        });
    }]);
