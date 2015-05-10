
webApp.service("homeService", function ($http, confServer) {


    
    this.post = function (number) {
        var request = $http({
            method: "post",
            url: confServer.apiUrl + "api/Number/",
            data: number
        });
        return request;
    };

});
