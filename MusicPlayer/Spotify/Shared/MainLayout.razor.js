export class Main {
    static Init() {
        let resizing = false
        let resizer = document.getElementById('resizer')
        let resizingPanel = document.getElementById('sidebar')
        let favouritesPanel = document.getElementById('favourites')

        resizer.addEventListener('mousedown', (e) => {
            resizing = true
            document.body.addEventListener('mousemove', resizingMove)
            document.body.addEventListener('mouseup', finishResizing)
        })

        function resizingMove(event) {
            if (resizing) {
                if (event.clientX <= 150) {
                    resizingPanel.style.width = 74 + "px"
                    favouritesPanel.style.paddingLeft = 5 + "px"
                    favouritesPanel.style.paddingRight = 5 + "px"
                }
                else {
                    resizingPanel.style.width = event.clientX + "px"
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
}