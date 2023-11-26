export class Index {

    static LoadNextInit(dotNet, mainPanel) {
        mainPanel.addEventListener("scroll", () => {
            const scrollTop = mainPanel.scrollTop
            const scrollHeigth = mainPanel.scrollHeight
            const clientHeight = mainPanel.clientHeight
            let percent = scrollTop * 100 / (scrollHeigth - clientHeight)

            if (percent > 80) {
                dotNet.invokeMethodAsync("LoadNext")
            }
        })
    }
}