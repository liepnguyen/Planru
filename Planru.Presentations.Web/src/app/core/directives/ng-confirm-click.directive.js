var core = angular.module('planru.core', []);
core.directive('ngConfirmClick', ['$modal',
  function ($modal) {
      return {
          priority: -1,
          restrict: 'A',
          link: function (scope, element, attrs) {
              element.bind('click', function (e) {
                  var message = attrs.ngConfirmClick;
                  if (message && !confirm(message)) {
                      e.stopImmediatePropagation();
                      e.preventDefault();
                  }
              });
          }
      }
  }
]);

angular.module('ngReallyClickModule', ['ui.bootstrap'])
  .directive('ngReallyClick', ['$modal',
    function ($modal) {
        var ModalInstanceCtrl = function ($scope, $modalInstance) {
            $scope.ok = function () {
                $modalInstance.close();
            };
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        };

        return {
            restrict: 'A',
            scope: {
                ngReallyClick: "&"
            },
            link: function (scope, element, attrs) {
                element.bind('click', function () {
                    var title = attrs.ngReallyTitle || "Confirm";
                    var message = attrs.ngReallyMessage || "Are you sure you want to do that?";
                    var modalHtml =
                        '<div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true" ng-click="cancel()">&times;</button>' +
                        '<h4 class="modal-title"><i class="fa fa-exclamation-triangle"/> ' + title + '</h4></div>' +
                        '<div class="modal-body">' +
                            '<div class="alert alert-warning" role="alert">' +
                                message +
                            '</div>' +
                        '</div>' +
                        '<div class="modal-footer"><button class="btn btn-primary" ng-click="ok()">OK</button><button class="btn btn-default" ng-click="cancel()">Cancel</button></div>';

                    var modalInstance = $modal.open({
                        template: modalHtml,
                        controller: ModalInstanceCtrl,
                        backdrop: true
                    });

                    modalInstance.result.then(function () {
                        scope.ngReallyClick();
                    }, function () {
                    });
                });
            }
        }
    }
  ]);
