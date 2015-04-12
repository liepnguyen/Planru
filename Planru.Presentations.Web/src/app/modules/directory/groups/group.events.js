directoryPlugin.factory('groupEvent', ['$rootScope', '$resource', '$q', function ($rootScope, $resource, $q) {
    var constants = {
        groupCreatedEvent: 'DIRECTORY::GROUP::CREATED_EVENT',
        groupDeletedEvent: 'DIRECTORY::GROUP::DELETED_EVENT'
    };

    // published events
    var events = {
        onGroupCreated: onGroupCreated,
        emitGroupCreatedEvent: emitGroupCreatedEvent,
        onGroupDeleted: onGroupDeleted,
        emitGroupDeletedEvent: emitGroupDeletedEvent
    };

    function onGroupCreated(listener) {
        $rootScope.$on(constants.groupCreatedEvent, listener);
    };

    function emitGroupCreatedEvent(args) {
        $rootScope.$broadcast(constants.groupCreatedEvent, args);
    };

    function onGroupDeleted(listener) {
        $rootScope.$on(constants.groupDeletedEvent, listener);
    };

    function emitGroupDeletedEvent(args) {
        $rootScope.$broadcast(constants.groupDeletedEvent, args);
    };

    return events;
}]);