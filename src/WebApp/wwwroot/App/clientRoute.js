
webApp.config(["$routeProvider", "$locationProvider", "$httpProvider", function ($routeProvider, $locationProvider, $httpProvider) {

    $routeProvider.when("/", {
        templateUrl: "/app/home/html/home.html",
        controller: "homeController",
        controllerAs: "vm"
    });

    $routeProvider.when("/about", {
        templateUrl: "/app/home/html/about.html"
    });

    $routeProvider.otherwise({
        redirecTo: '/'
    });

    $locationProvider.html5Mode(true).hashPrefix('!');


}]);