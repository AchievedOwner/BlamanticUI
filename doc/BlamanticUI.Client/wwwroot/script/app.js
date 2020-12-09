window.hash = function (id) {
    var el = document.getElementById(id);
    if (el) {
        el.scrollIntoView({
            block: 'start',
            behavior: 'smooth',
            inline: 'end'
        });
    }
}