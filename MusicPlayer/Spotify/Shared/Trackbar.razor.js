export class Trackbar {
    static TrackInfoInit(info, title, author) {
        let animatingTitle = false
        let animatingAuthor = false
        let speed = 12
        let infoPaddingRight = parseFloat(window.getComputedStyle(info, null).getPropertyValue('padding-right'))
        let infoPaddingLeft = parseFloat(window.getComputedStyle(info, null).getPropertyValue('padding-left'))
        let containerWidth = info.clientWidth - infoPaddingRight - infoPaddingLeft
        document.documentElement.style.setProperty("--track-info-width", containerWidth + "px")

        if (title.clientWidth > containerWidth) {
            let duration = (title.clientWidth - containerWidth) / speed
            title.classList.add('running-text')
            title.style["animation-duration"] = duration + "s"
            title.addEventListener("animationstart", function () {
                animatingTitle = true
            }, false);
            title.addEventListener("animationend", function () {
                animatingTitle = false
            }, false);
            title.addEventListener("mouseenter", function () {
                if (animatingTitle) {
                    title.style["animation-play-state"] = "paused"
                } else {
                    title.classList.remove('running-text')
                    title.offsetWidth
                    title.classList.add('running-text')
                    title.style["animation-duration"] = duration + "s"
                    title.style["animation-play-state"] = "paused"
                }
            }, false);
            title.addEventListener("mouseleave", function () {
                if (animatingTitle) {
                    title.style["animation-play-state"] = "running"
                }
            }, false);
        }

        if (author.clientWidth > containerWidth) {
            let duration = (author.clientWidth - containerWidth) / speed
            author.classList.add('running-text')
            author.style["animation-duration"] = duration + "s"
            author.addEventListener("animationstart", function () {
                animatingAuthor = true
            }, false);
            author.addEventListener("animationend", function () {
                animatingAuthor = false
            }, false);
            author.addEventListener("mouseenter", function () {
                if (animatingAuthor) {
                    author.style["animation-play-state"] = "paused"
                } else {
                    author.classList.remove('running-text')
                    author.offsetWidth
                    author.classList.add('running-text')
                    author.style["animation-duration"] = duration + "s"
                    author.style["animation-play-state"] = "paused"
                }
            }, false);
            author.addEventListener("mouseleave", function () {
                if (animatingAuthor) {
                    author.style["animation-play-state"] = "running"
                }
            }, false);
        }
    }
}