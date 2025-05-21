using ETA25_Intermediate.Session08.HelperMethods;
using ETA25_Intermediate.Session08.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ETA25_Intermediate.Session08;
public abstract class BaseTest
{
    protected IWebDriver Driver { get; private set; } = null!;
    public const string BaseUrl = "https://demoqa.com/";
    protected AlertHelper AlertHelper { get; private set; } = null!;
    protected JavascriptHelper JavascriptHelper { get; private set; } = null!;
    protected HomePage HomePage { get; private set; } = null!;
    protected AlertsPage AlertsPage { get; private set; } = null!;
    protected PracticeFormPage PracticeFormPage { get; private set; } = null!;

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        AlertHelper = new AlertHelper(Driver);
        JavascriptHelper = new JavascriptHelper(Driver);
        HomePage = new HomePage(Driver);
        AlertsPage = new AlertsPage(Driver);
        PracticeFormPage = new PracticeFormPage(Driver);

        Driver.Navigate().GoToUrl(BaseUrl);
        Driver.Manage().Window.Maximize();
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
}
