using OpenQA.Selenium;

namespace ETA25_Intermediate.Session05.Pages;
public class AlertsPage
{
    private readonly IWebDriver _driver;

    public AlertsPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void OpenBasicAlert()
    {
        ClickOnElemById("alertButton");
    }

    public void OpenTimerAlert()
    {
        ClickOnElemById("timerAlertButton");
    }

    public void OpenConfirmationAlert()
    {
        ClickOnElemById("confirmButton");
    }

    public void OpenComplexAlert()
    {
        ClickOnElemById("promtButton");
    }

    public string GetComplexAlertResult()
    {
        return GetTextFromElementById("promptResult");
    }

    public string GetConfirmationAlertResult()
    {
        return GetTextFromElementById("confirmResult");
    }

    private string GetTextFromElementById(string elementId)
    {
        var elements = _driver.FindElements(By.Id(elementId));
        if (elements.Count > 0)
        {
            IWebElement result = elements[0];
            return result.Text;
        }
        return string.Empty;
    }

    private void ClickOnElemById(string elementId)
    {
        IWebElement element = _driver.FindElement(By.Id(elementId));
        element.Click();
    }
}
