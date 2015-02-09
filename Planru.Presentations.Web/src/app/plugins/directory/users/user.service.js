directoryPlugin.service('userService', ['$resource', '$q', function ($resource, $http, $q) {
    var User = $resource('/api/api/user/:userId', { userId: '@id' });

    var service = {
        getActiveUsers: getActiveUsers,
        addUser: addUser,
        removeUser: removeUser,
        getUser: getUser,
        updateUser: updateUser
    };

    return service;

    function getActiveUsers(page, count) {
        return User.get({page: page, count: count}).$promise;
    }

    function addUser(user) {
        return User.save(user).$promise;
    }

    function removeUser(id) {
        return User.delete({ id: id }).$promise;
    }

    function getUser(id) {
    }

    function updateUser(user) {

    }

    function getDeletedUsers() {

    }
}]);