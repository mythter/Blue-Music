export class Main {

    static ResizeInit(resizer, sidebarPanel, favouritesPanel) {
        let resizing = false

        resizer.addEventListener('mousedown', (e) => {
            resizing = true
            document.body.addEventListener('mousemove', resizingMove)
            document.body.addEventListener('mouseup', finishResizing)
        })

        function resizingMove(event) {
            if (resizing) {
                if (event.clientX <= 150) {
                    sidebarPanel.style.width = 74 + "px"
                    favouritesPanel.style.paddingLeft = 5 + "px"
                    favouritesPanel.style.paddingRight = 5 + "px"
                }
                else {
                    sidebarPanel.style.width = event.clientX + "px"
                    favouritesPanel.style.paddingLeft = 10 + "px"
                    favouritesPanel.style.paddingRight = 10 + "px"
                }
            }
            else {
                finishResizing()
            }
        }

        const finishResizing = (e) => {
            resizing = false
            document.body.removeEventListener('mouseup', finishResizing)
            resizer.removeEventListener('mousemove', resizingMove)
        }
    }

    static LoadNextInit(dotNet, mainPanel) {
        mainPanel.addEventListener("scroll", () => {
            const scrollTop = mainPanel.scrollTop
            const scrollHeigth = mainPanel.scrollHeight
            const clientHeight = mainPanel.clientHeight
            let percent = scrollTop * 100 / (scrollHeigth - clientHeight)

            if (percent > 90) {
                dotNet.invokeMethodAsync("LoadNext")
            }
        })
    }
}