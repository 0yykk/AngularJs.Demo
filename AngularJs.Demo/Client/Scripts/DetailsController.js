(function (app) {
    var DetailsController = function ($scope, $http, $routeParams) {
        debugger;
        var id = $routeParams.id;
        $http({
            method: 'GET',
            url: 'api/Album/details/' + id
        }).then(function successCallback(response) {
            $scope.album = response.data;
        }, function errorCallback(response) {
            alert(response);
        });

    };
    app.controller("DetailsController", DetailsController);
}(angular.module("atTheAlbum")));