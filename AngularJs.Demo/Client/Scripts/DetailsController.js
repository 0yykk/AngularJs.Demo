//(function (app) {
//    var DetailsController = function ($scope, $http, $routeParams) {
//        debugger;
//        var id = $routeParams.id;
//        $http({
//            method: 'GET',
//            url: 'api/Album/details/' + id
//        }).then(function successCallback(response) {
//            $scope.album = response.data;
//        }, function errorCallback(response) {
//            alert(response);
//        });

//    };
//    app.controller("DetailsController", DetailsController);
//}(angular.module("atTheAlbum")));

(function (app) {
    var DetailsController = function ($scope,$routeParams,albumService) {
        debugger;
        var id = $routeParams.id;
        albumService
        .getById(id)
        .then(function successCallback(response) {
            $scope.album = response.data;
        }, function errorCallback(response) {
            alert(response);
            });
        $scope.edit = function () {
            $scope.edit.album = angular.copy($scope.album);
        };

    };
    app.controller("DetailsController", DetailsController);
}(angular.module("atTheAlbum")));