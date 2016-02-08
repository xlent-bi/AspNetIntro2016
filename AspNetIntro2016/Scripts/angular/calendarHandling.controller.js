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
                $scope.daysOriginal = response.data.Days;
                filter();
                console.log($scope.daysOriginal);
            });
        };
        
        $scope.saveCalendar = function () {
            console.log("passing: ");
            console.log({ item: "str" });
            $.ajax({
                url: 'api/days/export',
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ item: "str" }),
                //dataType: "json",
                success: function (result) {
                    console.log('Yay! It worked!');
                    // Or if you are returning something
                    console.log('I returned... ' + result.str);
                },
                error: function (result) {
                    console.log('Oh no :(');
                }
            });
        }

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
            //console.log(weekDay);
            return weekDay === "Lördag" || weekDay === "Söndag";
        }

        $scope.filter = {
            workfreeDays: false,
            weekends: false
        }


        $scope.filterWorkfreeDays = function () {
            $scope.filter.workfreeDays = !$scope.filter.workfreeDays;
            console.log("filter work free days: " + $scope.filter.workfreeDays);
            filter();
        }

        $scope.filterWeekends = function () {
            $scope.filter.weekends = !$scope.filter.weekends;
            console.log("filter weekends: " + $scope.filter.weekends);
            filter();
        }

        var workfreeDaysFiltering = function (day) {
            console.log("should " + day + "be included in workfreeDays?");
            return day["WorkFreeDay"];
        }

        var weekendFiltering = function (day) {
            console.log("should " + day + " be included in no weekends?");
            return !isWeekend(day["WeekDay"]);
        }

        var filter = function () {
            $scope.days = $scope.daysOriginal;
            if ($scope.filter.workfreeDays) {
                $scope.days = $scope.days.filter(workfreeDaysFiltering);
            }
            if ($scope.filter.weekends) {
                $scope.days = $scope.days.filter(weekendFiltering);
            }
            /*
            for (var index in $scope.daysOriginal) { //why is day just the index?
                var toAdd = ( $scope.daysOriginal[index] );
                var add = true;
                if ($scope.filter.workfreeDays && !$scope.daysOriginal[index]["WorkFreeDay"]) {
                    add = false;
                }
                if ($scope.filter.weekends && isWeekend($scope.daysOriginal[index]["WeekDay"])) {
                    add = false;
                }
                console.log("add: " + add);
                if (true === add) {
                    $scope.days.push(toAdd);
                }
            }
            */
        }

    }]);

})()