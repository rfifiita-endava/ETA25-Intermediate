using ETA25_Intermediate.Session07.HelperMethods;
using ETA25_Intermediate.Session07.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ETA25_Intermediate.Session07;
public class AlertsFramesWindowsTests
{
    public IWebDriver Driver { get; private set; }
    public const string BaseUrl = "https://demoqa.com/";
    public AlertHelper AlertHelper;
    public JavascriptHelper JavascriptHelper;
    private readonly HomePage _homePage;
    private readonly AlertsPage _alertsPage;

    public AlertsFramesWindowsTests()
    {
        Driver = new ChromeDriver();
        AlertHelper = new AlertHelper(Driver);
        JavascriptHelper = new JavascriptHelper(Driver);
        _homePage = new HomePage(Driver);
        _alertsPage = new AlertsPage(Driver);
    }

    [SetUp]
    public void Setup()
    {
        Driver.Navigate().GoToUrl(BaseUrl);

        Driver.Manage().Window.Maximize();

        _homePage.AccessPageByName(Enums.CardName.AlertsFramesWindows);
    }

    [TearDown]
    public void CleanUp()
    {
        if (Driver != null)
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }


    [Test]
    public void OpenBasicAlertTest()
    {
        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        _alertsPage.OpenBasicAlert();

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "You clicked a button");
    }

    [TestCase("This alert appeared after 5 seconds")]
    public void OpenTimerAlertTest(string alertExpectedText)
    {
        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        _alertsPage.OpenTimerAlert();

        var alertText = AlertHelper.GetAlertTextWithDelay();
        Assert.That(alertText == alertExpectedText);
    }

    [Test]
    public void OpenConfirmationAlertTest()
    {
        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        _alertsPage.OpenConfirmationAlert();

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "Do you confirm action?");

        AlertHelper.AlertCancel();
        var alertResultText = _alertsPage.GetConfirmationAlertResult();

        Assert.That(alertResultText == "You selected Cancel");
    }

    [Test]
    public void CheckConfirmationAlertResultWithoutOpeningAlertTest()
    {
        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        var alertResultText = _alertsPage.GetConfirmationAlertResult();

        Assert.That(alertResultText == string.Empty);
    }

    [TestCase("Radu Fifiita")]
    public void OpenComplexAlertTest(string alertInputText)
    {
        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Alerts\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(200);

        _alertsPage.OpenComplexAlert();

        var alertText = AlertHelper.GetAlertText();
        Assert.That(alertText == "Please enter your name");

        AlertHelper.AlertSendText(alertInputText);
        var alertResultText = _alertsPage.GetComplexAlertResult();

        Assert.That(alertResultText == $"You entered {alertInputText}");
    }

    [Test]
    public void OpenNewWindowMessageTest()
    {
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
