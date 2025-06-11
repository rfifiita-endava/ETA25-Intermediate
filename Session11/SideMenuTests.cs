using ETA25_Intermediate.Session11.Enums;
using ETA25_Intermediate.Session11.Pages;
using NUnit.Framework;

namespace ETA25_Intermediate.Session11;
public class SideMenuTests : BaseTest
{
    public SideMenuTests(DriverType driverType) : base(driverType)
    {
    }

    protected AlertsPage AlertsPage { get; private set; } = null!;

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
        HomePage.AccessPageByName(CardName.Elements);

        //AlertsPage.AccessSideMenuOption(menuOption);

        var pageUrl = Driver.Url;

        Assert.That(pageUrl.Contains(expectedUrlPath));
    }

    [TestCase(FormsMenuOption.PracticeForm, "automation-practice-form")]
    public void AccessFormsMenuOptionWithMenuCollapsedTest(FormsMenuOption menuOption, string expectedUrlPath)
    {
        HomePage.AccessPageByName(CardName.Forms);

        // intetionally collapsing menu section
        AlertsPage.FormsMenu.Click();

        AlertsPage.AccessSideMenuOption(menuOption);

        var pageUrl = Driver.Url;

        Assert.That(pageUrl.Contains(expectedUrlPath));
    }

    [TearDown]
    public override void ExtraCleanup()
    {
        // add implementation here
    }

    [SetUp]
    public override void ExtraSetup()
    {
        AlertsPage = new AlertsPage(Driver);
    }
}
