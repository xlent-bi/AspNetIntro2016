(function () {
    'use strict';

    angular.module('CalendarModule')
    .controller('calendarHandlingController', ['$scope', 'CalendarFactory', function ($scope, CalendarFactory) {

        $scope.init = function (year, month) {
            $scope.year = year;
            $scope.month = month;

            $scope.fetchDays($scope.year, $scope.month);
        };

        $scope.fetchDays = function (year, month) {

            $scope.year = year;
            $scope.month = month;

            CalendarFactory.fetchDays(year, month).then(function (response) {
                $scope.days = response.data.Days;
                $scope.daysOriginal = response.data.Days;
                console.log($scope.daysOriginal);
            });
        };

        $scope.changeCalendar = function (year, month) {
            var y = (year);
            var m = (month);
            if (13 == m) {
                y += 1;
                m = 1;
            }
            else if (0 == m) {
                y -= 1;
                m = 12;
            }

            $scope.fetchDays(y, m);
        };

        var isWeekend = function (weekDay) {
            console.log(weekDay);
            return weekDay === "Lördag" || weekDay === "Söndag";
        }

        $scope.filter = {
            workFreeDays: false,
            weekends: false
        }
        

        $scope.filterWorkFreeDays = function () {
            $scope.filter.workFreeDays = !$scope.filter.workFreeDays;
            console.log("filter work free days: " + $scope.filter.workFreeDays);
            filter();
        }

        $scope.filterWeekends = function () {
            $scope.filter.weekends = !$scope.filter.weekends;
            console.log("filter weekends: " + $scope.filter.weekends);
            filter();
        }

        var filter = function () {
            $scope.days = [];
            var index = 0;
            for (var day in $scope.daysOriginal) { //why is day just the index?
                var toAdd = ( $scope.daysOriginal[index] );
                var add = true;
                if ($scope.filter.workFreeDays && !$scope.daysOriginal[index]["WorkFreeDay"]) {
                    add = false;
                }
                if ($scope.filter.weekends && isWeekend($scope.daysOriginal[index]["WeekDay"])) {
                    add = false;
                }
                console.log("add: " + add);
                if (true === add) {
                    $scope.days.push(toAdd);
                }
                ++index;
            }
        }

    }]);

})()