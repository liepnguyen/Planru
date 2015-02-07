var directoryPlugin = angular.module('planru.plugins.user', [

]).config(['$stateProvider', function ($stateProvider) {
    $stateProvider
      .state('active-users', {
          url: '/active-users',
          views: {
              '': {
                  templateUrl: 'app/plugins/directory/users/active-users/active-user.view.html',
                  controller: 'UserController'
              },
              'user-list@active-users': {
                  templateUrl: 'app/plugins/directory/users/active-users/list/user-list.view.html',
                  controller: 'UserListController',
                  controllerAs: 'vm'
              }
          }
      })
      .state('active-users.create', {
          url: '/create'
      })
}]);