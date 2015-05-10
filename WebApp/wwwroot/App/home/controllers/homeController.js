"use strict";

webApp.controller('homeController', function ( homeService) {

    var vm = this;

    vm.number = [];
    vm.pattern = /^\d+$/;
    vm.number.value = 0;
    vm.number.type = 0;
    vm.number.letter = '';
    vm.number.decimal = 0;
    vm.number.step = 1;

    function changePattern() {

        var value = vm.number.decimal;

        if (value == 0)
            vm.pattern = /^\d+$/;
        else 
            vm.pattern = /^[0-9]+(\.[0-9]{1,2})?$/;
    }

    function ok() {
        var number = {
            Value: vm.number.value,
            Type: vm.number.type,
            Decimal: vm.number.decimal,
            Letter: ''
        };

        
        var promise = homeService.post(number);

        promise.then(function (pl) {
            vm.number.letter = pl.data;
        }, function (errorPl) {
            alert(errorPl);
        });

         
    };

    function cancel() {
        vm.number.value = 0;
        vm.number.type = 0;
        vm.number.letter = '';
    }

    vm.ok = ok;
    vm.cancel = cancel;
    vm.changePattern = changePattern;
});