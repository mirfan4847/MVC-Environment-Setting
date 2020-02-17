var UsersService = function () {
    var getAlluser = function (param, url, done, fail) {
        $.post(url, param)
       .done(done)
       .fail(fail)
    };

    var addUser = function (param, url, done, fail) {
        $.post(url, param)
        .done(done)
        .fail(fail)
    };

    return {
        GetAlluser: getAlluser,
        AddUser: addUser
    };
}();