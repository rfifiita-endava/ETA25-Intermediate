using ETA25_Intermediate.Session08.HelperMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ETA25_Intermediate.Session08;
public class AlertsFramesWindowsTests : BaseTest
{

    [Test]
    public void OpenBasicAlertTest()
    {
        HomePage.AccessPageByName(Enums.CardName.AlertsFramesWindows);

        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        AlertsPage.OpenBasicAlert();

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "You clicked a button");
    }

    [TestCase("This alert appeared after 5 seconds")]
    public void OpenTimerAlertTest(string alertExpectedText)
    {
        HomePage.AccessPageByName(Enums.CardName.AlertsFramesWindows);

        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        AlertsPage.OpenTimerAlert();

        var alertText = AlertHelper.GetAlertTextWithDelay();
        Assert.That(alertText == alertExpectedText);
    }

    [Test]
    public void OpenConfirmationAlertTest()
    {
        HomePage.AccessPageByName(Enums.CardName.AlertsFramesWindows);

        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        AlertsPage.OpenConfirmationAlert();

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "Do you confirm action?");

        AlertHelper.AlertCancel();
        var alertResultText = AlertsPage.GetConfirmationAlertResult();

        Assert.That(alertResultText == "You selected Cancel");
    }

    [Test]
    public void CheckConfirmationAlertResultWithoutOpeningAlertTest()
    {
        HomePage.AccessPageByName(Enums.CardName.AlertsFramesWindows);

        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        var alertResultText = AlertsPage.GetConfirmationAlertResult();

        Assert.That(alertResultText == string.Empty);
    }

    [TestCase("Radu Fifiita")]
    public void OpenComplexAlertTest(string alertInputText)
    {
        HomePage.AccessPageByName(Enums.CardName.AlertsFramesWindows);

        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        AlertsPage.OpenComplexAlert();

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "Please enter your name");

        AlertHelper.AlertSendText(alertInputText);
        var alertResultText = AlertsPage.GetComplexAlertResult();

        Assert.That(alertResultText == $"You entered {alertInputText}");
    }

    [Test]
    public void OpenNewWindowMessageTest()
    {
        HomePage.AccessPageByName(Enums.CardName.AlertsFramesWindows);

        IWebElement browserWindowsOption = Driver.FindElement(By.XPath("//span[text()=\"Browser Windows\"]"));
        browserWindowsOption.Click();

        IWebElement newWindowMessageButton = Driver.FindElement(By.Id("messageWindowButton"));
        newWindowMessageButton.Click();

        List<string> windows = Driver.WindowHandles.ToList();
        var currentWindowName = Driver.CurrentWindowHandle;
        Driver.SwitchTo().Window(windows[1]);

        JavascriptHelper.ExecuteScript("document.close();");

        new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
            .Until(d =>
                ((IJavaScriptExecutor)d)
                  .ExecuteScript("return document.readyState")
                  .Equals("complete"));
        var text = JavascriptHelper.GetElementTextContent("body");


        IWebElement pageText = Driver.FindElement(By.TagName("body"));
        string validationText = "Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.";

        Assert.That(pageText, Is.EqualTo(validationText));

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "You clicked a button");
    }
}
