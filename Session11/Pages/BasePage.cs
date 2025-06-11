using ETA25_Intermediate.Session11.Enums;
using OpenQA.Selenium;

namespace ETA25_Intermediate.Session11.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; init; }

    public BasePage(IWebDriver driver)
    {
        Driver = driver;
    }

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


    public Dictionary<Widgets, string> WidgetsMenuOptionsText = new()
    {
        { Widgets.Accordian, "Accordian" },
        { Widgets.AutoComplete, "Auto Complete" },
        { Widgets.DatePicker, "Date Picker" },
        { Widgets.Slider, "Accordian" },
        { Widgets.ProgressBar, "Progress Bar" },
        { Widgets.Tabs, "Accordian" },
        { Widgets.ToolTips, "Tool Tips" },
        { Widgets.Menu, "Accordian" },
        { Widgets.SelectMenu, "Select Menu" }
    };

    public Dictionary<Interactions, string> InteractionsMenuOptionsText = new()
    {
        { Interactions.Sortable, "Sortable" },
        { Interactions.Selectable, "Selectable" },
        { Interactions.Resizable, "Resizable" },
        { Interactions.Droppable, "Droppable" },
        { Interactions.Draggable, "Dragabble" }
    };
    #endregion

    #region Access Side Menu Options
    public void AccessSideMenuOption(ElementsMenuOption menuOption)
    {
        ElementsMenuOptionsText.TryGetValue(menuOption, out string? menuOptionText);

        ClickOnSideMenuOption(menuOptionText, ElementsMenu);
    }

    public void AccessSideMenuOption(FormsMenuOption menuOption)
    {
        FormsMenuOptionsText.TryGetValue(menuOption, out string? menuOptionText);

        ClickOnSideMenuOption(menuOptionText, FormsMenu);
    }

    public void AccessSideMenuOption(AlertsFramesWindowsMenuOption menuOption)
    {
        AlertsFramesWindowsMenuOptionsText.TryGetValue(menuOption, out string? menuOptionText);

        ClickOnSideMenuOption(menuOptionText, AlertsFramesWindowsMenu);
    }

    public void AccessSideMenuOption(Widgets menuOption)
    {
        WidgetsMenuOptionsText.TryGetValue(menuOption, out string? menuOptionText);

        ClickOnSideMenuOption(menuOptionText, WidgetsMenu);
    }

    public void AccessSideMenuOption(Interactions menuOption)
    {
        InteractionsMenuOptionsText.TryGetValue(menuOption, out string? menuOptionText);

        ClickOnSideMenuOption(menuOptionText, InteractionsMenu);
    }

    private void ClickOnSideMenuOption(string? menuOptionText, IWebElement parentWebElement)
    {
        IWebElement menuOptionsContainer = parentWebElement.FindElement(By.XPath("./div[contains(@class, \"element-list\")]"));
        bool areMenuOptionsVisible = menuOptionsContainer.GetAttribute("class")!.Contains("show");

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
                parentWebElement.Click();

                IWebElement option = Driver.FindElement(By.XPath($"//span[text()=\"{menuOptionText}\"]"));
                option.Click();
            }
        }
    }
    #endregion

}
