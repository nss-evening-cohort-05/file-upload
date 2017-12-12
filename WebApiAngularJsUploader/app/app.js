(function () {
    'use strict';

    var app = angular.module('app', ['ngResource','ngRoute','app.photo']);

    app.config(['$routeProvider', function ($routeProvider) {        

        $routeProvider.when('/welcome', {
            templateUrl: 'app/welcome.html',
            controller: 'welcome',
            controllerAs: 'vm',
            caseInsensitiveMatch: true
        });

        $routeProvider.when("/nathansphotos",
            {
                templateUrl: "app/photo/nathan.html",
                controller: "nathansphotos"
            });

        $routeProvider.otherwise({
            redirectTo: '/welcome'
        });
    }]);


    // Handle routing errors and success events
    app.run([function () {        
    }]);
})();