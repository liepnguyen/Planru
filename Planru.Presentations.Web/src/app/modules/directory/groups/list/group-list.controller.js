directoryPlugin.controller('GroupListController', ['$scope', 'ngTableParams', '$modal', '$state', '$modal', '$rootScope', 'groupService',
    function ($scope, ngTableParams, $modal, $state, $modal, $rootScope, groupService) {
        var vm = this;

        // definations
        vm.loadGroups = loadGroups;
        vm.deleteGroup = deleteGroup;

        // initialize
        vm.loadGroups();

        // implementations
        function loadGroups() {
            $scope.tableParams = new ngTableParams({
                page: 1,
                count: 10
            }, {
                total: 0,
                getData: function ($defer, params) {
                    groupService.getGroups(params.page() - 1, params.count()).then(function (response) {
                        params.total(response.TotalItems);
                        $defer.resolve(response.Items);
                    });
                }
            });
        };

        function deleteGroup(id) {
            groupService.removeGroup(id).then(function(response) {
                $scope.tableParams.reload();
            });
        }
    }]);
