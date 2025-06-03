﻿using ETA25_Intermediate.Session10.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ETA25_Intermediate.Session10.Drivers;

public class FirefoxBrowser : IBrowser
{
    public IWebDriver CreateDriver()
    {
        //var options = new FirefoxOptions();
        var driver = new FirefoxDriver();

        driver.Manage().Window.Maximize();

        return driver;
    }
}
