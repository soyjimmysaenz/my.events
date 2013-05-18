'use strict';

var URI = 'http://localhost\\:48022/api/eventos/';
var URI_ID = URI + ':id';

angular.module('eventosApp.services', ["ngResource"])
  .factory("eventosService", function($resource) {
      return $resource(
          URI_ID,
          { id:'@id' },
          { update: { method:'PUT' } }
      );
  });
