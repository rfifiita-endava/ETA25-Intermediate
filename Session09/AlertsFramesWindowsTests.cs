using ETA25_Intermediate.Session09.Enums;
using ETA25_Intermediate.Session09.HelperMethods;
using ETA25_Intermediate.Session09.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ETA25_Intermediate.Session09;
public class AlertsFramesWindowsTests : BaseTest
{
    protected AlertsPage AlertsPage { get; private set; } = null!;

    [SetUp]
    public override void ExtraSetup()
    {
        AlertsPage = new AlertsPage(Driver);

        HomePage.AccessPageByName(Enums.CardName.AlertsFramesWindows);

        AlertsPage.AccessSideMenuOption(Enums.AlertsFramesWindowsMenuOption.Alerts);
        JavascriptHelper.ScrollVertically(200);
    }

    [TearDown]
    public override void ExtraCleanup()
    {
        // add implementation here
    }

    [Test]
    public void OpenBasicAlertTest()
    {
        AlertsPage.OpenBasicAlert();

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "You clicked a button");
    }

    [TestCase("This alert appeared after 5 seconds")]
    public void OpenTimerAlertTest(string alertExpectedText)
    {
        AlertsPage.OpenTimerAlert();

        var alertText = AlertHelper.GetAlertTextWithDelay();
        Assert.That(alertText == alertExpectedText);
    }

    [Test]
    public void OpenConfirmationAlertTest()
    {
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
        var alertResultText = AlertsPage.GetConfirmationAlertResult();

        Assert.That(alertResultText == string.Empty);
    }

    [TestCase("Radu Fifiita")]
    public void OpenComplexAlertTest(string alertInputText)
    {
        AlertsPage.OpenComplexAlert();

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "Please enter your name");

        AlertHelper.AlertSendText(alertInputText);
        var alertResultText = AlertsPage.GetComplexAlertResult();

        Assert.That(alertResultText == $"You entered {alertInputText}");
    }

    [TestCase(DriverType.Firefox)]
    public void OpenNewWindowMessageTest(DriverType driverType)
    {
        AlertsPage.AccessSideMenuOption(Enums.AlertsFramesWindowsMenuOption.BrowserWindows);

        IWebElement newWindowMessageButton = Driver.FindElement(By.Id("messageWindowButton"));
        newWindowMessageButton.Click();

        List<string> windows = Driver.WindowHandles.ToList();
        var currentWindowName = Driver.CurrentWindowHandle;
        Driver.SwitchTo().Window(windows[1]);


        string pageText = Driver.FindElement(By.TagName("body")).Text;
        string validationText = "Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.";

        Assert.That(pageText, Is.EqualTo(validationText));
    }
}
