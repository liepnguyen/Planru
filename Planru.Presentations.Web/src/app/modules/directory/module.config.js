var directoryPlugin = angular.module('planru.modules.directory', [

]).config(['$stateProvider', function ($stateProvider) {
    $stateProvider
      .state('active-users', {
          url: '/active-users/:userId',
          views: {
              '': {
                  templateUrl: 'app/modules/directory/users/active-users/active-user.view.html',
                  controller: 'UserController'
              },
              '@active-users': {
                  templateUrl: 'app/modules/directory/users/active-users/list/user-list.view.html',
                  controller: 'UserListController',
                  controllerAs: 'vm'
              }
          }
      })
      .state('active-users.edit', {
          url: '/edit'
      })
      .state('groups', {
          url: '/groups/:groupId',
          views: {
              '': {
                  templateUrl: 'app/modules/directory/groups/group.view.html',
                  controller: 'GroupController'
              },
              '@groups': {
                  templateUrl: 'app/modules/directory/groups/list/group-list.view.html',
                  controller: 'GroupListController',
                  controllerAs: 'vm'
              }
          }
      })
      .state('groups.edit', {
          url: '/edit',
          views: {
              '': {
                  templateUrl: 'app/modules/directory/groups/edit/group-edit.view.html',
                  controller: 'GroupEditController',
                  controllerAs: 'vm'
              }
          }
      })
}]);