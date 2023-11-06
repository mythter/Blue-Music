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

            title.addEventListener("animationstart", () => {
                animatingTitle = true
            }, false);
            title.addEventListener("animationend", () => {
                animatingTitle = false
            }, false);
            title.addEventListener("mouseenter", () => mouseEnter(title, info, animatingTitle), false);
            title.addEventListener("mouseleave", () => mouseLeave(title, animatingTitle), false);
        }

        if (author.clientWidth > containerWidth) {
            let duration = (author.clientWidth - containerWidth) / speed
            author.classList.add('running-text')
            author.style["animation-duration"] = duration + "s"

            author.addEventListener("animationstart", () => {
                animatingAuthor = true
            }, false);
            author.addEventListener("animationend", () => {
                animatingAuthor = false
            }, false);
            author.addEventListener("mouseenter", () => mouseEnter(author, info, animatingAuthor), false);
            author.addEventListener("mouseleave", () => mouseLeave(author, animatingAuthor), false);
        }

        function mouseEnter(target, info, animating) {
            if (animating) {
                target.style["animation-play-state"] = "paused"
            } else {
                let duration = (target.clientWidth - info.clientWidth - 12) / speed
                document.documentElement.style.setProperty("--track-info-width", info.clientWidth - 12 + "px")

                target.classList.remove('running-text')
                target.offsetWidth
                target.classList.add('running-text')
                target.style["animation-duration"] = duration + "s"
                target.style["animation-play-state"] = "paused"
            }
        }

        function mouseLeave(target, animating) {
            if (animating) {
                target.style["animation-play-state"] = "running"
            }
        }
    }
}