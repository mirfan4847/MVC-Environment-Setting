var LoginService = function () {

    var login = function (param, url, done, fail) {
        $.post(url, param)
        .done(done)
        .fail(fail)
    };

    var register = function (param, url, done, fail) {
        $.post(url, param)
        .done(done)
        .fail(fail)
    };
    return {
        Login: login,
        Register: register
    };
}();