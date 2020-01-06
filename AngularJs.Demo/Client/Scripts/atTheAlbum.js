(function () {
    var app = angular.module('atTheAlbum', ['ngRoute']);
    debugger;
   
    var config = function ($routeProvider) {
        $routeProvider
            .when("/list",
            {
                templateUrl: "/client/views/list.html",
            })
            .when("/details/:id",
            {
                templateUrl: "/client/views/details.html",
            })
            .otherwise(
                { redirectTo: "/list" });
    };
    app.config(config);
    app.constant("albumApiUrl", "/api/Album/");
}());
