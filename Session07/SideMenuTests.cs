using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETA25_Intermediate.Session07.HelperMethods;
using ETA25_Intermediate.Session07.Pages;
using ETA25_Intermediate.Session07.Enums;

namespace ETA25_Intermediate.Session07;
public class SideMenuTests
{
    public IWebDriver Driver;
    public const string BaseUrl = "https://demoqa.com/";
    public JavascriptHelper JavascriptHelper;
    private HomePage _homePage;
    private BasePage _basePage;

    public SideMenuTests()
    {
        // moved initialization to Setup method to support
        // running multiple tests from the same test class
    }

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        JavascriptHelper = new JavascriptHelper(Driver);
        _homePage = new HomePage(Driver);
        _basePage = new BasePage(Driver);

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

    [TestCase(ElementsMenuOption.TextBox, "text-box")]
    [TestCase(ElementsMenuOption.CheckBox, "checkbox")]
    [TestCase(ElementsMenuOption.RadioButton, "radio-button")]
    [TestCase(ElementsMenuOption.WebTables, "webtables")]
    [TestCase(ElementsMenuOption.Buttons, "buttons")]
    [TestCase(ElementsMenuOption.Links, "links")]
    [TestCase(ElementsMenuOption.BrokenLinks, "broken")]
    [TestCase(ElementsMenuOption.UploadAndDownload, "upload-download")]
    [TestCase(ElementsMenuOption.DynamicProperties, "dynamic-properties")]
    public void AccessElementsMenuOptionWithMenuExpandedTest(ElementsMenuOption menuOption, string expectedUrlPath)
    {
        _homePage.AccessPageByName(CardName.Elements);

        _basePage.AccessSideMenuOption(menuOption);

        var pageUrl = Driver.Url;

        Assert.That(pageUrl.Contains(expectedUrlPath));
    }

    [TestCase(FormsMenuOption.PracticeForm, "automation-practice-form")]
    public void AccessFormsMenuOptionWithMenuCollapsedTest(FormsMenuOption menuOption, string expectedUrlPath)
    {
        _homePage.AccessPageByName(CardName.Forms);

        // intetionally collapsing menu section
        _basePage.FormsMenu.Click();

        _basePage.AccessSideMenuOption(menuOption);

        var pageUrl = Driver.Url;

        Assert.That(pageUrl.Contains(expectedUrlPath));
    }
}
