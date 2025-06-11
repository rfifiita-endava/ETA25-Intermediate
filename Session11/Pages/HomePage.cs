using ETA25_Intermediate.Session11.Enums;
using OpenQA.Selenium;

namespace ETA25_Intermediate.Session11.Pages;

public class HomePage : BasePage
{

    public HomePage(IWebDriver driver) : base(driver) { }

    // WebElements
    public IWebElement ElementsCard => GetCard("Elements");
    public IWebElement FormsCard => GetCard("Forms");
    public IWebElement AlertsFramesWindowsCard => GetCard("Alerts, Frame & Windows");
    public IWebElement WidgetsCard => GetCard("Widgets");
    public IWebElement InteractionsCard => GetCard("Interactions");
    public IWebElement BookStoreApplication => GetCard("Book Store Application");

    // Access different pages
    public void AccessElementsPage() => ElementsCard.Click();
    public void AccessFormsPage() => FormsCard.Click();
    public void AccessAlertsFramesWindowsPage() => AlertsFramesWindowsCard.Click();
    public void AccessWidgetsPage() => WidgetsCard.Click();
    public void AccessInteractionsPage() => InteractionsCard.Click();
    public void AccessBookStoreApplicationPage() => BookStoreApplication.Click();

    private IWebElement GetCard(string cardName)
    {
        return Driver.FindElement(By.XPath($"//h5[text()=\"{cardName}\"]"));
    }

    public void AccessPageByName(CardName cardName)
    {
        switch(cardName)
        {
            case CardName.Elements:
                GetCard("Elements").Click();
                break;
            case CardName.Forms:
                GetCard("Forms").Click();
                break;
            case CardName.AlertsFramesWindows:
                GetCard("Alerts, Frame & Windows").Click();
                break;
            case CardName.Widgets:
                GetCard("Widgets").Click();
                break;
            case CardName.Interactions:
                GetCard("Interactions").Click();
                break;
            case CardName.BookStoreApplication:
                GetCard("Book Store Application").Click();
                break;
            default:
                throw new ArgumentException("Non existing value!");
        }
    }
}
