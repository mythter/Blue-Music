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

    static SliderInit(slider) {
        slider.oninput = function () {
            let url = "url(" +
                "\x22data:image/svg+xml,<svg xmlns='http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg' width='100%' height='8'><defs><linearGradient id='blue-grad'><stop stop-color='%231e9ed7' offset='0%'/><stop stop-color='white' offset='100%'/></linearGradient></defs><rect x='0' y='0' width='" +
                this.value * 100 / this.max + "%" +
                "' height='8' rx='4' fill='url(%23blue-grad)'/></svg>\x22" +
                "), url(" +
                "\x22data:image/svg+xml,<svg xmlns='http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg' width='100%' height='8'><rect x='0' y='0' width='100%' height='8' rx='4' fill='%234d4c4d'/></svg>\x22" +
                ")";
            this.style.backgroundImage = url;
        }
    }

    static AudioInit(audio, slider, playBtn, currentTime, durationTime, volume) {
        let raf = null;
        let playState = 'play';
        let muteState = 'unmute';

        playBtn.addEventListener('click', () => {
            if (playState === 'play') {
                console.log("play");
                audio.play();
                playBtn.innerHTML = '<i class="fa-solid fa-circle-pause"></i>';
                requestAnimationFrame(whilePlaying);
                playState = 'pause';
            } else {
                audio.pause();
                playBtn.innerHTML = '<i class="fa-solid fa-circle-play"></i>';
                cancelAnimationFrame(raf);
                playState = 'play';
            }
        });

        const calculateTime = (secs) => {
            const minutes = Math.floor(secs / 60);
            const seconds = Math.floor(secs % 60);
            const returnedSeconds = seconds < 10 ? `0${seconds}` : `${seconds}`;
            return `${minutes}:${returnedSeconds}`;
        }

        const setSliderPosition = () => {
            let url = "url(" +
                "\x22data:image/svg+xml,<svg xmlns='http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg' width='100%' height='8'><defs><linearGradient id='blue-grad'><stop stop-color='%231e9ed7' offset='0%'/><stop stop-color='white' offset='100%'/></linearGradient></defs><rect x='0' y='0' width='" +
                slider.value * 100 / slider.max + "%" +
                "' height='8' rx='4' fill='url(%23blue-grad)'/></svg>\x22" +
                "), url(" +
                "\x22data:image/svg+xml,<svg xmlns='http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg' width='100%' height='8'><rect x='0' y='0' width='100%' height='8' rx='4' fill='%234d4c4d'/></svg>\x22" +
                ")";
            slider.style.backgroundImage = url;
            if (slider.value == slider.max) {
                audio.currentTime = 0;
                audio.pause();
                playState = 'play';
                //audio.currentTime = 0;
                //audio.play();
                //playBtn.innerHTML = '<i class="fa-solid fa-circle-pause"></i>';
                //requestAnimationFrame(whilePlaying);
                //let dt = new Date();
                //while ((new Date()) - dt <= 1000)
                //playState = 'pause';
                //audio.pause();
                playBtn.innerHTML = '<i class="fa-solid fa-circle-play"></i>';
                //cancelAnimationFrame(raf);
                //playState = 'play';
            }
        }

        const displayDuration = () => {
            durationTime.textContent = calculateTime(audio.duration);
        }

        const setSliderMax = () => {
            slider.max = Math.floor(audio.duration);
        }

        const whilePlaying = () => {
            slider.value = Math.floor(audio.currentTime);
            currentTime.textContent = calculateTime(slider.value);
            setSliderPosition();
            raf = requestAnimationFrame(whilePlaying);
        }

        if (audio.readyState > 0) {
            currentTime.textContent = '0:00'
            displayDuration();
            setSliderMax();
        } else {
            audio.addEventListener('loadedmetadata', () => {
                displayDuration();
                setSliderMax();
            });
        }

        slider.addEventListener('input', () => {
            currentTime.textContent = calculateTime(slider.value);
            if (!audio.paused) {
                cancelAnimationFrame(raf);
            }
        });

        slider.addEventListener('change', () => {
            audio.currentTime = slider.value;
            console.log(audio.paused)
            if (!audio.paused) {
                requestAnimationFrame(whilePlaying);
            }
        });
    }
}