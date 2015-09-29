'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

var app = angular.module('app.controllers', [])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', 'backendHubProxy', function ($scope, $location, $window, backendHubProxy) {
        $scope.$root.title = 'AngularJS SPA Template for Visual Studio';

        console.log('trying to connect to service')
        var performanceDataHub = backendHubProxy(backendHubProxy.defaultServer, 'performanceHub');
        console.log('connected to service')
        $scope.currentRamNumber = 68;

        performanceDataHub.on('broadcastPerformance', function (data) {
            data.forEach(function (dataItem) {
                switch (dataItem.categoryName) {
                    case 'Processor':
                        break;
                    case 'Memory':
                        $scope.currentRamNumber = dataItem.value;
                        break;
                    case 'Network In':
                        break;
                    case 'Network Out':
                        break;
                    case 'Disk Read Bytes/Sec':
                        break;
                    case 'Disk Write Bytes/Sec':
                        break;
                    default:
                        //default code block
                        break;
                }
            });
        });


        //$scope.$on('$viewContentLoaded', function () {
        //    $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        //});
    }])

    // Path: /about
    .controller('AboutCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | About';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /login
    .controller('LoginCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | Sign In';
        // TODO: Authorize a user
        $scope.login = function () {
            $location.path('/');
            return false;
        };
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Error 404: Page Not Found';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);



app.factory('backendHubProxy', ['$rootScope', 'backendServerUrl',
  function ($rootScope, backendServerUrl) {

      function backendFactory(serverUrl, hubName) {
          var connection = $.hubConnection(backendServerUrl);
          var proxy = connection.createHubProxy(hubName);

          connection.start().done(function () { });

          return {
              on: function (eventName, callback) {
                  proxy.on(eventName, function (result) {
                      $rootScope.$apply(function () {
                          if (callback) {
                              callback(result);
                          }
                      });
                  });
              },
              invoke: function (methodName, callback) {
                  proxy.invoke(methodName)
                  .done(function (result) {
                      $rootScope.$apply(function () {
                          if (callback) {
                              callback(result);
                          }
                      });
                  });
              }
          };
      };

      return backendFactory;
  }]);