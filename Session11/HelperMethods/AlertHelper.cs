using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ETA25_Intermediate.Session11.HelperMethods;
public class AlertHelper
{
    private readonly IWebDriver _driver;

    private readonly WebDriverWait _wait;

    public AlertHelper(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }

    public void AlertOk()
    {
        IAlert alert = GetAlert();
        alert.Accept();
    }

    public void AlertCancel()
    {
        IAlert alert = GetAlert();
        alert.Dismiss();
    }

    public void AlertSendText(string inputText)
    {
        IAlert alert = GetAlert();
        alert.SendKeys(inputText);
        alert.Accept();
    }

    public string GetAlertText()
    {
        IAlert alert = GetAlert();
        return alert.Text ?? string.Empty;
    }

    public string GetAlertTextWithDelay()
    {
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        return GetAlertText();
    }

    public void AlertOkWithDelay()
    {
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        AlertOk();
    }

    private IAlert GetAlert() => _driver.SwitchTo().Alert();
}
