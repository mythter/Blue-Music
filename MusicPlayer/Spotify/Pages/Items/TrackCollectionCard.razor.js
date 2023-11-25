export class TrackCollectionCard {
    static InitHover(target) {
        target.addEventListener('mouseenter', function (e) {
            e.target.style.setProperty('--x', e.offsetX + 'px');
            e.target.style.setProperty('--y', e.offsetY + 'px');
            e.target.style.setProperty('--w', (e.target.clientWidth * 4) + 'px');
        });

        target.addEventListener('mouseleave', function (e) {
            let offsetX = e.offsetX > e.target.clientWidth ? e.offsetX - 50 : e.offsetX + 50;
            let offsetY = e.offsetY > e.target.clientHeight ? e.offsetY + 50 : e.offsetY - 50;
            e.target.style.setProperty('--x', offsetX + 'px');
            e.target.style.setProperty('--y', offsetY + 'px');
        });

    }
}