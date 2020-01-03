(function (app) {
    var ListController = function ($scope, $http) {
        $http({
            method: 'GET',
            url: 'api/Album/GetAllAlbumAsync'
        }).then(function successCallback(response) {
            debugger;
            $scope.albums = response.data;
            }, function errorCallback(response) {
                alert(response);
        });
    };
    app.controller("ListController", ListController)
}(angular.module("atTheAlbum")));

