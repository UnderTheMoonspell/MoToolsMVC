(function () {

    var Helpers = {

        init: function () {
            window.createCookie = function (name, value, days) {
                if (days) {
                    var date = new Date();
                    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                    var expires = "; expires=" + date.toGMTString();
                }
                else var expires = "";
                document.cookie = name + "=" + value + expires + "; path=/";
            }

            window.readCookie = function (name) {
                var nameEQ = name + "=";
                var ca = document.cookie.split(';');
                for (var i = 0; i < ca.length; i++) {
                    var c = ca[i];
                    while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
                }
                return null;
            }

            window.eraseCookie = function (name) {
                createCookie(name, "", -1);
            }

            window.ajaxCall = function (url, type, data, success, error) {
                $.ajax({
                    type: type,
                    url: url,
                    data: JSON.stringify(data),
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        if (typeof (success) == "function")
                            success(response);
                    },
                    error: function (response) {
                        if (typeof (error) == "function")
                            error(response);
                    }
                });
            }

            window.setLocalStorageItem = function (key, object) {
                localStorage.setItem(key, object);
            }

            window.getLocalStorageItem = function (key) {
                return localStorage.getItem(key);
            }

            window.setSessionStorageItem = function (key, object) {
                sessionStorage.setItem(key, object);
            }

            window.getSessionStorageItem = function (key) {
                return sessionStorage.getItem(key);
            }
        }
    }

    Helpers.init();

})();