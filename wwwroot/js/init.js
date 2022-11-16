(function ($) {
    $(function () {

        $('.sidenav').sidenav();
        $('.parallax').parallax();

    }); // end of document ready
})(jQuery); // end of jQuery name space

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('select');
    var instances = M.FormSelect.init(elems, options);
});

// Or with jQuery

$(document).ready(function () {
    $('select').formSelect();
});


var instance = M.Tabs.init(el, options);
var instance = M.Tabs.getInstance(elem);

// Or with jQuery

$(document).ready(function () {
    $('.tabs').tabs();
});

(function ($) {
    $(function () {

        $('.button-collapse').sideNav();
        $('.parallax').parallax();
        $('select').material_select();

        $('.modal-trigger').leanModal();

    }); // end of document ready
})(jQuery); // end of jQuery name space