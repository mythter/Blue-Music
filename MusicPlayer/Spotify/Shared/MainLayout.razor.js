export class Main {

    static ResizeInit(resizer, sidebarPanel, favouritesPanel) {
        let resizing = false
        document.documentElement.style.setProperty("--scroll-width", "10px");

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
                    document.documentElement.style.setProperty("--scroll-width", "5px");
                }
                else {
                    sidebarPanel.style.width = event.clientX + "px"
                    favouritesPanel.style.paddingLeft = 10 + "px"
                    document.documentElement.style.setProperty("--scroll-width", "10px");
                }
            }
            else {
                finishResizing()
            }
        }

        const finishResizing = (e) => {
            resizing = false
            document.body.removeEventListener('mouseup', finishResizing)
            document.body.removeEventListener('mousemove', resizingMove)
        }
    }
}