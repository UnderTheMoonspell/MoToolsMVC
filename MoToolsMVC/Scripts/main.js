(function () {
    var Main = {
        init: function () {
            $('.user-container').click(function () {
                $('.user-popup').toggleClass('active');
            });
        }
    }
    Main.init();
})();