using ETA25_Intermediate.Session07.Enums;
using ETA25_Intermediate.Session07.HelperMethods;
using ETA25_Intermediate.Session07.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ETA25_Intermediate.Session07;
public class PracticeFormTests
{
    public IWebDriver Driver;
    public const string BaseUrl = "https://demoqa.com/";
    public JavascriptHelper JavascriptHelper;
    private readonly PracticeFormPage _practiceFormPage;
    private readonly HomePage _homePage;

    public PracticeFormTests()
    {
        Driver = new ChromeDriver();
        JavascriptHelper = new JavascriptHelper(Driver);
        _practiceFormPage = new PracticeFormPage(Driver);
        _homePage = new HomePage(Driver);
    }

    [SetUp]
    public void Setup()
    {
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

    [Test]
    public void PracticeFormTest1()
    {
        _homePage.AccessPageByName(CardName.Forms);

        IWebElement practiceFormOption = Driver.FindElement(By.XPath("//span[text()=\"Practice Form\"]"));
        practiceFormOption.Click();
        JavascriptHelper.ScrollVertically(400);

        _practiceFormPage.FillInFormFields("Radu", "Fifiita", "test@test.com", Gender.Male, "00010305", "1992", "April", "16",
            new List<string>() { "English", "Accounting", "Physics" }, new List<Hobby>() { Hobby.Music, Hobby.Reading }, "Test Address 123, &*()");

        Thread.Sleep(3000);
    }
}
