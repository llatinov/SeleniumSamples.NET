using OpenQA.Selenium;

namespace AutomationRhapsody.DesignPatterns
{
    class HomePageObject
    {
        private WebDriverFacade webDriver;
        public HomePageObject(WebDriverFacade webDriver)
        {
            this.webDriver = webDriver;
        }

        private IWebElement SearchLabel
        {
            get { return webDriver.FindElement(By.CssSelector("div.find label")); }
        }

        private IWebElement SearchField
        {
            get { return webDriver.FindElement(By.Id("search")); }
        }

        public string GetSearchLabel()
        {
            return SearchLabel.Text;
        }

        public void SearchFor(string text)
        {
            SearchField.SendKeys(text);
        }

        public void ClearSearch()
        {
            webDriver.ExecuteJavaScript("$('span.cancel').click()");
        }
    }
}
