using ETA25_Intermediate.Session07.Enums;
using OpenQA.Selenium;

namespace ETA25_Intermediate.Session07.Pages;

public class BasePage
{
    public BasePage(IWebDriver driver)
    {
        Driver = driver;
    }

    protected IWebDriver Driver { get; }

    // WebElements
    public IWebElement ElementsMenu => GetMenuSection(1);
    public IWebElement FormsMenu => GetMenuSection(2);
    public IWebElement AlertsFramesWindowsMenu => GetMenuSection(3);
    public IWebElement WidgetsMenu => GetMenuSection(4);
    public IWebElement InteractionsMenu => GetMenuSection(5);
    public IWebElement BookStoreApplicationMenu => GetMenuSection(6);



    private IWebElement GetMenuSection(int elemNo)
    {
        if (elemNo < 1 || elemNo > 6)
        {
            throw new ArgumentException("Element number out of valid range [1-6]");
        }

        return Driver.FindElement(By.XPath($"//div[@class=\"element-group\"][{elemNo}]"));
    }

    #region Enum to string Dictionaries
    public Dictionary<ElementsMenuOption, string> ElementsMenuOptionsText = new Dictionary<ElementsMenuOption, string>()
    {
        { ElementsMenuOption.TextBox,           "Text Box" },
        { ElementsMenuOption.CheckBox,          "Check Box" },
        { ElementsMenuOption.RadioButton,       "Radio Button" },
        { ElementsMenuOption.WebTables,         "Web Tables" },
        { ElementsMenuOption.Buttons,           "Buttons" },
        { ElementsMenuOption.Links,             "Links" },
        { ElementsMenuOption.BrokenLinks,       "Broken Links - Images" },
        { ElementsMenuOption.UploadAndDownload, "Upload and Download" },
        { ElementsMenuOption.DynamicProperties, "Dynamic Properties" }
    };

    public Dictionary<FormsMenuOption, string> FormsMenuOptionsText = new Dictionary<FormsMenuOption, string>()
    {
        { FormsMenuOption.PracticeForm, "Practice Form" }
    };

    public Dictionary<AlertsFramesWindowsMenuOption, string> AlertsFramesWindowsMenuOptionsText = new Dictionary<AlertsFramesWindowsMenuOption, string>()
    {
        { AlertsFramesWindowsMenuOption.BrowserWindows, "Browser Windows" },
        { AlertsFramesWindowsMenuOption.Alerts,         "Alerts" },
        { AlertsFramesWindowsMenuOption.Frames,         "Frames" },
        { AlertsFramesWindowsMenuOption.NestedFrames,   "Nested Frames" },
        { AlertsFramesWindowsMenuOption.ModalDialogs,   "Modal Dialogs" }
    };

    #endregion

    public void AccessSideMenuOption(ElementsMenuOption menuOption)
    {
        IWebElement menuOptionsContainer = ElementsMenu.FindElement(By.XPath("./div[contains(@class, \"element-list\")]"));
        bool areMenuOptionsVisible = menuOptionsContainer.GetAttribute("class")!.Contains("show");

        //string menuOptionText = ElementsMenuOptionsText[menuOption];
        ElementsMenuOptionsText.TryGetValue(menuOption, out string? menuOptionText);

        if (menuOptionText is not null)
        {
            if (areMenuOptionsVisible) 
            {
                IWebElement option = Driver.FindElement(By.XPath($"//span[text()=\"{menuOptionText}\"]"));
                option.Click();
            } else
            {
                // expand menu section
                ElementsMenu.Click();

                IWebElement option = Driver.FindElement(By.XPath($"//span[text()=\"{menuOptionText}\"]"));
                option.Click();
            }
        }
    }

    public void AccessSideMenuOption(FormsMenuOption menuOption)
    {
        IWebElement menuOptionsContainer = ElementsMenu.FindElement(By.XPath("./div[contains(@class, \"element-list\")]"));
        bool areMenuOptionsVisible = menuOptionsContainer.GetAttribute("class")!.Contains("show");

        //string menuOptionText = ElementsMenuOptionsText[menuOption];
        FormsMenuOptionsText.TryGetValue(menuOption, out string? menuOptionText);

        if (menuOptionText is not null)
        {
            if (areMenuOptionsVisible)
            {
                IWebElement option = Driver.FindElement(By.XPath($"//span[text()=\"{menuOptionText}\"]"));
                option.Click();
            }
            else
            {
                // expand menu section
                FormsMenu.Click();

                IWebElement option = Driver.FindElement(By.XPath($"//span[text()=\"{menuOptionText}\"]"));
                option.Click();
            }
        }
    }
}
