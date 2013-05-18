'use strict';

angular.module('eventosApp', [
    'eventosApp.services',
    'eventosApp.controllers',
    'eventosApp.directives'
]).
  config(['$routeProvider', function($routeProvider) {
      $routeProvider.when('/listar', { templateUrl: 'partials/list.html', controller: 'eventosController' });
      $routeProvider.when('/editar', { templateUrl: 'partials/edit.html', controller: 'eventosController' });
      $routeProvider.otherwise({ redirectTo: '/listar' });
  }]);
