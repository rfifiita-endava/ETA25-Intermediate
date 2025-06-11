using OpenQA.Selenium;

namespace ETA25_Intermediate.Session11.Pages;
public class AlertsPage : BasePage
{
    public AlertsPage(IWebDriver driver) : base(driver) { }
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
        var elements = Driver.FindElements(By.Id(elementId));
        if (elements.Count > 0)
        {
            IWebElement result = elements[0];
            return result.Text;
        }
        return string.Empty;
    }

    private void ClickOnElemById(string elementId)
    {
        IWebElement element = Driver.FindElement(By.Id(elementId));
        element.Click();
    }
}
