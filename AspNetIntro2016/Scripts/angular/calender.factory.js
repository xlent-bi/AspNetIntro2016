( function() {
    
    'use strict';

    angular.module('CalendarModule')
    .factory('CalendarFactory', ['$http', function ($http) {
        return {
            fetchDays: function (year, month) {
                return $http.get('/api/days/' + year + '/' + month);
            }
        }
    }]);
})()
