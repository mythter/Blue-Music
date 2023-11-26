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
                slider.value * 100 / slider.max + "%" +
                "' height='8' rx='4' fill='url(%23blue-grad)'/></svg>\x22" +
                "), url(" +
                "\x22data:image/svg+xml,<svg xmlns='http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg' width='100%' height='8'><rect x='0' y='0' width='100%' height='8' rx='4' fill='%234d4c4d'/></svg>\x22" +
                ")";
            slider.style.backgroundImage = url;
        }
    }

    static VolumeSliderInit(container, outer, inner, circle) {
        document.documentElement.style.setProperty("--volume-x", "100%");
        document.documentElement.style.setProperty("--circle-x", outer.clientWidth + "px");
        document.documentElement.style.setProperty("--volume-width", "100%");
        let moving = false;
        let entering = false;
        container.max = 100;
        container.value = container.max;
        container.updateValue = (v) => {
            if (v < 0) {
                container.value = 0;
            }
            else if (v > container.max) {
                container.value = container.max;
            }
            else if (v >= 0 && v <= container.max) {
                container.value = v;
            }

            document.documentElement.style.setProperty(
                "--volume-x",
                container.value + "%"
            );
            document.documentElement.style.setProperty("--circle-x", container.value * outer.clientWidth / 100 + "px");
        }
        let input = new CustomEvent("input", {
            bubbles: true,
            cancelable: true
        });

        const start = function (e) {
            let width = outer.clientWidth;
            let rect = outer.getBoundingClientRect();

            let x = e.clientX - rect.left;

            if (moving) {
                if (x >= width) {
                    document.documentElement.style.setProperty("--volume-x", 100 + "%");
                    document.documentElement.style.setProperty(
                        "--circle-x",
                        width + "px"
                    );
                } else if (x <= 0) {
                    document.documentElement.style.setProperty("--volume-x", 0 + "%");
                    document.documentElement.style.setProperty("--circle-x", 0 + "px");
                } else {
                    document.documentElement.style.setProperty(
                        "--volume-x",
                        (x * 100) / width + "%"
                    );
                    document.documentElement.style.setProperty("--circle-x", x + "px");
                }

                container.value = Math.round(
                    parseFloat(
                        getComputedStyle(document.documentElement).getPropertyValue("--volume-x")
                    ) * container.max / 100
                );

                container.dispatchEvent(input);
            } else {
                finish();
            }
        };

        const finish = () => {
            moving = false;

            if (!entering) {
                inner.classList.remove("inner-hover");
                circle.classList.remove("circle-hover");
            }

            container.removeEventListener("mousemove", start);
            document.removeEventListener("mousemove", start);
            document.removeEventListener("mouseup", finish);
        };

        container.addEventListener("mousedown", (e) => {
            moving = true;
            start(e);

            container.addEventListener("mousemove", start);
            document.addEventListener("mousemove", start);
            document.addEventListener("mouseup", finish);
        });

        container.addEventListener("mouseenter", () => {
            entering = true;

            inner.classList.add("inner-hover");
            circle.classList.add("circle-hover");
        });

        container.addEventListener("mouseleave", () => {
            entering = false;

            if (!moving) {
                inner.classList.remove("inner-hover");
                circle.classList.remove("circle-hover");
            }
        });

        window.addEventListener("resize", (e) => {
            let x =
                parseInt(
                    getComputedStyle(document.documentElement).getPropertyValue("--volume-x")
                ) / 100;
            document.documentElement.style.setProperty(
                "--circle-x",
                inner.clientWidth * x + "px"
            );
        });

    }

    static VolumeInit(audio, volume, volumeBtn, volumeContainer) {
        let volumeScrollStep = 10;

        volume.addEventListener('input', () => {
            if (volume.value > 0 && audio.muted) {
                audio.muted = false;
            }

            if (volume.value <= 0 && !audio.muted) {
                audio.muted = true;
            }
            else {
                audio.volume = volume.value / 100;
            }
            setVolumeIcon();

        });

        volumeBtn.addEventListener('click', () => {
            if (!audio.muted) {
                audio.muted = true;
                volume.updateValue(0);
            } else {
                audio.muted = false;
                if (audio.volume <= 0) {
                    audio.volume = 1;
                }
                volume.updateValue(audio.volume * 100);
            }
            setVolumeIcon();
        });

        const setVolumeIcon = () => {
            if (volume.value > 66) {
                volumeBtn.innerHTML = '<i class="ph ph-speaker-high"></i>';
            } else if (volume.value > 33 && volume.value <= 66) {
                volumeBtn.innerHTML = '<i class="ph ph-speaker-low"></i>';
            } else if (volume.value > 0 && volume.value <= 33) {
                volumeBtn.innerHTML = '<i class="ph ph-speaker-none"></i>';
            }
            else {
                volumeBtn.innerHTML = '<i class="ph ph-speaker-x"></i>';
            }
        }

        const setAudioVolume = () => {
            if (volume.value > 0 && audio.muted) {
                audio.muted = false;
            }

            if (volume.value <= 0 && !audio.muted) {
                audio.muted = true;
            }
            else {
                audio.volume = volume.value / 100;
            }
            setVolumeIcon();
        }

        volumeContainer.addEventListener('wheel', volumeMouseWheel)
        function volumeMouseWheel(e) {
            // scroll Up
            if (checkScrollDirectionIsUp(e)) {
                if (volume.value <= volume.max - volumeScrollStep) {
                    volume.value += volumeScrollStep;
                }
                else {
                    volume.value = volume.max;
                }

            }
            // scroll Down
            else {
                if (volume.value >= 0 + volumeScrollStep) {
                    volume.value -= volumeScrollStep;
                }
                else {
                    volume.value = 0;
                }
            }

            setAudioVolume();
            setVolumeIcon();
            volume.updateValue(volume.value);
        }

        function checkScrollDirectionIsUp(e) {
            if (e.wheelDelta) {
                return e.wheelDelta > 0
            }
            return e.deltaY < 0
        }
    }

    static AudioInit(audio, slider, playBtn, currentTime, durationTime, backBtn) {
        let raf = null;
        let playState = 'pause';

        playBtn.addEventListener('click', () => {

            if (!audioValid())
                return;

            // if audio valid do common logic
            if (playState === 'pause') {
                audio.play();
                playBtn.innerHTML = '<i class="fa-solid fa-circle-pause"></i>';
                requestAnimationFrame(whilePlaying);
                playState = 'play';
            } else {
                audio.pause();
                playBtn.innerHTML = '<i class="fa-solid fa-circle-play"></i>';
                cancelAnimationFrame(raf);
                playState = 'pause';
            }
        });

        backBtn.addEventListener('click', () => {

            if (!audioValid())
                return;

            if (audio.currentTime > 3) {
                audio.currentTime = 0;
                slider.value = audio.currentTime;
                currentTime.textContent = calculateTime(slider.value);
                setSliderPosition();
            } else {
                // TODO: back to previous track
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
                playBtn.innerHTML = '<i class="fa-solid fa-circle-play"></i>';
                cancelAnimationFrame(raf);
                playState = 'pause';

                slider.value = audio.currentTime;
                currentTime.textContent = calculateTime(slider.value);
                setSliderPosition();
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
            raf = requestAnimationFrame(whilePlaying);
            setSliderPosition();
        }

        const audioValid = () => {
            return audio.getAttribute("src") != null;
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

            if (!audioValid())
                return;

            currentTime.textContent = calculateTime(slider.value);
            if (!audio.paused) {
                cancelAnimationFrame(raf);
            }
        });

        slider.addEventListener('change', () => {

            if (!audioValid())
                return;

            audio.currentTime = slider.value;
            if (!audio.paused) {
                requestAnimationFrame(whilePlaying);
            }
        });
    }
}