
var things = function () {

    return 'The thing function';
    
}

console.log(things());


var ninja = {

    yell: function yell(n) {
        return n > 0 ? yell(n - 1) + 'a' : 'hiy';
    }
}

assert(ninja.yell(4) == 'hiyaaaa', 'Works as we expect it to!');