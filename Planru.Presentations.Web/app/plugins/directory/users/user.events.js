directoryPlugin.factory('userEvent', ['$rootScope', '$resource', '$q', function ($rootScope, $resource, $q) {
    var constants = {
        userCreatedEvent: 'DIRECTORY::USER::CREATED_EVENT',
        userDeletedEvent: 'DIRECTORY::USER::DELETED_EVENT'
    };

    // published events
    var events = {
        onUserCreated: onUserCreated,
        emitUserCreatedEvent: emitUserCreatedEvent,
        onUserDeleted: onUserDeleted,
        emitUserDeletedEvent: emitUserDeletedEvent
    };

    function onUserCreated(listener) {
        $rootScope.$on(constants.userCreatedEvent, listener);
    };

    function emitUserCreatedEvent(args) {
        $rootScope.$broadcast(constants.userCreatedEvent, args);
    };

    function onUserDeleted(listener) {
        $rootScope.$on(constants.userDeletedEvent, listener);
    };

    function emitUserDeletedEvent(args) {
        $rootScope.$broadcast(constants.userDeletedEvent, args);
    };

    return events;
}]);