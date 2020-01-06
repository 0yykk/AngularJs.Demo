(function (app) {

    var albumService = function ($http, albumApiUrl) {
        var getAll = function () {
            return $http.get(albumApiUrl);
        };
        debugger;
        var getById = function (id) {
            return $http.get(albumApiUrl + id);
        };
        var update = function (album) {
            return $http.put(albumApiUrl + album.id, album);
        }
        var create = function (album) {
            return $http.post(albumApiUrl, album);
        };
        var destory = function (album) {
            return $http.delete(albumApiUrl + album.id);
        }
        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destory
        };
    };
    app.factory("albumService", albumService);
}(angular.module("atTheAlbum")))