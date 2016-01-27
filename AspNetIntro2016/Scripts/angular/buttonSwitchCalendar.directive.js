(function () {
    'use strict';
    angular.module('CalendarModule')
        .directive('ButtonSwitchCalendar', function () {
            return {
                restrict: 'E',
                scope: {
                    date: '='
                },
                templateUrl: 'Views/Shared/ngTemplate/buttonSwitchCalendar.html',
                controller: 'SwitchCalendarController'
            };
        });
})();