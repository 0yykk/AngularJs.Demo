(function (app) {
    var EditContoller = function ($scope, albumService) {
        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.album;
        };
        $scope.cancel = function () {
            return $scope.album = null;
        };
        $scope.save = function () {
            if ($scope.edit.album.AlbumId) {
                updateAlbum();
            }
            else {
                createAlbum();
            }
        };
        var updateAlbum = function () {
            albumService.update($scope.edit.album)
                .then(function () {
                    angular.extend($scope.album, $scope.edit.album);
                    $scope.edit.album = null;
                });
        };
        var createAlbum = function () {
            albumService.create($scope.edit.album)
                .then(function () {
                    $scope.album.push(album);
                    $scope.edit.album = null;
                });
        };
    };
    app.controller("EditController", EditContoller);

}(angular.module("atTheAlbum")));