directoryPlugin.factory('userEvent', ['$rootScope', '$resource', '$q', function ($rootScope, $resource, $q) {
    var constants = {
        userCreatedEvent: 'DIRECTORY::USER::CREATED_EVENT'
    };

    // published events
    var events = {
        onUserCreated: onUserCreated,
        emitUserCreatedEvent: emitUserCreatedEvent
    };

    function onUserCreated(listener) {
        $rootScope.$on(constants.userCreatedEvent, listener);
    };

    function emitUserCreatedEvent(args) {
        $rootScope.$broadcast(constants.userCreatedEvent, args);
    };

    return events;
}]);