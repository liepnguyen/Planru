app.config(['$stateProvider', function ($stateProvider) {
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
}]);
