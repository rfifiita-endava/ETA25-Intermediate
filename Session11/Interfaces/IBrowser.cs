using OpenQA.Selenium;

namespace ETA25_Intermediate.Session11.Interfaces;

public interface IBrowser
{
    IWebDriver CreateDriver();
}
