export class Trackbar {
    static TrackInfoInit(info, title, author) {
        let animatingTitle = false
        let animatingAuthor = false
        let timeOutTitle = null
        let timeOutAuthor = null
        let speed = 12
        let infoPaddingRight = parseFloat(window.getComputedStyle(info, null).getPropertyValue('padding-right'))
        let infoPaddingLeft = parseFloat(window.getComputedStyle(info, null).getPropertyValue('padding-left'))
        let containerWidth = info.clientWidth - infoPaddingRight - infoPaddingLeft
        document.documentElement.style.setProperty("--track-info-width", containerWidth + "px")

        if (title.clientWidth > containerWidth) {
            let duration = (title.clientWidth - containerWidth) / speed
            title.classList.add('running-text')
            title.style["animation-duration"] = duration + "s"

            title.addEventListener("animationstart", animationTitleStart, false);
            title.addEventListener("animationend", animationTitleEnd, false);
            title.addEventListener("mouseenter", mouseEnterTitle, false);
            title.addEventListener("mouseleave", mouseLeaveTitle, false);
        }

        if (author.clientWidth > containerWidth) {
            let duration = (author.clientWidth - containerWidth) / speed
            author.classList.add('running-text')
            author.style["animation-duration"] = duration + "s"

            author.addEventListener("animationstart", animationAuthorStart, false);
            author.addEventListener("animationend", animationAuthorEnd, false);
            author.addEventListener("mouseenter", mouseEnterAuthor, false);
            author.addEventListener("mouseleave", mouseLeaveAuthor, false);
        }

        //new ResizeObserver(() => resizingInfo(info)).observe(info)

        window.addEventListener("resize", () => resizingInfo(info))

        function resizingInfo(infoArea) {
            let containerWidth = infoArea.clientWidth - infoPaddingRight - infoPaddingLeft

            title.classList.remove('running-text')
            if (title.clientWidth <= containerWidth) {
                title.removeEventListener("animationstart", animationTitleStart)
                title.removeEventListener("animationend", animationTitleEnd)
                title.removeEventListener("mouseenter", mouseEnterTitle)
                title.removeEventListener("mouseleave", mouseLeaveTitle)
            } else {
                title.classList.add('running-text')
                title.style["animation-iteration-count"] = "0"

                title.addEventListener("animationstart", animationTitleStart, false);
                title.addEventListener("animationend", animationTitleEnd, false);
                title.addEventListener("mouseenter", mouseEnterTitle, false);
                title.addEventListener("mouseleave", mouseLeaveTitle, false);
            }

            author.classList.remove('running-text')
            if (author.clientWidth <= containerWidth) {
                author.removeEventListener("animationstart", animationAuthorStart)
                author.removeEventListener("animationend", animationAuthorEnd)
                author.removeEventListener("mouseenter", mouseEnterAuthor)
                author.removeEventListener("mouseleave", mouseLeaveAuthor)
            } else {
                author.classList.add('running-text')
                author.style["animation-iteration-count"] = "0"

                author.addEventListener("animationstart", animationAuthorStart, false);
                author.addEventListener("animationend", animationAuthorEnd, false);
                author.addEventListener("mouseenter", mouseEnterAuthor, false);
                author.addEventListener("mouseleave", mouseLeaveAuthor, false);
            }
        }

        function animationAuthorStart() {
            animatingAuthor = true
        }

        function animationAuthorEnd() {
            animatingAuthor = false
        }

        function animationTitleStart() {
            animatingTitle = true
        }

        function animationTitleEnd() {
            animatingTitle = false
        }

        function mouseEnterTitle() {
            if (animatingTitle) {
                title.style["animation-play-state"] = "paused"
            } else {
                timeOutTitle = setTimeout(() => {
                    let infoWidth = info.clientWidth - infoPaddingRight - infoPaddingLeft
                    let duration = (title.clientWidth - infoWidth) / speed
                    document.documentElement.style.setProperty("--track-info-width", infoWidth + "px")

                    title.classList.remove('running-text')
                    title.offsetWidth
                    title.classList.add('running-text')
                    title.style["animation-duration"] = duration + "s"
                    title.style["animation-play-state"] = "running"
                    title.style["animation-iteration-count"] = "2"
                }, 160)
            }
        }

        function mouseLeaveTitle() {
            if (animatingTitle) {
                title.style["animation-play-state"] = "running"
            } else {
                clearTimeout(timeOutTitle)
                timeOutTitle = null
            }
        }

        function mouseEnterAuthor() {
            if (animatingAuthor) {
                author.style["animation-play-state"] = "paused"
            } else {
                timeOutAuthor = setTimeout(() => {
                    let infoWidth = info.clientWidth - infoPaddingRight - infoPaddingLeft
                    let duration = (author.clientWidth - infoWidth) / speed
                    document.documentElement.style.setProperty("--track-info-width", infoWidth + "px")

                    author.classList.remove('running-text')
                    author.offsetWidth
                    author.classList.add('running-text')
                    author.style["animation-duration"] = duration + "s"
                    author.style["animation-play-state"] = "running"
                    author.style["animation-iteration-count"] = "2"
                }, 160)
            }
        }

        function mouseLeaveAuthor() {
            if (animatingAuthor) {
                author.style["animation-play-state"] = "running"
            } else {
                clearTimeout(timeOutAuthor)
                timeOutAuthor = null
            }
        }
    }
}