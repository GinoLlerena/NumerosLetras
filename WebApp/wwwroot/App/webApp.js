"use strict";

var webApp = angular.module('webApp', ['ngRoute', 'ngResource', 'ui.bootstrap']);


webApp.constant("confServer", {
    "apiUrl": "/",
    "clientId": "webApp"
});

webApp.factory("sharedData", function () { return { value: 0 } });

