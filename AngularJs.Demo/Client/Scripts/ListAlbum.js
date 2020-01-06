//(function (app) {
//    var ListController = function ($scope, $http) {
//        $http({
//            method: 'GET',
//            url: 'api/Album/GetAllAlbumAsync'
//        }).then(function successCallback(response) {
//            debugger;
//            $scope.albums = response.data;
//            }, function errorCallback(response) {
//                alert(response);
//        });
//    };
//    app.controller("ListController", ListController)
//}(angular.module("atTheAlbum")));
(function (app) {
    var ListController = function ($scope, albumService) {
        albumService
            .getAll()
            .then(function successCallback(response) {
                $scope.albums = response.data;
            }, function errorCallback(response) {
                alert(response);
            });
        $scope.create = function () {
            $scope.edit = {
                album:
                {
                    Title: "",
                    ArtistName: "",
                    GenreName: "",
                    Price:""
                }
            };
        };
        $scope.delete = function (album) {
            albumService.delete(album)
                .then(function () {
                    removeAlbumById(album.AlbumId);
                });
        };
        var removeAlbumById = function (id) {
            for (var i = 0; i < $scope.albums.lenght; i++) {
                if ($scope.albums[i].AlbumId == id) {
                    $scope.albums.splice(i, 1);
                    break;
                }
            }
        }
    };
    app.controller("ListController", ListController)
}(angular.module("atTheAlbum")));

