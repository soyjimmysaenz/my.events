'use strict';

/* Controllers */

angular.module('eventosApp.controllers', []).
  controller('eventosController', ['$scope', 'eventosService', function ($scope, eventosService) {
        
      var init = function () {
          $scope.evento = new eventosService();
          $scope.isViewLoading = false;
          getEventos();
          $scope.fechaElegida = { fecha: '', hora: '' };
      };
      
      var cambiarFormatoFecha = function (fecha) {
          var cadenaComparar = "-06:00";
          var cadenaFecha = fecha.slice(-6);
          var resp = fecha;
          if (cadenaFecha != "") {
              if (cadenaFecha != cadenaComparar) {
                  resp += cadenaComparar;
              }
          }
          return resp;
      };

      var getEventos = function () {
          $scope.isViewLoading = true;
           
          eventosService.query({}, 
          function(data) {
              $scope.eventos = data;
              $scope.isViewLoading = false;
          },
          function (err) {
              $scope.error = err;
              $scope.isViewLoading = false;
          });
      };

      var getEvento = function (idEvento) {
          return eventosService.get({ id: idEvento });
      };

      var createEvento = function (nuevoEvento) {
          nuevoEvento.$save({}, 
          function(data) {
              //nuevoEvento = data;
              $scope.eventos.push(nuevoEvento);
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
              $scope.fechaElegida.fecha = $scope.evento.FechaRealizacion;
          }
      };
      
      $scope.getEvento = function (id) {
          $scope.detalleEvento = getEvento(id);
      };

      $scope.saveEvento = function (evento) {
          evento.FechaRealizacion = cambiarFormatoFecha($scope.fechaElegida.fecha);
          $scope.fechaElegida.fecha = '';
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
      
      init();

  }]);