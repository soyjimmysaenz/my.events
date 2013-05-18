'use strict';

/* Controllers */

angular.module('eventosApp.controllers', []).
  controller('eventosController', ['$scope', 'eventosService', function ($scope, eventosService) {
       
      $scope.fechaRealizacion = {
          fecha: new Date(),
          hora: new Date()
      };

      $scope.cambiarFormatoFecha = function () {
          var cadenaComparar = "-06:00";
          var cadenaFecha = $scope.evento.FechaRealizacion.slice(-6);
          if (cadenaFecha != "") {
              if (cadenaFecha != cadenaComparar) {
                  $scope.evento.FechaRealizacion += cadenaComparar;
              }
          }
      };
      
      var init = function () {
          $scope.evento = new eventosService();
          $scope.eventos = getEventos();
      };

      var getEventos = function () {
          return eventosService.query();
      };

      var getEvento = function (idEvento) {
          return eventosService.get({ id: idEvento });
      };

      var createEvento = function (nuevoEvento) {
          nuevoEvento.$save();
          $scope.eventos.push(nuevoEvento);
      };

      var updateEvento = function (evento) {
          evento.$update();
      };

      $scope.setNuevoEvento = function () {
          $scope.evento = new eventosService();
      };

      $scope.loadEvento = function (evento) {
          if (evento) {
              $scope.evento = evento;
          }
      };
      
      $scope.getEvento = function (id) {
          $scope.detalleEvento = getEvento(id);
      };

      $scope.saveEvento = function (evento) {
          
          if (evento.Id) {
              updateEvento(evento);
          }
          else {
              createEvento(evento);
          }
      };

      $scope.deleteEvento = function (evento) {
          var confirmacion = confirm('¿Seguro?');
          if (confirmacion) {
              evento.$delete({ id: evento.Id });
              $scope.eventos.splice($scope.eventos.indexOf(evento), 1);
          }
      };

      $scope.getHora = function() {
          console.log($scope.evento.FechaRealizacion);
      };

      init();

  }]);