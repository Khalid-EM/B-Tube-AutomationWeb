using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;


namespace TestProject2
{
    public class DriverBrowser
    {
        IWebDriver webDriver = new ChromeDriver();


        public void Take_Screenshot()
        {
            ((ITakesScreenshot)webDriver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
        }

        public IWebDriver WebDriver
        {
            get { return webDriver; }
        }
    }

    

    public class Tests
    {
        // Hooks in NUnit
        [SetUp]
        public void Setup()
        {
            
        }



        [Test]
        public void Test_LoginAsAdmin()
        {
            DriverBrowser driver = new DriverBrowser();

            var wait = new WebDriverWait(driver.WebDriver, TimeSpan.FromSeconds(10));

            var wait2 = driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            driver.WebDriver.Manage().Window.Maximize();
            // Navigate to Site
            driver.WebDriver.Navigate().GoToUrl("https://brightshopapp.herokuapp.com/#/");

            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='css-1jf7604']")));
            //Thread.Sleep(5000);

           // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='SignInButton']")));
            Thread.Sleep(4000);

            IWebElement btubeLogin = driver.WebDriver.FindElement(By.XPath("//button[@id='SignInButton']"));
           
            btubeLogin.Click();

            btubeLogin = driver.WebDriver.FindElement(By.XPath("//input[@id='SignInEmail']"));
            btubeLogin.SendKeys("brent.dar@ap.be");
            btubeLogin = driver.WebDriver.FindElement(By.XPath("//input[@id='SignInPassword']"));
            btubeLogin.SendKeys("hond");
            btubeLogin = driver.WebDriver.FindElement(By.XPath("//button[@id='SignInButtonComplete']"));
            driver.Take_Screenshot();
            btubeLogin.Click();

            //webDriver.Quit();

        }


        

        [Test]

        public void Test_search_bar_1()
        {
            //Open Browser 
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Manage().Window.Maximize();
            // Navigate to Site
            webDriver.Navigate().GoToUrl("https://brightshopapp.herokuapp.com/#/");

            // Pauze voor de volgende actie
            Thread.Sleep(6000);


            IWebElement btubeLogin = webDriver.FindElement(By.XPath("/html/body/div/div/div[2]/header/div[2]/div/div/div/div/input"));
            btubeLogin.SendKeys("Battlefield 2025");
            btubeLogin.SendKeys(Keys.Down);
            btubeLogin.SendKeys(Keys.Enter);


            //webDriver.Close();


        }

        [Test]

        public void Test_rent_movie_button()
        {
            //Open Browser 
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Manage().Window.Maximize();
            // Navigate to Site
            webDriver.Navigate().GoToUrl("https://brightshopapp.herokuapp.com/#/");

            // Pauze voor de volgende actie
            Thread.Sleep(6000);


            IWebElement btubeLogin = webDriver.FindElement(By.XPath("/html/body/div/div/div[2]/header/div[2]/div/div/div/div/input"));
            btubeLogin.SendKeys("Battlefield 2025");
            btubeLogin.SendKeys(Keys.Down);
            btubeLogin.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            btubeLogin = webDriver.FindElement(By.CssSelector("#RentMovieButton"));
            btubeLogin.Click();

            //webDriver.Close();


        }

        [Test]

        public void Test_search_bar_2() //Visual test but at the same time functional => test will fail cuz no dropdown
        {
            //Open Browser 
            DriverBrowser driver = new DriverBrowser();

            driver.WebDriver.Manage().Window.Maximize();
            // Navigate to Site
            driver.WebDriver.Navigate().GoToUrl("https://brightshopapp.herokuapp.com/#/");

            // Pauze voor de volgende actie
            Thread.Sleep(6000);


            IWebElement btubeLogin = driver.WebDriver.FindElement(By.XPath("/html/body/div/div/div[2]/header/div[2]/div/div/div/div/input"));
            btubeLogin.SendKeys("Battlefield 2025");
            btubeLogin.SendKeys(Keys.Down);
            driver.Take_Screenshot(); // Laat de dropdown options zien
            btubeLogin.SendKeys(Keys.Enter);
            Thread.Sleep(2000); // De modal komt na een paar seconden delay
            //driver.Take_Screenshot();
            ///Test zal slagen maar op de UI zal je te zien krijgen dat hij "No Options" krijgt, als er daarna een interactie gebeurd zal deze namelijk falen.
            ///De onderste 3 lijnen code zal zijn voor de Rentbutton te klikken op de modal, maar die zal er niet zijn dus gaan hij falen

            
           Thread.Sleep(2000);
           btubeLogin = driver.WebDriver.FindElement(By.CssSelector("#RentMovieButton"));
           btubeLogin.Click();
            
            //webDriver.Close();

        }

        [Test]

        public void Test_more_info() //Zelfs als de aan staat zal deze test slagen omdat hij op de effectief
                                     // op de link kan klikken maar wordt niet redirected naar een andere pagina
        {
            //Open Browser 
            DriverBrowser driver = new DriverBrowser();

            driver.WebDriver.Manage().Window.Maximize();
            // Navigate to Site
            driver.WebDriver.Navigate().GoToUrl("https://brightshopapp.herokuapp.com/#/");

            // Pauze voor de volgende actie
            Thread.Sleep(6000);


            IWebElement btubeLogin = driver.WebDriver.FindElement(By.XPath("/html/body/div/div/div[2]/header/div[2]/div/div/div/div/input"));
            btubeLogin.SendKeys("Battlefield 2025");
            btubeLogin.SendKeys(Keys.Down);
            btubeLogin.SendKeys(Keys.Enter);
            Thread.Sleep(2000); // De modal komt na een paar seconden delay


            //btubeLogin = driver.WebDriver.FindElement(By.ClassName("css-14nkc1e"));
            btubeLogin = driver.WebDriver.FindElement(By.LinkText("Click here to see more info"));
            btubeLogin.Click();
            driver.Take_Screenshot();


            //webDriver.Close();

        }



        [Test]
        public void Test_Screenshot()
        {
            //Open Browser 
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Manage().Window.Maximize();
            // Navigate to Site
            webDriver.Url = "https://brightshopapp.herokuapp.com/#/";
            Thread.Sleep(10000);
            ((ITakesScreenshot)webDriver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
            webDriver.Quit();

        }
        [Test]
        public void Test_ScreenshotFireFox()
        {
            //Open Browser 
            IWebDriver webDriver = new FirefoxDriver();

            webDriver.Manage().Window.Maximize();
            // Navigate to Site
            webDriver.Url = "https://brightshopapp.herokuapp.com/#/";
            Thread.Sleep(10000);
            ((ITakesScreenshot)webDriver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
            webDriver.Close();

        }

    }
}