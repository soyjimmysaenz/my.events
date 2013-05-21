'use strict';

/* Controllers */

angular.module('eventosApp.controllers', []).
  controller('eventosController', ['$scope', 'eventosService', function ($scope, eventosService) {
        
      //$scope.cambiarFormatoFecha = function () {
      //    var cadenaComparar = "-06:00";
      //    var cadenaFecha = $scope.evento.FechaRealizacion.slice(-6);
      //    if (cadenaFecha != "") {
      //        if (cadenaFecha != cadenaComparar) {
      //            $scope.evento.FechaRealizacion += cadenaComparar;
      //        }
      //    }
      //};
      
      var init = function () {
          $scope.evento = new eventosService();
          $scope.eventos = getEventos();
          $scope.fechaElegida = {fecha:'', hora:''};
      };

      var getEventos = function () {
          return eventosService.query();
      };

      var getEvento = function (idEvento) {
          return eventosService.get({ id: idEvento });
      };

      var createEvento = function (nuevoEvento) {
          nuevoEvento.FechaRealizacion = $scope.fechaElegida.fecha;
          nuevoEvento.$save({}, 
          function(data) {
              //nuevoEvento = data;
              $scope.eventos.push(nuevoEvento);
              $scope.status = data.status;
          },
          function(data) {
              // error callback
              $scope.status = data.status;
              switch (data.status) {
                  case '400':
                      $scope.error = "Ha realizado una acción incorrecta";
                  default:
                      $scope.error = "Algo salió mal :(";
              }
          });           
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
      
      //$scope.toLocalDate = function (fecha) {
      //    //var nuevaFecha = fecha + "-06:00";
      //    var utc = new Date(fecha);
      //    var local = new Date(utc.getUTCFullYear(), utc.getUTCMonth(), utc.getUTCDay(), utc.getUTCHours(), utc.getUTCMinutes());
      //    return local;
      //};

      init();

  }]);