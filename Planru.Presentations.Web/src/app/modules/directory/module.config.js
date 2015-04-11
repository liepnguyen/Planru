var directoryPlugin = angular.module('planru.modules.directory', [

]).config(['$stateProvider', function ($stateProvider) {
    $stateProvider
      .state('active-users', {
          url: '/active-users',
          views: {
              '': {
                  templateUrl: 'app/modules/directory/users/active-users/active-user.view.html',
                  controller: 'UserController'
              },
              'user-list@active-users': {
                  templateUrl: 'app/modules/directory/users/active-users/list/user-list.view.html',
                  controller: 'UserListController',
                  controllerAs: 'vm'
              }
          }
      })
      .state('active-users.create', {
          url: '/create'
      })
      .state('groups', {
          url: '/groups',
          views: {
              '': {
                  templateUrl: 'app/modules/directory/groups/group.view.html',
                  controller: 'GroupController'
              },
              'group-list@groups': {
                  templateUrl: 'app/modules/directory/groups/list/group-list.view.html',
                  controller: 'GroupListController',
                  controllerAs: 'vm'
              }
          }
      })
      .state('groups.create', {
          url: '/create'
      })
}]);