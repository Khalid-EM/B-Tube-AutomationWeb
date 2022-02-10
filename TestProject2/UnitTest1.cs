using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;


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
            //Open Browser 
            
    
            driver.WebDriver.Manage().Window.Maximize();
            // Navigate to Site
            driver.WebDriver.Navigate().GoToUrl("https://brightshopapp.herokuapp.com/#/");

            // Pauze voor de volgende actie
            System.Threading.Thread.Sleep(6000);
            // Identify Login
            //IWebElement btubeLogin = webDriver.FindElement(By.XPath("/html/body/div/div/div[2]/header/div[3]"));
            // Operation on btubeLogine
            //btubeLogin.Click();


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
            System.Threading.Thread.Sleep(6000);


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
            System.Threading.Thread.Sleep(6000);


            IWebElement btubeLogin = webDriver.FindElement(By.XPath("/html/body/div/div/div[2]/header/div[2]/div/div/div/div/input"));
            btubeLogin.SendKeys("Battlefield 2025");
            btubeLogin.SendKeys(Keys.Down);
            btubeLogin.SendKeys(Keys.Enter);






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
            System.Threading.Thread.Sleep(10000);
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
            System.Threading.Thread.Sleep(10000);
            ((ITakesScreenshot)webDriver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
            webDriver.Close();

        }

    }
}