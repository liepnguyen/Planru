app.run(function ($rootScope) {
    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        $rootScope.previousState = fromState.name;
    });
});