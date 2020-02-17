var BookService = function () {

    var addBook = function (param, url, done, fail) {
        $.post(url, param)
        .done(done)
        .fail(fail)
    };
    return {
        AddBook: addBook
    };
}();