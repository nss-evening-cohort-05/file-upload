angular
    .module('app.photo')
    .controller('nathansphotos', ["$http", "$scope", "photoManagerClient", function ($http, $scope, photoManagerClient) {
        $scope.photos = [];

        $scope.upload = function () {
            var files = {};

            angular.forEach($scope.photos, function (photo) {
                files[photo.name] = photo;
            });


            $http.post("api/photo", files,
                {
                    headers: { "Content-Type": undefined },
                    transformRequest: function (data) {
                        var formData = new FormData();
                        angular.forEach(data, function (value, key) {
                            formData.append(key, value);
                        });
                        return formData;
                    }
                });
            //photoManagerClient.save(formData);
        }
    }]);
