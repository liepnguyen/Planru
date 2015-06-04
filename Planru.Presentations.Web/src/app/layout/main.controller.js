app.controller("MainController", ["$scope",
  function($scope) {
    var vm = this;

    // properties
    vm.leftPanelCollapsed = false;

    // definations
    vm.toggleLeftPanel = toggleLeftPanel;

    // implementations
    function toggleLeftPanel() {
      vm.leftPanelCollapsed = !vm.leftPanelCollapsed;
    }

    // DOM manipulations
    angular.element('.parent').on('click', function() {
      var parent = angular.element(this);
      var children = parent.find('.children');
      if (parent.hasClass('nav-active')) {
        parent.removeClass('nav-active');
        children.addClass('hide');
      }
      else {
        parent.addClass('nav-active');
        children.removeClass('hide');
      }
    });
  }])
