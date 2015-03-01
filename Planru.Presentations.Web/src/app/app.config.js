var app = angular.module('planruApp', [
    'ngTable',
    'ui.router',
    'ui.bootstrap',
    'ngResource',
    'angular-loading-bar',
    'ngAnimate',
    'toastr',
    'planru.modules.user'
])
.config(['$stateProvider', function ($stateProvider) {
    $stateProvider
      .state('dashboard', {
          url: '/',
          templateUrl: 'app/modules/dashboard/dashboard.view.html',
          controller: 'DashboardController'
      });
}])
.run(function ($rootScope) {
    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        $rootScope.previousState = fromState.name;
    });
});
