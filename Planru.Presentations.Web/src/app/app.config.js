var app = angular.module('planruApp', [
    'ngTable',
    'ui.router',
    'ui.bootstrap',
    'ngResource',
    'angular-loading-bar',
    'ngAnimate',
    'toastr',
    'planru.plugins.user'
])
.config(['$stateProvider', function ($stateProvider) {
    $stateProvider
      .state('dashboard', {
          url: '/',
          templateUrl: 'app/dashboard/dashboard.view.html',
          controller: 'DashboardController'
      })
      .state('deleted-users', {
          url: '/deleted-users',
          views: {
              '': {
                  templateUrl: 'app/admin/users/deleted-users/deleted-user.view.html',
                  controller: 'DeletedUserController'
              },
              'deleted-user-list@deleted-users': {
                  templateUrl: 'app/admin/users/deleted-users/list/deleted-user-list.view.html',
                  controller: 'DeletedUserListController'
              }
          }
      });
}])
.run(function ($rootScope) {
    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        $rootScope.previousState = fromState.name;
    });
});
