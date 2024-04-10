'use strict';

document.addEventListener('DOMContentLoaded', function () {
    if (document.getElementById('video')) {
        const poster = 'img/cover.jpg';
        const youtubeSrc = 'https://www.youtube.com/watch?v=2XX5zDThC3U';
        var myBackground = new vidim('#video', {
            src: youtubeSrc,
            type: 'YouTube',
            poster: poster,
        });
        myBackground.play();
    }
});
