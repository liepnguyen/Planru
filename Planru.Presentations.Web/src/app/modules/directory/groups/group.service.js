directoryPlugin.service('groupService', ['$resource', '$q', function ($resource, $http, $q) {
    var Group = $resource('/api/api/group/:groupId', { groupId: '@id' });

    var service = {
        getGroups: getGroups,
        addGroup: addGroup,
        removeGroup: removeGroup,
        getGroup: getGroup,
        updateGroup: updateGroup
    };

    return service;

    function getGroups(page, count) {
        return Group.get({ page: page, count: count }).$promise;
    }

    function addGroup(user) {
        return Group.save(user).$promise;
    }

    function removeGroup(id) {
        return Group.delete({ id: id }).$promise;
    }

    function getGroup(id) {
    }

    function updateGroup(user) {

    }
}]);